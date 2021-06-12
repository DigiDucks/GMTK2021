using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FREN_BRAIN : MonoBehaviour
{
    Rigidbody2D _body;
    Collider2D _col;

    // color that the unit starts initialized asS
    [SerializeField]
    Color start_color;

    // color that the unit becomes when it becomes a fren
    [SerializeField]
    Color fren_color;

    // amount of jump
    [SerializeField]
    float jumpForce = 2;
    // speed of unit
    [SerializeField]
    float moveSpeed = 10f;

    // controller variables
    float hor = 0;
    bool vert = false;
    bool jump = false;
    [SerializeField]
    bool grounded = false;
    [SerializeField]
    bool touching_right = false;
    [SerializeField]
    bool touching_left = false;

    float movement = 0;

    //brain variables
    public Transform player_ref;
    bool isFren = false;

    // Start is called before the first frame update
    void Start()
    {
        _body = GetComponent<Rigidbody2D>();
        _col = GetComponent<Collider2D>();
        //initialize color
        SpriteRenderer my_sprite = gameObject.GetComponent<SpriteRenderer>();
        my_sprite.color = start_color;
    }

    // Update is called once per frame
    void Update()
    {
        //Brain stuff goes on here
        // If it is not yet a fren
        if (!isFren)
        {
            //check to see if player is in range
            Transform myTransform = gameObject.GetComponent<Transform>();
            float distance = Vector2.Distance(player_ref.position, myTransform.position);
            if(distance < 3)
            {
                //if it is, become a fren and switch to the new color
                isFren = true;
                SpriteRenderer my_sprite = gameObject.GetComponent<SpriteRenderer>();
                my_sprite.color = fren_color;
            }

        } else //otherwise, it is a fren
        {
            // check difference in X coord
            Transform myTransform = gameObject.GetComponent<Transform>();
            float side = player_ref.position.x - myTransform.position.x;
            // if it goes too far left, move left
            if (side < -3)
            {
                hor = -1;
            }
            // if it goes too far right, go right
            else
            if (side > 3)
            {
                hor = 1;
            }
            //otherwise, stop moving
            else hor = 0;

            //TODO: If stuck on wall, jump
            if(side < -3 && touching_left && grounded)
            {
                jump = true;
            }
            else if(side > 3 && touching_right && grounded)
            {
                jump = true;
            }
        }
    }

    private void FixedUpdate()
    {
        //Set delta's waiting for input
        movement = 0;
        grounded = false;
        touching_left = false;
        touching_right = false;

        //Set a raycast to check whether or not on the ground
        Vector3 max = _col.bounds.max;
        Vector3 min = _col.bounds.min;
        Vector2 corner1 = new Vector2(max.x -.01f , min.y - .01f);
        Vector2 corner2 = new Vector2(min.x + .01f , min.y - .01f);
        Collider2D[] hit = Physics2D.OverlapAreaAll(corner1, corner2);

        if (hit != null)
        {
            foreach (Collider2D col in hit)
            {

                if (!col.isTrigger && col.gameObject != gameObject)
                {
                    Debug.Log(col);
                    grounded = true;
                    break;
                }
            }
        }

        //Set a raycast to check whether or not it is stuck on it's right side
        corner1 = new Vector2(max.x + .01f, max.y - .01f);
        corner2 = new Vector2(max.x + .01f, min.y + .02f);
        hit = Physics2D.OverlapAreaAll(corner1, corner2);

        if (hit != null)
        {
            foreach (Collider2D col in hit)
            {

                if (!col.isTrigger && col.gameObject != gameObject)
                {
                    Debug.Log(col);
                    touching_right = true;
                    break;
                }
            }
        }

        //Set a raycast to check whether or not on the ground
        corner1 = new Vector2(min.x - .01f, max.y - .01f);
        corner2 = new Vector2(min.x - .01f, min.y + .02f);
        hit = Physics2D.OverlapAreaAll(corner1, corner2);

        if (hit != null)
        {
            foreach (Collider2D col in hit)
            {

                if (!col.isTrigger && col.gameObject != gameObject)
                {
                    Debug.Log(col);
                    touching_left = true;
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
}
