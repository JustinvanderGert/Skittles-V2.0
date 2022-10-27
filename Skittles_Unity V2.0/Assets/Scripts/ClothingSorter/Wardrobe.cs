using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Wardrobe : MonoBehaviour
{
    public List<GameObject> hungClothes = new List<GameObject>();


    void Start()
    {
        
    }


    void Update()
    {
        
    }

    public void AddClothesToList(XRSocketInteractor socket)
    {
        IXRSelectInteractable ixrheldClothes = socket.GetOldestInteractableSelected();
        GameObject heldClothes = ixrheldClothes.transform.gameObject;

        //Debug.Log(heldClothes);

        hungClothes.Add(heldClothes);
    }

    public void RemoveClothesFromList(XRSocketInteractor socket)
    {
        IXRSelectInteractable ixrheldClothes = socket.GetOldestInteractableSelected();
        GameObject heldClothes = ixrheldClothes.transform.gameObject;

        //Debug.Log(heldClothes);

        hungClothes.Remove(heldClothes);
    }
}