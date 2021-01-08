using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerscript : MonoBehaviour
{
    [SerializeField] GameObject pausingGameobject_;
    [SerializeField] GameObject playerfoot_;
    [SerializeField]AudioSource audiosource_;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.P))
        {
            StartingPauseMenu();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            PlayerReset();
        }
     
    }
    private void StartingPauseMenu()
    { 
        audiosource_.Pause();
        pausingGameobject_.SetActive(true);
        Time.timeScale = 0;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ReturnGame()
    {
        Time.timeScale = 1;
        pausingGameobject_.SetActive(false);
        audiosource_.Play();
    }

    private void PlayerReset()
    {
        SceneManager.LoadScene("GameScene");   
    }

    public void Win()
    {
        SceneManager.LoadScene("WinScene");
    }
}
