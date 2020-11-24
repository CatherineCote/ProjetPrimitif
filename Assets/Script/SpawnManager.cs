using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    //Créer des gameObject pour les prefabs
    public GameObject ObstaclePrefabs;
    public GameObject EnnemiPrefabs;
    //variable limitant la position du spawn à la pateforme du jeu
    private float spawnRangeX = -30;
    private float spawnPosZ = 7;

    //variable limitant la position du spawn de l'ennemi à la pateforme du jeu 
    private float spawnEnnemiRangeX = -34;
    private float spawnEnnemiPosZ = 5;

    //Variable pour le delais du spawn ainsi que l'interval
    private float startDelay = 2;
    private float spawnInterval = 2f;

    //Variable pour le delais du spawn ainsi que l'interval Mais pour l'ennemi
    private float startDelayE = 5;
    private float spawnIntervalE = 1.5f;

    //Variable pour l'audio de l'ennmmi
    public AudioClip ennemiSound;
    //créer la source de l,audio dans le spawn manager
    private AudioSource spawnManagerAudio;
  

    //Variable pur aller chercher le script du player
    private PlayerControler playerControlerScript;
    // Start is called before the first frame update
    void Start()
    {
        //Va chercher l'audio source du spawn manager
        spawnManagerAudio = GetComponent<AudioSource>();
        //Dans le gameObject player, va chercher le script playerControler
        playerControlerScript = GameObject.Find("Player").GetComponent<PlayerControler>();
        //Appel la fonction personnalisé (nomFonction, Temps delais, L'interval d'apparition)
        InvokeRepeating("SpawnObstacle", startDelay, spawnInterval);
        InvokeRepeating("SpawnEnnemi", startDelayE, spawnIntervalE);
        
    }
    //Fonction qui contient le spawn des obstacle
    void SpawnObstacle()

    {
        //Si le gameover est a faux exécute le code
        if (playerControlerScript.gameOver == false)
        {
            //génère une position au hasard selon le range qu'on lui permet
            Vector3 spawnPos = new Vector3(spawnRangeX, 7, Random.Range(-spawnPosZ, spawnPosZ));

            //Instantiate le prefabs obstacle selon le range établie
            Instantiate(ObstaclePrefabs, spawnPos, ObstaclePrefabs.transform.rotation);
        }
    }
    //Fonction qui contient le spawn des ennemi
    void SpawnEnnemi()
    {
        if (playerControlerScript.gameOver == false)
        {
            //génère une position au hasard selon le range qu'on lui permet pour l'ennemi
            Vector3 spawnPos = new Vector3(spawnEnnemiRangeX, 0.5f, Random.Range(-spawnEnnemiPosZ, spawnEnnemiPosZ));

            //Instantiate le prefabs obstacle selon le range établie
            Instantiate(EnnemiPrefabs, spawnPos, ObstaclePrefabs.transform.rotation);
            //On joue l'audio une fois l'audio de l'ennemi
            spawnManagerAudio.PlayOneShot(ennemiSound, 1.0f);
            
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
