using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    Rigidbody2D _body;
    Collider2D _col;

    [SerializeField]
    int playerNumber = 1;

    [SerializeField]
    float jumpForce = 30;
    [SerializeField]
    float moveSpeed = 10f;

    float hor = 0;

    bool vert = false;
    bool jump = false;
    [SerializeField]
    bool grounded = false;

    float movement = 0;

    // Start is called before the first frame update
    void Start()
    {
        _body = GetComponent<Rigidbody2D>();
        _col = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Read Inputs
        vert = (Input.GetAxisRaw("Vertical"+playerNumber)>0);
        hor = Input.GetAxisRaw("Horizontal" + playerNumber);
        if (grounded && vert)
        {
            jump = true;
        }
    }

    private void FixedUpdate()
    {
        //Set delta's waiting for input
        movement = 0;
        grounded = false;

        //Set a raycast to check whether or not on the ground
        Vector3 max = _col.bounds.max;
        Vector3 min = _col.bounds.min;
        Vector2 corner1 = new Vector2(max.x - .1f, min.y - .01f);
        Vector2 corner2 = new Vector2(min.x + .1f, min.y - .01f);
        Collider2D[] hit = Physics2D.OverlapAreaAll(corner1, corner2);

        if (hit != null)
        {
            foreach(Collider2D col in hit)
            {
                if (!col.isTrigger && col.gameObject !=gameObject )
                {
                    Debug.Log(col);
                    grounded = true;
                    break;
                }
            }
        }

        if (hor < 0)
        {
            movement = -moveSpeed;
        }
        else if (hor > 0)
        {
            movement = moveSpeed;
        }

        if (jump)
        {
            _body.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            jump = false;
        }

        _body.velocity = new Vector2(movement, _body.velocity.y);
    }

    public int GetPlayerNumber()
    {
        return playerNumber;
    }
}
