using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacterScript : MonoBehaviour
{
    public enum State
    {
        NONE,
        IDLE,
        WALK,
        JUMP
    }
    private const float speed_ = 2.0f;
    private const float jumpspeed_= 3.0f;
    private float moveDir_ = 0.0f;
    [SerializeField] Rigidbody2D body_;
    private Transform transform_;
    bool IsFacingRight_= false;
    bool IsFacingLeft_ = false;
    SpriteRenderer sprite_;
    Camera cam_;
    // Start is called before the first frame update
    void Start()
    {
        body_ = GetComponent<Rigidbody2D>();
        sprite_ = GetComponent<SpriteRenderer>();
        transform_ = GetComponent<Transform>();
        cam_ = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void FixedUpdate()
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
            moveDir_ += 1.0f;
            Jump();
        }
        var vel = body_.velocity;
        body_.velocity = new Vector2(speed_ * moveDir_, body_.velocity.y);
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
        body_.velocity = new Vector2(body_.velocity.x, moveDir_ * jumpspeed_);
    }
}

