using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollision : MonoBehaviour
{
  
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ennemi")
        {
            //Lorsqu'on détect un collision entre deux objets ayant un box collider
            //On détruit le gameObject
            Destroy(gameObject);
            Destroy(other.gameObject);
            //On écrit ce message dans la console
            Debug.Log("OUF! vous l'avez échappé belle!");
        }
          
    }
}
