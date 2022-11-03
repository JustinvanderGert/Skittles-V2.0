using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Lights : MonoBehaviour
{
    [SerializeField] GameObject lightLight;
    private bool lightActive = false;
    private bool interact;


    // Start is called before the first frame update
    void Start()
    {
        lightLight.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (interact && Input.GetKeyDown(KeyCode.F))
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