using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class test : MonoBehaviour
{
    Animator anim; // ***

    // Start is called before the first frame update
    SpriteRenderer sr;
    Rigidbody2D rb;
    void Start()
    {
        print("start");
        anim = GetComponent<Animator>(); // ***
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("jump", false);
        anim.SetBool("walk", false);
        anim.SetBool("attack", false);
        float speed = 10;


        
        


        if ( Input.GetKey("w") == true || Input.GetKey(KeyCode.Space) == true)
        {
            print("Player pressed up");
            anim.SetBool("jump", true);
            transform.position = new Vector2(transform.position.x, transform.position.y + (speed*Time.deltaTime) );
        }
        if (Input.GetKey("d") == true)
        {
            sr.flipX = false;
            anim.SetBool("walk", true);
            print("Player pressed right");
            transform.position = new Vector2(transform.position.x + (speed * Time.deltaTime), transform.position.y);
            
        }
        if (Input.GetKey("a") == true)
        {
            anim.SetBool("walk", true);
            sr.flipX = true;
            print("Player pressed left");
            transform.position = new Vector2(transform.position.x + (-(speed) * Time.deltaTime), transform.position.y);
        }
        
        if (Input.GetKey(KeyCode.LeftShift) == true && Input.GetKey("d") == true)
        {
            speed = (speed + 20);
            anim.SetBool("walk", true);
            print("Player pressed right");
            transform.position = new Vector2(transform.position.x + (speed * Time.deltaTime), transform.position.y);

        }
        if (Input.GetKey(KeyCode.LeftShift) == true && Input.GetKey("a") == true)
        {
            speed = (speed + 20);
            print("Player pressed left");
            anim.SetBool("walk", true);
            transform.position = new Vector2(transform.position.x + (-(speed) * Time.deltaTime), transform.position.y);

        }

        if (Input.GetKey("r") == true)
        {
            anim.SetBool("attack", true);
            
        }


    }
}
