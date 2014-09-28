using UnityEngine;
using System.Collections;

public class GameManagerScript : MonoBehaviour {
	
	public int player;
	public CubeScript[] cubes;

	// Use this for initialization
	void Start () {
		player = 1;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void nextTurn(){
		if (checkVictory()) {
			Debug.Log ("THE PLAYER " + player + " IS THE WINNER!");
			newGame();
		}

		if (player == 1) {
			player = 2;
		} else {
			player = 1;
		}
	}

	bool checkVictory(){
		bool victory = false;

		if (cubes [0].turn == cubes [1].turn && cubes [0].turn == cubes [2].turn && cubes [0].turn != 0) {
			victory = true;
		} else if (cubes [3].turn == cubes [4].turn && cubes [3].turn == cubes [5].turn && cubes [3].turn != 0) {
			victory = true;
		} else if (cubes [6].turn == cubes [7].turn && cubes [6].turn == cubes [8].turn && cubes [6].turn != 0) {
			victory = true;
		} else if (cubes [0].turn == cubes [3].turn && cubes [0].turn == cubes [6].turn && cubes [0].turn != 0) {
			victory = true;
		} else if (cubes [1].turn == cubes [4].turn && cubes [1].turn == cubes [7].turn && cubes [1].turn != 0) {
			victory = true;
		} else if (cubes [2].turn == cubes [5].turn && cubes [2].turn == cubes [8].turn && cubes [2].turn != 0) {
			victory = true;
		} else if (cubes [6].turn == cubes [4].turn && cubes [6].turn == cubes [2].turn && cubes [6].turn != 0) {
			victory = true;
		} else if (cubes [0].turn == cubes [4].turn && cubes [0].turn == cubes [8].turn && cubes [0].turn != 0) {
			victory = true;
		}

		return victory;
	}

	void newGame(){
		for (int i = 0; i < cubes.Length; i++){
			cubes[i].turn = 0;
			cubes[i].renderer.material.color = Color.white;
		}

		player = 0;
	}
}