using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerscript : MonoBehaviour
{
    [SerializeField] GameObject pausingGameobject_;
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
    }
    private void StartingPauseMenu()
    { 
        Debug.Log("lol");
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
}
