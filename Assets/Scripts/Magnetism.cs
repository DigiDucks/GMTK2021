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

    GameObject aura;
    [SerializeField]
    float aura_alpha = 0f;
    Color aura_color;

    public float aura_speed = 1;

    private void Start()
    {
        _effect = GetComponent<PointEffector2D>();
        player = GetComponentInParent<PlayerMovement>();
        playerNumber = player.GetPlayerNumber();

        //find aura child
        aura = GetComponent<Transform>().parent.gameObject.GetComponent<Transform>().Find("aura").gameObject;
        Color original_aura_color = aura.GetComponent<SpriteRenderer>().color;
        aura_color = new Color(original_aura_color.r, original_aura_color.g, original_aura_color.b, aura_alpha);
        aura.GetComponent<SpriteRenderer>().color = aura_color;
    }

    private void Update()
    {
        if (Input.GetButton("Action" + playerNumber) && player.IsGrounded())
        {
            _effect.forceMagnitude = magnetForce;
            aura_alpha += aura_speed * Time.deltaTime;
        }
        else
        {
            _effect.forceMagnitude = 0;
            aura_alpha -= aura_speed * Time.deltaTime;
        }
        aura_alpha = Mathf.Clamp(aura_alpha, 0, 1);

        aura_color.a = aura_alpha;
        aura.GetComponent<SpriteRenderer>().color = aura_color;
    }
}
