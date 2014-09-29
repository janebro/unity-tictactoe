using UnityEngine;
using System.Collections;

public class CubeScript : MonoBehaviour {
	
	private Texture2D circle;
	private Texture2D cross;

	public GameManagerScript gameManagerScript;
	public int turn;

	// Use this for initialization
	void Start () {
		turn = 0;
		circle = Resources.Load<Texture2D>("Circle");
		cross = Resources.Load<Texture2D>("Cross");
	}
	
	// Update is called once per frame
	void Update () { }
	
	void OnMouseUpAsButton() {
		if (turn == 0) {
			if (gameManagerScript.player == 1) {
				this.renderer.material.mainTexture =  circle;
				turn = 1;
			} else {
				this.renderer.material.mainTexture =  cross;
				turn = 2;
			}
			
			gameManagerScript.nextTurn();
		}
	}
}
