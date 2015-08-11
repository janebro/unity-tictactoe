using UnityEngine;
using System.Collections;

public class MenuScript : MonoBehaviour {

#if UNITY_STANDALONE_WIN
    void OnClick()
    {
        Application.LoadLevel("game");
    }
#endif

#if UNITY_ANDROID || UNITY_IPHONE
    void Update()
    {
        if (Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit) && hit.collider == this.gameObject.GetComponent<Collider>())
            {
                Application.LoadLevel("game");
            }
        }
    }
#endif
}
