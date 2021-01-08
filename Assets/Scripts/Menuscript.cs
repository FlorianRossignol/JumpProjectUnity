using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menuscript : MonoBehaviour
{
    GameObject GameObject_;
    private void Start()
    {
        
    }

    private void Update()
    {
        
    }
    public void StarGame()
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
