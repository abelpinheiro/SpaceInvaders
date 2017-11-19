using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameOver : MonoBehaviour {
    public static bool isPlayerDead = false;
    private Text gameover;

	// Use this for initialization
	void Start () {
        gameover = GetComponent<Text>();
        gameover.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (isPlayerDead)
        {
            Time.timeScale = 0;
            gameover.enabled = true;
        }
	}
}
