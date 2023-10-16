using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemybehaviour : MonoBehaviour
{
    public GameObject player;
    public float speed;

    private float distance;
    SpriteRenderer sr;
    HelperScript helper;



    // Start is called before the first frame update
    void Start()
    {
        sr = gameObject.AddComponent<SpriteRenderer>();
        helper = gameObject.AddComponent<HelperScript>();
    }

    // Update is called once per frame
    void Update()
    {



        helper.FlipObject(true);
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;

        transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);

        float dist = player.transform.position.x - transform.position.x;
        if( dist > 0 )
         {
            helper.FlipObject(false);
        }

        Color hitColor = Color.blue;

        float laserlength = 1;
        Vector3 rayOffset = new Vector3(0.75f, 0, 0);
        Vector3 rayOffset2 = new Vector3(-0.75f, 0, 0);

        RaycastHit2D hit = Physics2D.Raycast(transform.position + rayOffset, Vector2.right, laserlength);
        RaycastHit2D hit2 = Physics2D.Raycast(transform.position + rayOffset2, Vector2.left, laserlength);
        if ((hit.collider != null) || (hit2.collider != null))
        {
            hitColor = Color.red;
            sr.flipX = true;
        }
        Debug.DrawRay(transform.position + rayOffset, Vector2.right * laserlength, hitColor);
        Debug.DrawRay(transform.position + rayOffset2, Vector2.left * laserlength, hitColor);
    }
}
