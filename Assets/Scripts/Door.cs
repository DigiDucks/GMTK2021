using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Plate plate;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Collider2D col = GetComponent<Collider2D>();
        SpriteRenderer my_sprite = gameObject.GetComponent<SpriteRenderer>();
        if (plate.plate_on)
        {
            col.enabled = false;
            my_sprite.color = new Color(my_sprite.color.r, my_sprite.color.g, my_sprite.color.b, .2f);
        }
        else
        {
            col.enabled = true;
            my_sprite.color = new Color(my_sprite.color.r, my_sprite.color.g, my_sprite.color.b, 1.0f);
        }

    }
}
