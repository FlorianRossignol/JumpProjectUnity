﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPlayer : MonoBehaviour
{
   [SerializeField] GameManagerscript gamemanagerscript_;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            gamemanagerscript_.PlayerReset();
        }
    }
}
