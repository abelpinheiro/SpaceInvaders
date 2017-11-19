using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movPlayer : MonoBehaviour {
    public float movMulti;

    public float tiroInicial;
    public float tiroContinuo; //frequencia de tiros
    public GameObject tiros; 

    public int numTiros;
    List<GameObject> listaTiros;

    void Start () {
        listaTiros = new List<GameObject>();
        for(int i = 0; i < numTiros; i++)
        {
            GameObject obj = (GameObject)Instantiate(tiros);
            obj.SetActive(false);
            listaTiros.Add(obj);
        }
	}
	
	// Update is called once per frame
	void Update () {
        float posX = transform.position.x + Input.GetAxisRaw("Horizontal") * Time.deltaTime * movMulti;

        transform.position = new Vector3(Mathf.Clamp(posX, -12, 12), -4.3f, 0);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            InvokeRepeating("Atirar", tiroInicial, tiroContinuo);
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            CancelInvoke("Atirar");
        }
	}

    void Atirar()
    {
        for (int i = 0; i < listaTiros.Count; i++)
        {
            if (!listaTiros[i].activeInHierarchy)
            {
                listaTiros[i].transform.position = transform.position;
                listaTiros[i].transform.rotation = transform.rotation;
                listaTiros[i].SetActive(true);
                break;
            }
        }
    }
}