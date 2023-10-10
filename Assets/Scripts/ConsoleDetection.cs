using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsoleDetection : MonoBehaviour
{    
    void Update()
    {
        if (Input.GetKey("h") == true)
            print("Hello World");
    }
}
