using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movPlayer : MonoBehaviour {
    public float minBound, maxBound;
    public float speed;
    private Transform player;

    void Start () {
        player = GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
        float posX = Input.GetAxis("Horizontal");
        if (player.position.x < minBound && posX < 0)
        {
            posX = 0;
        }
        else if (player.position.x > maxBound && posX > 0)
        {
            posX = 0;
        }

        player.position += Vector3.right * posX * speed;
	}
}