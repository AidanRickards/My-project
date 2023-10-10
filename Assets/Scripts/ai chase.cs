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

  



    }
}
