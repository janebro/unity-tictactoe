using UnityEngine;
using System.Collections;

public class CubeScript : MonoBehaviour {

	public Color colorPlayer1 = Color.yellow;
	public Color colorPlayer2 = Color.black;
	public GameManagerScript gameManagerScript;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnMouseUpAsButton() {
		if (gameManagerScript.player == 1) {
			this.renderer.material.color = colorPlayer1; 
		} else {
			this.renderer.material.color = colorPlayer2;
		}

		gameManagerScript.nextTurn ();
	}
}
