using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoovingPlatform : MonoBehaviour
{
    private float Speed_;
    Rigidbody2D Body_;
    void Start()
    {
        Body_ = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Body_.velocity = Vector2.right * Speed_;
    }
}
