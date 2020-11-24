using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    //variable pour la vitesse
    private float speed = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //On change la translation qu'on modifie la direction fois la vitesse et le temps
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }
}
