using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class EnemiesHandler : MonoBehaviour
{

    PlayerScript scriptPC;

    [SerializeField] public GameObject endScreen;

    public bool pauseMenuAllowed;
    public bool gameOver;

    void Awake()
    {
        scriptPC = GameObject.Find("Player").GetComponent<PlayerScript>();
    }

    private void Start()
    {
        gameOver = false;
    }

    private void OnCollisionEnter(Collision other)
    {

        if (other.gameObject.CompareTag("Enemy"))

        {
            Debug.Log("Hit Enemy");
            scriptPC.P0.SetActive(false);
            scriptPC.P1.SetActive(false);
            scriptPC.P2.SetActive(false);
            scriptPC.P3.SetActive(false);
            scriptPC.P4.SetActive(false);

            gameOver = true;

            scriptPC.isSpeakerPlaying = false;

            scriptPC.speakerItems.clip = scriptPC.lionSound;
            scriptPC.speakerItems.loop = false;
            scriptPC.speakerItems.Play();
        }
    }
}