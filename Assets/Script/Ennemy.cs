using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemy : MonoBehaviour
{
    //Variable pour la vitesse
    private float speed = 3;
    //Variable pour le rigidbody de l'ennemi
    private Rigidbody enemyRb;
    //On crée un game objeco pour le player
    private GameObject player;
    //Variable pour la systeme de particule avec celle de saleté
    public ParticleSystem dirtParticle;
    //Créer une variavle qui se réfere au script du player
    private PlayerControler playerControlerScript;
    // Start is called before the first frame update
    void Start()
    {
        //Dans le script du player, va dans le gameObject, trouve player et va cerhcer son component "playerController"
                                                                                     //(le script est un component aussi)
        playerControlerScript = GameObject.Find("Player").GetComponent<PlayerControler>();
        
        //Va chercher le rigidbody qui se trouve sur l'ennemi
        enemyRb = GetComponent<Rigidbody>();
        //Player, on va chercher le gameObject player
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //Si le gameOver est a false
        if (playerControlerScript.gameOver == false)
        {
            //L'ennemi va toujours avancer en direction du player selon la position de celui-ci
            Vector3 lookDirection = (player.transform.position - transform.position).normalized;
            enemyRb.AddForce(lookDirection * speed);
            dirtParticle.Play();
        }
    }
}
