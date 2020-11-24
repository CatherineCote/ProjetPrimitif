using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBottom : MonoBehaviour
{
    public float speed = 10;
    private PlayerControler playerControlerScript;
    // Start is called before the first frame update
    void Start()
    {
        playerControlerScript = GameObject.Find("Player").GetComponent<PlayerControler>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerControlerScript.gameOver == false)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
    }
}
