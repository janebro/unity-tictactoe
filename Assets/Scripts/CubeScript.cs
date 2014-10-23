using UnityEngine;
using System.Collections;

public class CubeScript : MonoBehaviour {
	
	public Texture player1_texture;
	public Texture player2_texture;
    public Texture init_texture;
	public GameManagerScript gameManagerScript;
	public int turn;

	// Use this for initialization
	void Start () {
		turn = 0;
        animation.wrapMode = WrapMode.ClampForever;
        this.renderer.material.mainTexture = init_texture;
	}
	
	void OnMouseUpAsButton() {
		if (turn == 0) {
			if (gameManagerScript.player == 1) {
				turn = 1;
			} else {
				turn = 2;
			}
			
            animation.CrossFade("cube_rotation");
			gameManagerScript.nextTurn();
		}
	}

    void SetCubeTexture() {
        if (gameManagerScript.player == 1) {
            this.renderer.material.mainTexture = player1_texture;
        } else {
            this.renderer.material.mainTexture = player2_texture;
        }
    }
}
