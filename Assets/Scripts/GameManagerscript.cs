using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerscript : MonoBehaviour
{
    [SerializeField] GameObject pausingGameobject_;
    [SerializeField] GameObject winconditionobject_;
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
        Time.timeScale = 0;
        pausingGameobject_.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ReturnGame()
    {
        Time.timeScale = 1;
        pausingGameobject_.SetActive(false);
    }

    private void PlayerReset()
    {
        SceneManager.LoadScene("GameScene");   
    }

    private void Win()
    {
        
    }
}
