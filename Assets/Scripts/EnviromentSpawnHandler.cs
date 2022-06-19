using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnviromentSpawnHandler : MonoBehaviour
{

    PlayerScript scriptPC;
    SceneHandler scriptCH;
    EnemiesHandler scriptEH;

    [SerializeField] private GameObject[] EnviromentalProps = new GameObject[14];
    [SerializeField] private GameObject[] Border = new GameObject[1];

    private int borders;
    private int props;

    private float posX;
    private float posY;
    private float posZ;
    private float playerZ;

    private float spawnTimer;

    void Awake()
    {
        scriptPC = GameObject.Find("Player").GetComponent<PlayerScript>();
        scriptCH = GameObject.Find("Canvas").GetComponent<SceneHandler>();
        scriptEH = GameObject.Find("Player").GetComponent<EnemiesHandler>();
    }

    void Start()
    {
        spawnTimer = 1.0f;
        borders = 22;
        props = 50;

        for (int i = 0; i < borders; i++)
        {
            posX = 0;
            posY = 0;
            posZ = i * 2.5f;
            transform.position = new Vector3(posX, posY, posZ);

            Instantiate(Border[Random.Range(0, 1)], transform.position, transform.rotation);
        }

        for (int i = 0; i < props; i++)
        {
            posX = Random.Range(30, 32);
            posY = -9;
            posZ = Random.Range(0, 50);
            transform.position = new Vector3(posX, posY, posZ);

            Instantiate(EnviromentalProps[Random.Range(0, 14)], transform.position, transform.rotation);
        }

        for (int i = 0; i < props; i++)
        {
            posX = Random.Range(-32, -30);
            posY = -9;
            posZ = Random.Range(0, 50);
            transform.position = new Vector3(posX, posY, posZ);

            Instantiate(EnviromentalProps[Random.Range(0, 14)], transform.position, transform.rotation);
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
                spawnRight();
                spawnLeft();
                spawnBorder();
                spawnTimer = 0.2f - scriptPC.zMove;
            }
        }
    }

    void spawnRight()
    {
        for (int i = 0; i < props * 0.02f; i++)
        {
            posX = Random.Range(30, 32);
            posY = -9;
            posZ = playerZ + 50;
            transform.position = new Vector3(posX, posY, posZ);

            Instantiate(EnviromentalProps[Random.Range(0, 14)], transform.position, transform.rotation);
        }
    }

    void spawnLeft()
    {
        for (int i = 0; i < props * 0.02f; i++)
        {
            posX = Random.Range(-32, -30);
            posY = -9;
            posZ = playerZ + 50;
            transform.position = new Vector3(posX, posY, posZ);

            Instantiate(EnviromentalProps[Random.Range(0, 14)], transform.position, transform.rotation);
        }
    }

    void spawnBorder()
    {
        posX = 0;
        posY = 0;
        posZ = playerZ + 50;
        transform.position = new Vector3(posX, posY, posZ);

        Instantiate(Border[Random.Range(0, 1)], transform.position, transform.rotation);
    }
}

