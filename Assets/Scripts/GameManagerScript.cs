using UnityEngine;
using System.Collections;

public class GameManagerScript : MonoBehaviour {
	
	public int player;
	public CubeScript[] cubes;
    public UILabel p1Score;
    public UILabel p2Score;

    private int p1Count;
    private int p2Count;

	// Use this for initialization
	void Start() 
	{
        p1Count = 0;
        p2Count = 0;

		reset();
	}

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

	public void nextTurn() 
	{
		if (checkVictory()) 
		{
            if (player == 1)
            {
                p1Count++;
                p1Score.text = p1Count.ToString();
            }
            else
            {
                p2Count++;
                p2Score.text = p2Count.ToString();
            }
		} 
		else if (checkTie()) 
		{
            Debug.Log("TIED.");
		}

        if (checkVictory() || checkTie()) 
		{
            StartCoroutine(newGame());
        }

		if (player == 1) 
		{
			player = 2;
		} 
		else 
		{
			player = 1;
		}
	}

	public bool checkVictory() 
	{
		bool victory = false;

		if (cubes [0].turn == cubes [1].turn && cubes [0].turn == cubes [2].turn && cubes [0].turn != 0) 
		{
            for (int i = 0; i <= 2; i++) 
			{
                cubes[i].GetComponent<Renderer>().material.color = Color.yellow;
            }

            victory = true;
		} 
		else if (cubes [3].turn == cubes [4].turn && cubes [3].turn == cubes [5].turn && cubes [3].turn != 0) 
		{
            for (int i = 3; i <= 5; i++)
            {
                cubes[i].GetComponent<Renderer>().material.color = Color.yellow;
            }

            victory = true;
		} 
		else if (cubes [6].turn == cubes [7].turn && cubes [6].turn == cubes [8].turn && cubes [6].turn != 0) 
		{
            for (int i = 6; i <= 8; i++)
            {
                cubes[i].GetComponent<Renderer>().material.color = Color.yellow;
            }

            victory = true;

		} 
		else if (cubes [0].turn == cubes [3].turn && cubes [0].turn == cubes [6].turn && cubes [0].turn != 0) 
		{
            cubes[0].GetComponent<Renderer>().material.color = Color.yellow;
            cubes[3].GetComponent<Renderer>().material.color = Color.yellow;
            cubes[6].GetComponent<Renderer>().material.color = Color.yellow;
            victory = true;

		} 
		else if (cubes [1].turn == cubes [4].turn && cubes [1].turn == cubes [7].turn && cubes [1].turn != 0) 
		{
            cubes[1].GetComponent<Renderer>().material.color = Color.yellow;
            cubes[4].GetComponent<Renderer>().material.color = Color.yellow;
            cubes[7].GetComponent<Renderer>().material.color = Color.yellow;
            victory = true;
		} 
		else if (cubes [2].turn == cubes [5].turn && cubes [2].turn == cubes [8].turn && cubes [2].turn != 0) 
		{
            cubes[2].GetComponent<Renderer>().material.color = Color.yellow;
            cubes[5].GetComponent<Renderer>().material.color = Color.yellow;
            cubes[8].GetComponent<Renderer>().material.color = Color.yellow;
            victory = true;
		} 
		else if (cubes [6].turn == cubes [4].turn && cubes [6].turn == cubes [2].turn && cubes [6].turn != 0) 
		{
            cubes[6].GetComponent<Renderer>().material.color = Color.yellow;
            cubes[4].GetComponent<Renderer>().material.color = Color.yellow;
            cubes[2].GetComponent<Renderer>().material.color = Color.yellow;
            victory = true;
		} 
		else if (cubes [0].turn == cubes [4].turn && cubes [0].turn == cubes [8].turn && cubes [0].turn != 0) 
		{
            cubes[0].GetComponent<Renderer>().material.color = Color.yellow;
            cubes[4].GetComponent<Renderer>().material.color = Color.yellow;
            cubes[8].GetComponent<Renderer>().material.color = Color.yellow;
            victory = true;
		}

		return victory;
	}

	public bool checkTie() 
	{
		bool noTurnLeft = true;

		for (int i = 0; i < cubes.Length; i++){
			if (cubes[i].turn == 0) {
				noTurnLeft = false;
				break;
			}
		}

		return (!checkVictory() && noTurnLeft ? true : false);
	}

	IEnumerator newGame()
	{
        yield return new WaitForSeconds(3);
        reset();
	}

    private void reset()
    {
        for (int i = 0; i < cubes.Length; i++)
        {
            cubes[i].turn = 0;
            cubes[i].GetComponent<Renderer>().material.color = Color.white;
            cubes[i].resetCubeTexture();
            cubes[i].GetComponent<Animation>().Stop();
        }

        GetComponent<AudioSource>().Play();
        player = 1;
    }
}