using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnetism : MonoBehaviour
{
    [SerializeField]
    float magnetForce;

    PointEffector2D _effect;
    PlayerMovement player;

    float playerNumber;
    

    private void Start()
    {
        _effect = GetComponent<PointEffector2D>();
        player = GetComponentInParent<PlayerMovement>();
        playerNumber = player.GetPlayerNumber();
    }

    private void Update()
    {
        if (Input.GetButton("Action" + playerNumber) && player.IsGrounded())
        {
            _effect.forceMagnitude = magnetForce;

        }
        else
        {
            _effect.forceMagnitude = 0;
        }   
    }
}
