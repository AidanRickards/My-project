using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelperScript : MonoBehaviour
{
    public void FlipObject( bool flip )
    {
        SpriteRenderer sr = gameObject.GetComponent<SpriteRenderer>();

        if(flip == true)
        {
            sr.flipX = true; ;
        }
        else
        {
            sr.flipX=false; ;
        }
    }

    // declare this variable at the top of your HelperScript class
    LayerMask groundLayerMask;



    void Start()
    {
        // set the mask to be "Ground"
        groundLayerMask = LayerMask.GetMask("Ground");
    }



    void DoRayCollisionCheck()
    {
        float rayLength = 0.5f; // length of raycast


        //cast a ray downward 
        RaycastHit2D hit;

        hit = Physics2D.Raycast(transform.position, -Vector2.up, rayLength, groundLayerMask);

        Color hitColor = Color.white;


        if (hit.collider != null)
        {
            print("Player has collided with Ground layer");
            hitColor = Color.red;
        }
        // draw a debug ray to show ray position
        // You need to enable gizmos in the editor to see these
        Debug.DrawRay(transform.position, -Vector2.up * rayLength, hitColor);

    }
}

