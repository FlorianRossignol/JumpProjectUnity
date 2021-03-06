﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerscript : MonoBehaviour
{
    [SerializeField] GameObject pausingGameObject_;
    [SerializeField] GameObject playerFoot_;
    [SerializeField] AudioSource audioSource_;
    [SerializeField] GameObject pausingtext_;
    void Start()
    {
        
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.P) || Input.GetButton("RESETPLAYER"))
        {
            StartingPauseMenu();
        }

        if (Input.GetKeyDown(KeyCode.R) || Input.GetButton("RESET"))
        {
            PlayerReset();
        }
     
    }
    private void StartingPauseMenu()
    { 
        audioSource_.Pause();
        pausingGameObject_.SetActive(true);
        pausingtext_.SetActive(false);
        Time.timeScale = 0;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ReturnGame()
    {
        Time.timeScale = 1;
        pausingGameObject_.SetActive(false);
        pausingtext_.SetActive(true);
        audioSource_.Play();
    }

    public void PlayerReset()
    {
        SceneManager.LoadScene("GameScene");   
    }

    public void Win()
    {
        SceneManager.LoadScene("WinScene");
    }
}
