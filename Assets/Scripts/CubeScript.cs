using UnityEngine;
using System.Collections;

public class CubeScript : MonoBehaviour {
	
	public Texture player1_texture;
	public Texture player2_texture;
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
                this.renderer.material.mainTexture = player1_texture;
				turn = 1;
			} else {
                this.renderer.material.mainTexture = player2_texture;
				turn = 2;
			}
			
			gameManagerScript.nextTurn();
		}
	}
}
