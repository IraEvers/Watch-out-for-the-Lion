using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class CollectablesHandler : MonoBehaviour
{
    PlayerScript scriptPC;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI scoreTextEnd;

    public bool scoreAllowed;

    void Awake()
    {
        scriptPC = GameObject.Find("Player").GetComponent<PlayerScript>();
    }

    void Start()
    {
        Score.score = 0;
        scoreAllowed = true;
        ScoreText();
    }

    private void OnCollisionEnter(Collision other)
    {

        if (other.gameObject.CompareTag("Collectable") && scoreAllowed)

        {
            Debug.Log("Hit Collectable");

            Score.score += 2;
            scoreAllowed = false;
            ScoreText();

            scriptPC.speakerItems.clip = scriptPC.itemSound;
            scriptPC.speakerItems.loop = false;
            scriptPC.speakerItems.Play();
        }
    }

    public void ScoreText()
    {
        scoreText.text = "Score: " + Score.score.ToString();
        scoreTextEnd.text = Score.score.ToString();
    }
}