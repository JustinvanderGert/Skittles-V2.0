using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Lights : MonoBehaviour
{
    [SerializeField] GameObject lightLight;
    private bool lightActive = false;
    private bool interact;

    int counter = 0;

    void OnGUI()
    {
        GUI.Label(new Rect(40, 20, 200, 50), "COUNTER: " + counter);
        {

            if (counter >= 6)
            {
                Application.LoadLevel("win_scene"); // this has to be changed to the marking of the task
            }

        }
    }


    // Start is called before the first frame update
    void Start()
    {
        lightLight.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (interact && Input.GetKeyDown(KeyCode.A))
        {
            if (lightActive == false)
            {
                lightLight.gameObject.SetActive(true);
                lightActive = true;
            }
            else
            {
                lightLight.gameObject.SetActive(false);
                lightActive = false;
            }
        }
        if (Input.GetKeyDown(KeyCode.A)(0))
        {
            counter++
        }
        void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                interact = true;
            }
        }


        void OnTriggerExit(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                interact = false;
            }
        }
    }
}