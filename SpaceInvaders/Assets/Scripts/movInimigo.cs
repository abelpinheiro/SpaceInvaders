using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class movInimigo : MonoBehaviour {
    private float contMov = 0;
    private Transform inimigo;
    public float speedEnemyBullet = 1f;
    //public Text winText;
    gamemanager gManager;
    GameObject inObj;

    public float tiroInicial;
    public float tiroContinuo; //frequencia de tiros
    public GameObject tiros;

    public int numTiros;
    List<GameObject> listaTiros;

    // Use this for initialization
    void Start () {
        //winText.enabled = false;
        gManager = GameObject.Find("GameManager").GetComponent<gamemanager>();
        inObj = GameObject.Find("Inimigos");
        inimigo = GetComponent<Transform>();

        listaTiros = new List<GameObject>();
        for (int i = 0; i < numTiros; i++)
        {
            GameObject obj = (GameObject)Instantiate(tiros);
            obj.SetActive(false);
            listaTiros.Add(obj);
        }

    }
	
	// Update is called once per frame
	void Update () {
        contMov += Time.deltaTime;
        if(contMov > 1)
        {
            if (gManager.bateuParede == false)
            {
                if(gManager.desce == false)
                {
                    transform.position += new Vector3(.2f, 0, 0);
                    contMov = 0;
                }
                else
                {
                    transform.position += new Vector3(.2f, 0, 0);
                    inObj.transform.position += new Vector3(0, -1, 0);
                    gManager.desce = false;
                    contMov = 0;
                }
            }
            else if (gManager.bateuParede == true)
            {
                if (gManager.desce == false)
                {
                    transform.position += new Vector3(-.2f, 0, 0);
                    contMov = 0;
                }
                else
                {
                    transform.position += new Vector3(-.2f, 0, 0);
                    inObj.transform.position += new Vector3(0, -1, 0);
                    gManager.desce = false;
                    contMov = 0;
                }
            }
        }

        //InvokeRepeating("Atirar", tiroInicial, tiroContinuo);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "ParedeDir")
        {
            gManager.bateuParede = true;
            gManager.desce = true;
        }else if(collision.gameObject.tag == "ParedeEsq")
        {
            gManager.bateuParede = false;
            gManager.desce = true;
        }

        if (collision.gameObject.tag == "Bala")
        {
            Destroy(gameObject);
            collision.gameObject.SetActive(false);
            PlayerScore.playerScore += 10;
            if(inimigo.childCount == 0)
            {
                //winText.enabled = true;
            }
        }

        if(collision.gameObject.tag == "Escudo")
        {

        }
    }

    void Atirar()
    {
        //if (Random.Range(0.0f, 2.0f) == 1f)
        //{
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
        //}
    }
}
