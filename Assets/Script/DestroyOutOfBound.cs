using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBound : MonoBehaviour
{
    //Limite du haut de l'écran
    private float topBound = -30;
    //Limite du bas de l'écran
    private float lowerBound = -50;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Lorsqu'un GameObject dépense la limite du haut l'objet est détruit
        if (transform.position.x > topBound)
        {
            // Destroy me
            Destroy(gameObject);
        }
        //Lorsqu'un GameObject dépense la limite du bas l'objet est détruit
        else if (transform.position.x < lowerBound)
        {
            // Destroy me
            Destroy(gameObject);

            //On affiche ce message dans la console
            Debug.LogError("Ennemi disparu");
        }
   }
}
