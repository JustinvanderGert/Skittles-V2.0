using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


// checking to add objects placed to a list to be determined if in correct position
public class SettingTable : MonoBehaviour
{

    public void AdditemToList(XRSocketInteractor socket)
    {
        IXRSelectInteractable ixrheldItem = socket.GetOldestInteractableSelected();
        GameObject heldItem = ixrheldItem.transform.gameObject;

        GameObject snapPosition = socket.gameObject;
        snapPosition.GetComponent<ItemLocation>().heldItem = heldItem;
        snapPosition.GetComponent<ItemLocation>().CheckItem(); 

        //activate checkitem function object, should check if its the correct item or not
    }

    public void RemoveitemToList(XRSocketInteractor socket)
    {
        IXRSelectInteractable ixrheldItem = socket.GetOldestInteractableSelected();
        GameObject heldItem = ixrheldItem.transform.gameObject;

        GameObject snapPosition = socket.gameObject;
        snapPosition.GetComponent<ItemLocation>().heldItem = null;
        snapPosition.GetComponent<ItemLocation>().CheckItem();
    }
}
