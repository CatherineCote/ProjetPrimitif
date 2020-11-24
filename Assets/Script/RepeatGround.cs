using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatGround : MonoBehaviour
{
    //Crée une variable avec la position initial du background
    private Vector3 startPos;
    private float repeatWidth;
    public float speed = 10;
    private PlayerControler playerControlerScript;

    void Start()
    {
        //startPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        startPos = transform.position;
        //variable repeatWidth = Va chercher component BoxCollider du script
        //Puis va chercher le size du x et divise le en 2 (pour la moitié)
        repeatWidth = GetComponent<BoxCollider>().size.x;
        playerControlerScript = GameObject.Find("Player").GetComponent<PlayerControler>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerControlerScript.gameOver == false)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
            //Si la position X est plus petit que celle du départ - la moitié
            if (transform.position.x < startPos.x - repeatWidth)
            {
                Debug.Log("Restart");
                //Reload a la position de départ
                transform.position = startPos;
            }
        }
    }
}
