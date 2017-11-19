using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tiros : MonoBehaviour {
    public float velTiro;
    public float tempoVida;

    void OnEnable()
    {
        Invoke("Desligar", tempoVida);
    }

    void Desligar()
    {
        gameObject.SetActive(false);
    }

    void OnDisable()
    {
        CancelInvoke();
    }

    // Update is called once per frame
    void Update () {
        transform.position += new Vector3(0, velTiro, 0) * Time.deltaTime; 
	}
}
