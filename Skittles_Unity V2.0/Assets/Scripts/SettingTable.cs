using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


// checking to add objects placed to a list to be determined if in correct position
public class SettingTable : MonoBehaviour
{
    public List<GameObject> cutlerySnaps = new List<GameObject>();
    bool allCorect = false;

    public Light completionLight;



    private void Start()
    {
        completionLight.color = Color.red;
    }

    void CheckSnaps()
    {
        bool correct = false;
        int counter = 0;

        foreach (var snap in cutlerySnaps)
        {
            if(snap.GetComponent<ItemLocation>().heldItem != null)
            {
                counter++;
            }

            if (snap.GetComponent<ItemLocation>().hasCorrectItem)
            {
                correct = true;
            }
            else
            {
                allCorect = false;
                correct = false;
                break;
            }
        }

        if (correct)
        {
            completionLight.color = Color.green;
        }
        else if(counter > 0)
        {
            completionLight.color = Color.yellow;
        } else
        {
            completionLight.color = Color.red;
        }
    }

    public void AdditemToList(XRSocketInteractor socket)
    {
        IXRSelectInteractable ixrheldItem = socket.GetOldestInteractableSelected();
        GameObject heldItem = ixrheldItem.transform.gameObject;

        GameObject snapPosition = socket.gameObject;
        snapPosition.GetComponent<ItemLocation>().heldItem = heldItem;
        snapPosition.GetComponent<ItemLocation>().CheckItem();

        CheckSnaps();

        //activate checkitem function object, should check if its the correct item or not
    }

    public void RemoveitemFromList(XRSocketInteractor socket)
    {
        IXRSelectInteractable ixrheldItem = socket.GetOldestInteractableSelected();
        GameObject heldItem = ixrheldItem.transform.gameObject;

        GameObject snapPosition = socket.gameObject;
        snapPosition.GetComponent<ItemLocation>().heldItem = null;
        snapPosition.GetComponent<ItemLocation>().CheckItem();

        CheckSnaps();
    }
}
