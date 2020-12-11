using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter: MonoBehaviour
{
    public enum State
    {
        NONE,
        IDLE,
        WALK,
        JUMP
    }
    private const float moveSpeed_ = 2.0f;
    private const float jumpSpeed_= 3.0f;
    private float moveDir_ = 0.0f;
    Rigidbody2D body_;
    private Transform transform_;
    bool isFacingRight_ = false;
    SpriteRenderer sprite_;
    Camera cam_;
    // Start is called before the first frame update
    void Start()
    {
        body_ = GetComponent<Rigidbody2D>();
        sprite_ = GetComponent<SpriteRenderer>();
        transform_ = GetComponent<Transform>();
        cam_ = Camera.main;
    }

    // Update is called once per frame

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            moveDir_ += 1.0f;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            moveDir_ -= 1.0f;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            Jump();
        }
        var vel = body_.velocity;
        body_.velocity = new Vector2(moveSpeed_ * moveDir_, body_.velocity.y);
    }


    private void PlayerReset()
    {
        if(cam_.transform.position.y > body_.transform.position.y +100)
        {
            cam_.Reset();
        }
        if(cam_.transform.position.x > body_.transform.position.x + 100)
        {
            cam_.Reset();
        }
    }
    private void Jump()
    {
        var vel = body_.velocity;
        body_.velocity = new Vector2(body_.velocity.x, jumpSpeed_);
    }
}
