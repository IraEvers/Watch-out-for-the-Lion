using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickHandler : MonoBehaviour
{
    PlayerScript scriptPC;

    public bool isChicken;
    public bool isCat;
    public bool isDog;
    public bool isPinguin;
    public bool isCube;
    private bool allowedToSwitch;

    void Awake()
    {
        scriptPC = GameObject.Find("Player").GetComponent<PlayerScript>();
    }

    void Start()
    {
        isChicken = true;
        isCat = false;
        isDog = false;
        isPinguin = false;
        isCube = false;
        allowedToSwitch = true;
    }

    void Update()
    {
        if (allowedToSwitch)
        {
            Invoke("allowSwitch", 0.1f);
        }

        playerSelection();
    }

    void playerSelection() {

        if (isChicken)
        {
            scriptPC.P0.SetActive(true);
            scriptPC.P1.SetActive(false);
            scriptPC.P2.SetActive(false);
            scriptPC.P3.SetActive(false);
            scriptPC.P4.SetActive(false);
            Debug.Log("Chicken");

            PlayerPrefs.SetFloat("playerSelection", 0f);
        }

        if (isCat)
        {
            scriptPC.P0.SetActive(false);
            scriptPC.P1.SetActive(true);
            scriptPC.P2.SetActive(false);
            scriptPC.P3.SetActive(false);
            scriptPC.P4.SetActive(false);
            Debug.Log("Cat");

            PlayerPrefs.SetFloat("playerSelection", 1f);
        }

        if (isDog)
        {
            scriptPC.P0.SetActive(false);
            scriptPC.P1.SetActive(false);
            scriptPC.P2.SetActive(true);
            scriptPC.P3.SetActive(false);
            scriptPC.P4.SetActive(false);
            Debug.Log("Dog");

            PlayerPrefs.SetFloat("playerSelection", 2f);
        }

        if (isPinguin)
        {
            scriptPC.P0.SetActive(false);
            scriptPC.P1.SetActive(false);
            scriptPC.P2.SetActive(false);
            scriptPC.P3.SetActive(true);
            scriptPC.P4.SetActive(false);
            Debug.Log("Pinguin");

            PlayerPrefs.SetFloat("playerSelection", 3f);
        }

        if (isCube)
        {
            scriptPC.P0.SetActive(false);
            scriptPC.P1.SetActive(false);
            scriptPC.P2.SetActive(false);
            scriptPC.P3.SetActive(false);
            scriptPC.P4.SetActive(true);
            Debug.Log("Cube");

            PlayerPrefs.SetFloat("playerSelection", 4f);
        }
    }

    public void pressLeft()
    {

        if (isChicken && allowedToSwitch)
        {
            isChicken = false;
            isCat = true;
            isDog = false;
            isPinguin = false;
            isCube = false;

            allowedToSwitch = false;

        }

        if (isCat && allowedToSwitch)
        {
            isChicken = false;
            isCat = false;
            isDog = true;
            isPinguin = false;
            isCube = false;

            allowedToSwitch = false;

        }

        if (isDog && allowedToSwitch)
        {
            isChicken = false;
            isCat = false;
            isDog = false;
            isPinguin = true;
            isCube = false;

            allowedToSwitch = false;

        }

        if (isPinguin && allowedToSwitch)
        {
            isChicken = false;
            isCat = false;
            isDog = false;
            isPinguin = false;
            isCube = true;

            allowedToSwitch = false;

        }

        if (isCube && allowedToSwitch)
        {
            isChicken = true;
            isCat = false;
            isDog = false;
            isPinguin = false;
            isCube = false;

            allowedToSwitch = false;

        }
    }
    public void pressRight()
    {
        if (isChicken && allowedToSwitch)
        {
            isChicken = false;
            isCat = false;
            isDog = false;
            isPinguin = false;
            isCube = true;

            allowedToSwitch = false;
        }

        if (isCat && allowedToSwitch)
        {
            isChicken = true;
            isCat = false;
            isDog = false;
            isPinguin = false;
            isCube = false;

            allowedToSwitch = false;

        }

        if (isDog && allowedToSwitch)
        {
            isChicken = false;
            isCat = true;
            isDog = false;
            isPinguin = false;
            isCube = false;

            allowedToSwitch = false;

        }

        if (isPinguin && allowedToSwitch)
        {
            isChicken = false;
            isCat = false;
            isDog = true;
            isPinguin = false;
            isCube = false;

            allowedToSwitch = false;
        }

        if (isCube && allowedToSwitch)
        {
            isChicken = false;
            isCat = false;
            isDog = false;
            isPinguin = true;
            isCube = false;

            allowedToSwitch = false;

        }
    }

    void allowSwitch()
    {
        allowedToSwitch = true;
    }
}
