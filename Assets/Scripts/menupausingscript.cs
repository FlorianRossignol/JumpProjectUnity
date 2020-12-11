using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menupausingscript : MonoBehaviour
{
    [SerializeField] GameObject pausingGameobject_;
    // Start is called before the first frame update
    void Start()
    {
        pausingGameobject_ = GetComponent<GameObject>();
    }

   
    public void StartingPauseMenu()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = -1;
            pausingGameobject_.SetActive(true);
        }
    }
}
