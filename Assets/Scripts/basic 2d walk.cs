using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basic2dwalk : MonoBehaviour
{
    SpriteRenderer sr;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        print("start");
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float speed = 1;


        if (Input.GetKey("w") == true || Input.GetKey(KeyCode.Space) == true)
        {
            print("Player pressed up");
            transform.position = new Vector2(transform.position.x, transform.position.y + (speed * Time.deltaTime));
        }
        if (Input.GetKey("d") == true)
        {
            sr.flipX = false;
            print("Player pressed right");
            transform.position = new Vector2(transform.position.x + (speed * Time.deltaTime), transform.position.y);

        }
        if (Input.GetKey("a") == true)
        {
            sr.flipX = true;
            print("Player pressed left");
            transform.position = new Vector2(transform.position.x + (-(speed) * Time.deltaTime), transform.position.y);
        }

    }
}
