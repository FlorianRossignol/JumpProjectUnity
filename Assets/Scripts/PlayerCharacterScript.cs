using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacterScript : MonoBehaviour
{
    private const float speed_ = 1.0f;
    private const float jump_count_ = 2.0f;
    private float moveDir_ = 0.0f;
    [SerializeField] Rigidbody2D body_;
    bool IsFacingRight_= false;
    bool IsFacingLeft_ = false;

    // Start is called before the first frame update
    void Start()
    {
        body_ = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.RightArrow))
        {
            moveDir_ += 1.0f;
        }
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            moveDir_ -= 1.0f;
        }
        if(Input.GetKey(KeyCode.UpArrow))
        {
            moveDir_ += 1.0f;
        }
        body_.velocity = new Vector2(moveDir_ * speed_,moveDir_ * speed_);
    }
}
