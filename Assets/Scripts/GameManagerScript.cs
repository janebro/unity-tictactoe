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
		if (player == 1) {
			player = 2;
		} else {
			player = 1;
		}
	}
}
