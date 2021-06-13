using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plate : MonoBehaviour
{
    public bool plate_on;

    Collider2D _col;



    // Start is called before the first frame update
    void Start()
    {
        _col = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        plate_on = false;

        //Set a raycast to check whether or not on the ground
        Vector3 max = _col.bounds.max;
        Vector3 min = _col.bounds.min;
        Vector2 corner1 = new Vector2(min.x + .01f, max.y + .01f);
        Vector2 corner2 = new Vector2(max.x - .01f, max.y + .01f);
        Collider2D[] hit = Physics2D.OverlapAreaAll(corner1, corner2);

        if (hit != null)
        {
            foreach (Collider2D col in hit)
            {
                if (col.CompareTag("Crate"))
                {
                    if (!col.isTrigger && col.gameObject != gameObject)
                    {
                        plate_on = true;
                        break;
                    }
                }

            }
        }
    }
}
