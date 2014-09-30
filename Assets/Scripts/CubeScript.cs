using UnityEngine;
using System.Collections;

public class CubeScript : MonoBehaviour {
	
	public Texture Player1Tex;
	public Texture Player2Tex;
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
				this.renderer.material.mainTexture = Player1Tex;
				turn = 1;
			} else {
				this.renderer.material.mainTexture = Player2Tex;
				turn = 2;
			}
			
			gameManagerScript.nextTurn();
		}
	}
}
