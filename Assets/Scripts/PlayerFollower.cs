using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Cam follow the player character
public class PlayerFollower : MonoBehaviour
{
    [SerializeField] private Transform player;
    private Vector3 offset_;
    private const float zPosition_ = -10.0f;
    Transform camTransform_;
    // Start is called before the first frame update
    void Start()
    {
        camTransform_ = transform;
    }

    // Update is called once per frame
    void Update()
    {
        camTransform_.position = new Vector3(player.position.x, player.position.y, zPosition_); // Camera follows the player 
    }
}
