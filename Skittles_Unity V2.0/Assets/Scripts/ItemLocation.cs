using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// cross references items for each position
// attached to every attach point for objects, checking to see if its in the correct places

public class ItemLocation : MonoBehaviour
{
    public GameObject correctItem;
    public GameObject heldItem;

    public bool hasCorrectItem;

    public void CheckItem()
    {
        if (heldItem == correctItem)
        {
            hasCorrectItem = true;
        }

        else
        {
            hasCorrectItem = false;
        }
    }
}
