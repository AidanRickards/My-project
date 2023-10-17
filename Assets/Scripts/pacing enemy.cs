using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pacingenemy : MonoBehaviour
{
    SpriteRenderer sr;
    float speed = -1;
    HelperScript helper;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        helper = gameObject.AddComponent<HelperScript>();
    }



    void Update()
    {
        Color hitColor = Color.white;

        Vector3 rayOffset = new Vector3(0.13f, 0, 0);
        Vector3 rayOffset2 = new Vector3(-0.13f, 0, 0);

        bool hitLeft;
        bool hitRight;
        hitLeft = helper.ExtendedRayCollisionCheck(0.13f, 0);
        hitRight = helper.ExtendedRayCollisionCheck(-0.13f, 0);

        transform.position = new Vector2(transform.position.x  + (speed * Time.deltaTime), transform.position.y);

  
  

        if (helper.ExtendedRayCollisionCheck(0.13f, 0))
            {
                sr.flipX = false;
                speed = -speed;
            }
        


        if (helper.ExtendedRayCollisionCheck(-0.13f, 0))
        {
                speed = -speed;
                sr.flipX = true;
        }
    }
}
    