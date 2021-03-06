﻿using UnityEngine;
using System.Collections;

public class CubeScript : MonoBehaviour {

    public GameManagerScript gameManagerScript;
	public Texture player1_texture;
	public Texture player2_texture;
    public Texture init_texture;
	public int turn;

	// Use this for initialization
	void Start () 
    {
		turn = 0;
        GetComponent<Animation>().wrapMode = WrapMode.ClampForever;
        resetCubeTexture();
	}

#if UNITY_STANDALONE_WIN || UNITY_EDITOR_OSX
    void OnMouseUpAsButton() 
    {
        inputAction();
	}
#endif

#if UNITY_ANDROID || UNITY_IPHONE
    void Update() 
    {
        if (Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit) && hit.collider == this.GetComponent<Collider>())
            {
                inputAction();
            }
        }
    }
#endif

    public void SetCubeTexture() 
    {
        if (gameManagerScript.player == 1) 
        {
            this.GetComponent<Renderer>().material.mainTexture = player1_texture;
        } 
        else 
        {
            this.GetComponent<Renderer>().material.mainTexture = player2_texture;
        }
    }

    public void resetCubeTexture() 
    {
        this.GetComponent<Renderer>().material.mainTexture = init_texture;
    }

    private void inputAction()
    {
        if (turn == 0)
        {
            if (gameManagerScript.player == 1)
            {
                turn = 1;
            }
            else
            {
                turn = 2;
            }

            GetComponent<AudioSource>().Play();
            GetComponent<Animation>().CrossFade("cube_rotation");
            gameManagerScript.nextTurn();
        }
    }
}
