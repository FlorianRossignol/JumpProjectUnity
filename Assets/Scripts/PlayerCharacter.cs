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
    private const float DeadZone_ = 0.1f;
    private State currentState_ = State.IDLE;
    private const float moveSpeed_ = 2.0f;
    private const float jumpSpeed_ = 3.0f;
    private float moveDir_ = 0.0f;
    [SerializeField]Rigidbody2D body_;
    private Transform transform_;
    bool isFacingRight_ = false;
    [SerializeField]SpriteRenderer sprite_;
    Camera cam_;
    [SerializeField]Animator anim_;

    // Start is called before the first frame update
    void Start()
    {
        body_ = GetComponent<Rigidbody2D>();
        sprite_ = GetComponent<SpriteRenderer>();
        transform_ = GetComponent<Transform>();
        cam_ = Camera.main;
        anim_ = GetComponent<Animator>();
        ChangeState(State.JUMP);
    }

    // Update is called once per frame

    void FixedUpdate()
    {
        body_.velocity = new Vector2(Input.GetAxis("Horizontal") * moveSpeed_, body_.velocity.y);
        /*if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            moveDir_ = 1.0f;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            moveDir_ = -1.0f;
        }*/
        if (Input.GetKey(KeyCode.UpArrow))
        {
            Jump();
        }
        /*else
        {
            moveDir_ = 0;
        }*/

       /* var vel = body_.velocity;
        body_.velocity = new Vector2(moveSpeed_ * moveDir_, body_.velocity.y);*/


        if((Input.GetAxis("Horizontal")) > DeadZone_ && isFacingRight_)
        {
            flip();
        }

        if ((Input.GetAxis("Horizontal")) < -DeadZone_ && !isFacingRight_)
        {
            flip();
        }

            switch (currentState_)
        {
            case State.IDLE:
                if(Mathf.Abs(Input.GetAxis("Horizontal")) > DeadZone_)
                {
                    ChangeState(State.WALK);
                }

                if (foot_.FootContact == 0)
                {
                    ChangeState(State.JUMP);
                }
                break;
            case State.WALK:
                if(Mathf.Abs(Input.GetAxis("Horizontal")) < DeadZone_)
                {
                    ChangeState(State.IDLE);
                }

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
       /* var vel = body_.velocity;*/
        body_.velocity = new Vector2(body_.velocity.x, jumpSpeed_);
    }

    void ChangeState(State state)
    {
        switch(state)
        {
            case State.IDLE:
                anim_.Play("Idle");
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

    void flip()
    {
        sprite_.flipX = !sprite_.flipX;
        isFacingRight_ = !isFacingRight_;
    }    
}
