using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    //Variable qui va chercher l'axe horizontale
    public float horizontalInput;
    //Variable qui va chercher l'axe vertical
    public float verticaleInput;
    //Variable pour la vitesse
    private float speed = 10;
    //Limite sur l'axe des z
    private float zLimit = 7;
    //Variable bool game over est faux
    public bool gameOver = false;
    //Audio pour les projectile
    public AudioClip projectileSound;
    //source qui se trouve dans le player
    private AudioSource playerAudio;
    //Variable pour la systeme de particule avec celle d'explosion
    public ParticleSystem explosionParticle;
    //Variable pour la systeme de particule avec celle de saleté
    public ParticleSystem dirtParticle;
    //crée un game object avec le prefabs du prejectile
    public GameObject projectilePrefab;
    // Start is called before the first frame update
    void Start()
    {
        //Va chercher l'audio source
        playerAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
        //si le gameOver == faux
        if (gameOver == false)
        {
            //Va chercher l'axe horizontal
            horizontalInput = Input.GetAxis("Horizontal");
            //transfom le translate dans la direction back fois la temps la vitesse et l'axe horizontale
            transform.Translate(Vector3.back * Time.deltaTime * speed * horizontalInput);
            // Va chercher l'axe horizontal
            verticaleInput = Input.GetAxis("Vertical");
            //transfom le translate dans la direction back fois la temps la vitesse et l'axe horizontale
            transform.Translate(Vector3.up * Time.deltaTime * speed * verticaleInput);
        }
        // si la position z depasse 7 (la limite de la plateforme)
        if (transform.position.z > zLimit)
        {
            //On désigne la position selon la limite des 3 axes
            transform.position = new Vector3(transform.position.x, transform.position.y, zLimit);
        }
        // si la position z depasse -7 (la limite de la plateforme)
        else if (transform.position.z < -zLimit)
        {
            //On désigne la position selon la limite des 3 axes dans le negatif
            transform.position = new Vector3(transform.position.x, transform.position.y, -zLimit);
        }
        
        //Si on appuit sur la barre espace
            if (Input.GetKeyDown(KeyCode.Space))
            {
            //On imprime ce message dans la console
                print("space key was pressed");
                // Instantiate ( le prefab , sa position , sa rotation)
                Instantiate(projectilePrefab, transform.position + new Vector3(1, 0, 0), transform.rotation);
            //Joue l'audio du projectile, il joue une seule fois
                playerAudio.PlayOneShot(projectileSound, 1.0f);
                

            }

        

    }
    private void OnTriggerEnter(Collider other)
    {
       
        if (other.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            dirtParticle.Stop();
            Debug.Log("GAME OVER");
           
        }
        else if (other.gameObject.CompareTag("Ennemi"))
        {
            gameOver = true;
            dirtParticle.Stop();
            Debug.Log("GAME OVER");
            explosionParticle.Play();
        }

    }
  


}
