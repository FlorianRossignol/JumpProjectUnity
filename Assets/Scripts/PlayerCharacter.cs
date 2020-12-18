using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerCharacter : MonoBehaviour
{
    public enum State
    {
        NONE,
        IDLE,
        WALK,
        JUMP
    }
    [SerializeField] private PlayerCharacterFootScript foot_;
    private State currentState_ = State.NONE;
    private const float moveSpeed_ = 2.0f;
    private const float jumpSpeed_ = 3.0f;
    private float moveDir_ = 0.0f;
    Rigidbody2D body_;
    private Transform transform_;
    bool isFacingRight_ = false;
    SpriteRenderer sprite_;
    Camera cam_;
    Animator anim_;

    // Start is called before the first frame update
    void Start()
    {
        body_ = GetComponent<Rigidbody2D>();
        sprite_ = GetComponent<SpriteRenderer>();
        transform_ = GetComponent<Transform>();
        cam_ = Camera.main;
        anim_ = GetComponent<Animator>();
        ChangeState(State.IDLE);
    }

    // Update is called once per frame

    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            moveDir_ = 1.0f;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            moveDir_ = -1.0f;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Jump();
        }

        var vel = body_.velocity;
        body_.velocity = new Vector2(moveSpeed_ * moveDir_, body_.velocity.y);

        switch (currentState_)
        {
            case State.IDLE:
                if (foot_.FootContact == 0)
                {
                    ChangeState(State.JUMP);
                }
                break;
            case State.WALK:

                if (foot_.FootContact == 0)
                {
                    ChangeState(State.JUMP);
                }
                break;
            case State.JUMP:
                if (foot_.FootContact > 0)
                {
                    ChangeState(State.IDLE);
                }
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }


    private void Jump()
    {
        var vel = body_.velocity;
        body_.velocity = new Vector2(body_.velocity.x, jumpSpeed_);
    }

    void ChangeState(State state)
    {
        switch(state)
        {
            case State.IDLE:
                anim_.Play("idle");
                break;
            case State.WALK:
                anim_.Play("walk");
                break;
            case State.JUMP:
                anim_.Play("jump");
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(state), state, null);
        }
        currentState_ = state;
    }
}
