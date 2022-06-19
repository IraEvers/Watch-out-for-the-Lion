using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    SceneHandler scriptCH;
    EnemiesHandler scriptEH;

    [SerializeField] public GameObject P0;
    [SerializeField] public GameObject P1;
    [SerializeField] public GameObject P2;
    [SerializeField] public GameObject P3;
    [SerializeField] public GameObject P4;

    public float xMove;
    public float speedX;
    private float xPos;

    public float jumpHeight;
    private float yPos;

    public float zMove;
    public float speedZ;
    public float startSpeedZ;
    public float zPos;

    private float playerSelection;

    public int currentScore;

    public bool allowedToMove;
    public bool allowedTojump;
    public bool isPlayerSelection;

    public bool isSpeakerPlaying;
    public bool isItemPlaying;

    public AudioSource speakerBackground;
    public AudioSource speakerItems;

    public AudioClip backgroundMusic;
    public AudioClip gameOverMusic;
    public AudioClip menuMusic;
    public AudioClip itemSound;
    public AudioClip lionSound;

    private void Awake()
    {
        scriptCH = GameObject.Find("Canvas").GetComponent<SceneHandler>();
        scriptEH = GameObject.Find("Player").GetComponent<EnemiesHandler>();
    }

    void Start()
    {
        speedX = 8;
        jumpHeight = 3;
        speedZ = 3;
        startSpeedZ = 5;

        allowedToMove = true;
        isSpeakerPlaying = false;
        isItemPlaying = false;

        player();
    }

    void Update()
    {

        if (!isPlayerSelection)
        {
            if (scriptCH.inGameMenuActive)
            {
                Pause();

                if (!isSpeakerPlaying)
                {
                    isSpeakerPlaying = true;
                    speakerBackground.clip = menuMusic;
                    speakerBackground.loop = true;
                    speakerBackground.Play();
                }
            }

            if (!scriptCH.inGameMenuActive && !scriptEH.gameOver)
            {
                Movement();

                speedX = 8;
                jumpHeight = 3;
                speedZ = 3;
                startSpeedZ = 5;

                if (!isSpeakerPlaying)
                {
                    isSpeakerPlaying = true;
                    speakerBackground.clip = backgroundMusic;
                    speakerBackground.loop = true;
                    speakerBackground.Play();
                }
            }

            if (scriptEH.gameOver)
            {
                Pause();
                Invoke("GameOver", 1f);


                if (!isSpeakerPlaying)
                {
                    isSpeakerPlaying = true;
                    speakerBackground.clip = gameOverMusic;
                    speakerBackground.loop = true;
                    speakerBackground.Play();
                }
            }

            if (transform.position.y == -9)
            {
                allowedTojump = true;
            }
            else
            {
                allowedTojump = false;
            }
        }
    }

    public void Movement()
    {

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            Right();
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            Left();
        }

        if ((Input.GetKey(KeyCode.W) && allowedTojump) || (Input.GetKey(KeyCode.UpArrow) && allowedTojump) || (Input.GetKey(KeyCode.Space) && allowedTojump))
        {
            Jump();
        }

        MoveForward();
    }

    public void Right()
    {
        xMove = Time.deltaTime * (speedX + (zMove * 3f));
        xPos = Mathf.Clamp(transform.position.x + xMove, -27, 27);
        yPos = transform.position.y;
        zPos = transform.position.z;

        transform.position = new Vector3(xPos, yPos, zPos);
    }

    public void Left()
    {
        xMove = Time.deltaTime * (speedX + (zMove * 3f));
        xPos = Mathf.Clamp(transform.position.x - xMove, -27, 27);
        yPos = transform.position.y;
        zPos = transform.position.z;

        transform.position = new Vector3(xPos, yPos, zPos);
    }

    public void Jump()
    {
        xPos = transform.position.x;
        yPos = transform.position.y;
        zPos = transform.position.z;

        transform.position = new Vector3(xPos, yPos + jumpHeight, zPos);
    }

    public void MoveForward()
    {
        xPos = transform.position.x;
        yPos = transform.position.y;
        zMove = Time.deltaTime * (startSpeedZ + (0.2f * Score.score));
        zPos = transform.position.z;

        transform.position = new Vector3(xPos, yPos, zPos + zMove);
    }

    public void Pause()
    {
        speedX = 0;
        jumpHeight = 0;
        speedZ = 0;
        startSpeedZ = 0;
    }

    void player()
    {
        playerSelection = PlayerPrefs.GetFloat("playerSelection");

        if (playerSelection == 0)
        {
            P0.SetActive(true);
            P1.SetActive(false);
            P2.SetActive(false);
            P3.SetActive(false);
            P4.SetActive(false);
            Debug.Log("Chicken");
        }

        if (playerSelection == 1)
        {
            P0.SetActive(false);
            P1.SetActive(true);
            P2.SetActive(false);
            P3.SetActive(false);
            P4.SetActive(false);
            Debug.Log("Cat");
        }

        if (playerSelection == 2)
        {
            P0.SetActive(false);
            P1.SetActive(false);
            P2.SetActive(true);
            P3.SetActive(false);
            P4.SetActive(false);
            Debug.Log("Dog");
        }

        if (playerSelection == 3)
        {
            P0.SetActive(false);
            P1.SetActive(false);
            P2.SetActive(false);
            P3.SetActive(true);
            P4.SetActive(false);
            Debug.Log("Pinguin");
        }

        if (playerSelection == 4)
        {
            P0.SetActive(false);
            P1.SetActive(false);
            P2.SetActive(false);
            P3.SetActive(false);
            P4.SetActive(true);
            Debug.Log("Cube");
        }
    }

    public void GameOver()
    {
        scriptEH.pauseMenuAllowed = false;
        scriptEH.endScreen.SetActive(true);

        currentScore = Score.score;
        if (currentScore > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", currentScore);
        }
    }
}
