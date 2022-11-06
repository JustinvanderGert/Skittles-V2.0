using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


public class Lights : MonoBehaviour
{
    List<UnityEngine.XR.InputDevice> inputDevices = new List<UnityEngine.XR.InputDevice>();

    [SerializeField] GameObject lightLight;
    private bool lightActive = false;
    private bool interact;

    public float activationDistance = 10f;

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


        UnityEngine.XR.InputDevices.GetDevices(inputDevices);
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
        if (Input.GetKeyDown(KeyCode.A))
        {
            counter++;
        }

        /*
        var leftHandDevices = new List<UnityEngine.XR.InputDevice>();
        UnityEngine.XR.InputDevices.GetDevicesAtXRNode(UnityEngine.XR.XRNode.LeftHand, leftHandDevices);
        UnityEngine.XR.InputDevice device;
        if (leftHandDevices.Count == 1)
        {
            device = leftHandDevices[0];
            Debug.Log(string.Format("Device name '{0}' with role '{1}'", device.name, device.role.ToString()));
        }
        else if (leftHandDevices.Count > 1)
        {
            Debug.Log("Found more than one left hand!");
        }

        if (device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.triggerButton, out triggerValue) && triggerValue)
        {
            Debug.Log("Trigger button is pressed.");
        }*/
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

    public void SwitchLight(GameObject controller)
    {
        float distance = Vector3.Distance(transform.position, controller.transform.position);

        if (distance <= activationDistance)
        {
            Debug.Log("Switched Light");
            lightActive = !lightActive;
            lightLight.gameObject.SetActive(lightActive);

            counter++;
        }
    }
}