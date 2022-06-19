using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnHandler : MonoBehaviour
{

    PlayerScript scriptPC;
    SceneHandler scriptCH;
    EnemiesHandler scriptEH;

    [SerializeField] private GameObject[] Collectables = new GameObject[10];
    [SerializeField] private GameObject[] Enemies = new GameObject[1];

    private int collectables;
    private int enemies;

    private float posX;
    private float posY;
    private float posZ;

    private float playerZ;

    private float rotX;
    private float rotY;
    private float rotZ;

    public float spawnTimer;

    void Awake()
    {
        scriptPC = GameObject.Find("Player").GetComponent<PlayerScript>();
        scriptCH = GameObject.Find("Canvas").GetComponent<SceneHandler>();
        scriptEH = GameObject.Find("Player").GetComponent<EnemiesHandler>();
    }

    void Start()
    {
        spawnTimer = 1.0f;

        collectables = 30;
        enemies = 10;

        for (int i = 0; i < collectables; i++)
        {
            posX = Random.Range(-26, 26);
            posY = -9;
            posZ = Random.Range(10, 50);
            transform.position = new Vector3(posX, posY, posZ);

            Instantiate(Collectables[Random.Range(0, 10)], transform.position, transform.rotation);
        }

        for (int i = 0; i < enemies; i++)
        {
            posX = Random.Range(-26, 26);
            posY = -9.5f;
            posZ = Random.Range(10, 50);
            transform.position = new Vector3(posX, posY, posZ);

            rotX = 0;
            rotY = 180;
            rotZ = 0;
            transform.rotation = new Quaternion(rotX, rotY, rotZ, transform.rotation.w);

            Instantiate(Enemies[Random.Range(0, 1)], transform.position, transform.rotation);
        }
    }

    void Update()
    {
        if (!scriptCH.inGameMenuActive && !scriptEH.gameOver)
        {
            playerZ = scriptPC.transform.position.z;

            if (spawnTimer > 0)
            {
                spawnTimer -= Time.deltaTime;
            }
            else
            {
                Enemy();
                Collectable();
                spawnTimer = 1f - scriptPC.zMove;
            }
        }
    }

    void Enemy()
    {
        for (int i = 0; i < enemies * 0.15f; i++)
        {
            posX = Random.Range(-26, 26);
            posY = -9.5f;
            posZ = playerZ + 50;
            transform.position = new Vector3(posX, posY, posZ);

            rotX = 0;
            rotY = 180;
            rotZ = 0;
            transform.rotation = new Quaternion(rotX, rotY, rotZ, transform.rotation.w);

            Instantiate(Enemies[Random.Range(0, 1)], transform.position, transform.rotation);
        }
    }

    void Collectable()
    {
        for (int i = 0; i < collectables * 0.15f; i++)
        {
            posX = Random.Range(-26, 26);
            posY = -9;
            posZ = playerZ + 50;
            transform.position = new Vector3(posX, posY, posZ);

            Instantiate(Collectables[Random.Range(0, 10)], transform.position, transform.rotation);
        }
    }
}
