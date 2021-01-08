using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menuscript : MonoBehaviour
{
    private void Start()
    {
        
    }

    private void Update()
    {
        
    }
    public void StartGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void Tutorial()
    {
        
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
