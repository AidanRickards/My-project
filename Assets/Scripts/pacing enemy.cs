using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pacingenemy : MonoBehaviour
{
    SpriteRenderer sr;
    float speed = 1;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }


    void Update()
    {
        Color hitColor = Color.white;

        float laserlength = 0.01f;
        Vector3 rayOffset = new Vector3(0.13f, 0, 0);
        Vector3 rayOffset2 = new Vector3(-0.13f, 0, 0);

        RaycastHit2D hit = Physics2D.Raycast(transform.position + rayOffset, Vector2.right, laserlength);
        RaycastHit2D hit2 = Physics2D.Raycast(transform.position + rayOffset2, Vector2.left, laserlength);
        if ((hit.collider != null) || (hit2.collider != null))
        {
            hitColor = Color.red;
        }
        Debug.DrawRay(transform.position + rayOffset, Vector2.right * laserlength, hitColor);
        Debug.DrawRay(transform.position + rayOffset2, Vector2.left * laserlength, hitColor);

        transform.position = new Vector2(transform.position.x + (-(speed) * Time.deltaTime), transform.position.y);

        if (hit.collider != null)
        {
            speed = (speed) * -1;
            sr.flipX = false;

        }
        if (hit.collider != null)
        {
            speed = (speed) * -1;
            sr.flipX = true;

        }
    }
}
    