using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Counter : MonoBehaviour
{





    int counter = 0;

    void OnGUI()
    {
        GUI.Label(new Rect(40, 20, 200, 50), "COUNTER: " + counter);
        {

            if (counter >= 4)
            {
                Application.LoadLevel("win_scene"); // this has to be changed to the marking of the task
            }

        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.transform.gameObject.CompareTag("Player"))
        {
            counter++;
        }
    }


   
}