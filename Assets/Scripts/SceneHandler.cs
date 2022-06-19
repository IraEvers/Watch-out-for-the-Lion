using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class SceneHandler : MonoBehaviour
{
    EnemiesHandler scriptEH;
    PlayerScript scriptPC;

    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject controls;

    public bool inGameMenuActive;

    public TextMeshProUGUI highScore;


    private void Awake()
    {
        scriptEH = GameObject.Find("Player").GetComponent<EnemiesHandler>();
        scriptPC = GameObject.Find("Player").GetComponent<PlayerScript>();
    }

    void Start()
    {
        scriptEH.pauseMenuAllowed = true;
        inGameMenuActive = false;

        HighScoreText();
    }

    void Update()
    {
        if (scriptEH.pauseMenuAllowed)
        {
            if (Input.GetKey(KeyCode.M) && !inGameMenuActive)
            {
                scriptPC.isSpeakerPlaying = false;

                pauseMenu.SetActive(true);
                inGameMenuActive = true;
            }

            if (Input.GetKey(KeyCode.N) && inGameMenuActive)
            {
                scriptPC.isSpeakerPlaying = false;

                pauseMenu.SetActive(false);
                inGameMenuActive = false;
            }
        }
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        inGameMenuActive = false;

        scriptPC.isSpeakerPlaying = false;
    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
    }

    public void PickCharacter()
    {
        SceneManager.LoadScene(1);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(2);

    }
    public void controlsActivate()
    {
        controls.SetActive(true);
    }

    public void controlsDeactivate()
    {
        controls.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void HighScoreText()
    {
        highScore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
    }

    public void resetHighScore()
    {
        PlayerPrefs.SetInt("HighScore", 0);
        HighScoreText();
    }
}
