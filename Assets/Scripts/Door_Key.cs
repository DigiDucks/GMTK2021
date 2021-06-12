using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_Key : MonoBehaviour
{
    public GameObject my_key;

    // Start is called before the first frame update
    void Start()
    {
        //set key color to match door color
        Color myColor = GetComponent<SpriteRenderer>().color;
        my_key.GetComponent<SpriteRenderer>().color = myColor;
    }

    // Update is called once per frame
    void Update()
    {
        if (my_key)
        {
            Vector2 myPos = GetComponent<Transform>().position;
            Vector2 keyPos = my_key.GetComponent<Transform>().position;
            float distance = Vector2.Distance(myPos, keyPos);
            if(distance < 2)
            {
                Destroy(my_key);
                GetComponent<Collider2D>().enabled = false;
                Color myColor = GetComponent<SpriteRenderer>().color;
                GetComponent<SpriteRenderer>().color = new Color(myColor.r, myColor.g, myColor.b, 0.2f);
            }
        }
    }
}
