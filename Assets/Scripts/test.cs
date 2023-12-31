
using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class test : MonoBehaviour
{
    Animator anim;

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
        float speed = 1;


        Color hitColor = Color.white;
        bool onground = false;
        float laserlength = 0.005f;
        Vector3 rayOffset = new Vector3(0, -0.2f, 0);
        Vector3 rayOffset2 = new Vector3(-0.075f, -0.2f, 0);
        Vector3 rayOffset3 = new Vector3(0.075f, -0.2f, 0);

        RaycastHit2D hit = Physics2D.Raycast(transform.position + rayOffset, Vector2.down, laserlength);
        RaycastHit2D hit2 = Physics2D.Raycast(transform.position + rayOffset2, Vector2.down, laserlength);
        RaycastHit2D hit3 = Physics2D.Raycast(transform.position + rayOffset3, Vector2.down, laserlength);

        if ((hit.collider != null) || (hit2.collider != null) || (hit3.collider != null))
        {
            hitColor = Color.red;
        }
        Debug.DrawRay(transform.position + rayOffset, Vector2.down * laserlength, hitColor);
        Debug.DrawRay(transform.position + rayOffset2, Vector2.down * laserlength, hitColor);
        Debug.DrawRay(transform.position + rayOffset3, Vector2.down * laserlength, hitColor);

        if ((hit.collider != null) || (hit2.collider != null) || (hit3.collider != null))
        {
            onground = true;
            anim.SetBool("jump", false);
        }

        if (onground == false)
        {
            anim.SetBool("jump", true);
        }


        if ((Input.GetKey("w") == true) && (onground == true))
        {
            rb.velocity = new Vector2(rb.velocity.x, 3);
            
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
            speed = (speed + 1);
            anim.SetBool("walk", true);
            print("Player pressed right");
            transform.position = new Vector2(transform.position.x + (speed * Time.deltaTime), transform.position.y);

        }
        if (Input.GetKey(KeyCode.LeftShift) == true && Input.GetKey("a") == true)
        {
            speed = (speed + 1);
            print("Player pressed left");
            anim.SetBool("walk", true);
            transform.position = new Vector2(transform.position.x + (-(speed) * Time.deltaTime), transform.position.y);

        }

        if (Input.GetKey("r") == true)
        {
            anim.SetBool("attack", true);
            
        }


    }
    int playerHealth = 5;
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider != null && collider.gameObject.tag == "Enemy")
        {
            playerHealth--;
            print(playerHealth);
            if (playerHealth <= 0)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
