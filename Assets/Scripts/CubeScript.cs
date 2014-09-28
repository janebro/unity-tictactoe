using UnityEngine;
using System.Collections;

public class CubeScript : MonoBehaviour {

	public Color colorPlayer1 = Color.yellow;
	public Color colorPlayer2 = Color.black;
	public GameManagerScript gameManagerScript;
	public int turn;

	// Use this for initialization
	void Start () {
		turn = 0;
	}
	
	// Update is called once per frame
	void Update () { }
	
	void OnMouseUpAsButton() {
		if (turn == 0) {
			if (gameManagerScript.player == 1) {
				this.renderer.material.color = colorPlayer1;
				turn = 1;
				Debug.Log("");
			} else {
				this.renderer.material.color = colorPlayer2;
				turn = 2;
			}
			
			gameManagerScript.nextTurn();
		}
	}
}
