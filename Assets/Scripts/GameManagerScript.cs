using UnityEngine;
using System.Collections;

public class GameManagerScript : MonoBehaviour {

	//Starting with player 1
	public int player = 1;
	public CubeScript[] cubes;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void nextTurn(){
		if (!checkVictory()) {
			if (player == 1) {
				player = 2;
			} else {
				player = 1;
			}
		} else {
			Debug.Log("THE PLAYER " + player + " IS VICTORIOUS.");
		}
	}

	bool checkVictory(){
		if (cubes[0].renderer.material.color == cubes [1].renderer.material.color && cubes [0].renderer.material.color == cubes [2].renderer.material.color) {
			return true;
		} else if (cubes[3].renderer.material.color == cubes [4].renderer.material.color && cubes [3].renderer.material.color == cubes [5].renderer.material.color){
			return true;
		} else {
			return false;
		}
	}
}