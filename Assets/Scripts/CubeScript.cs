using UnityEngine;
using System.Collections;

public class CubeScript : MonoBehaviour {

	public Texture player1_texture;
	public Texture player2_texture;
    public Texture init_texture;
	public GameManagerScript gameManagerScript;
	public int turn;

	// Use this for initialization
	void Start () 
    {
		turn = 0;
        animation.wrapMode = WrapMode.ClampForever;
        resetCubeTexture();
	}

#if UNITY_STANDALONE_WIN
    void OnMouseUpAsButton() 
    {
        inputAction();
	}
#endif

#if UNITY_ANDROID || UNITY_IPHONE
    void Update() 
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit) && hit.collider == this.collider) 
        {
            inputAction();
        }
    }
#endif

    public void SetCubeTexture() 
    {
        if (gameManagerScript.player == 1) 
        {
            this.renderer.material.mainTexture = player1_texture;
        } 
        else 
        {
            this.renderer.material.mainTexture = player2_texture;
        }
    }

    public void resetCubeTexture() 
    {
        this.renderer.material.mainTexture = init_texture;
    }

    private void inputAction()
    {
        if (turn == 0)
        {
            if (gameManagerScript.player == 1)
            {
                turn = 1;
            }
            else
            {
                turn = 2;
            }

            audio.Play();
            animation.CrossFade("cube_rotation");
            gameManagerScript.nextTurn();
        }
    }
}
