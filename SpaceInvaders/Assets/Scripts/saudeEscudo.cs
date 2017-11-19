using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class saudeEscudo : MonoBehaviour {
    public float vida = 2;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(vida <= 0)
        {
            Destroy(gameObject);
        }
	}
}
