using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnetism : MonoBehaviour
{
    [SerializeField]
    float magnetForce;

    PointEffector2D _effect;
    int player;

    private void Start()
    {
        _effect = GetComponent<PointEffector2D>();
        player = GetComponentInParent<PlayerMovement>().GetPlayerNumber();
    }

    private void Update()
    {
        if (Input.GetAxis("Vertical" + player) < 0)
        {
            _effect.forceMagnitude = magnetForce;

        }
        else
        {
            _effect.forceMagnitude = 0;
        }   
    }
}
