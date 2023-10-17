using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    int playerHealth = 100;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Enemy")
        {
            playerHealth = playerHealth - 20;
            Thread.Sleep(500);
            print(playerHealth);
            if (playerHealth <= 0)
            {
                Destroy(this.gameObject);
            }
        }
    }



}
