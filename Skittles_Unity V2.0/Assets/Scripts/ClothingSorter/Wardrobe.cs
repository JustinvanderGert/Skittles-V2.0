using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Wardrobe : MonoBehaviour
{
    public List<GameObject> hungClothes = new List<GameObject>();
    public List<GameObject> hangers = new List<GameObject>();
    public GameObject light;

    public int hangerAmount = 3;

    //Set to true if you want to check for color sorting (will disable type sorting)
    public bool sortByColor = false;

    [SerializeField]
    bool sorted = false;


    void Start()
    {
        for (int i = 0; i < hangerAmount; i++)
        {
            hungClothes.Add(null);
        }
    }

    public void AddClothesToList(XRSocketInteractor socket)
    {
        IXRSelectInteractable ixrheldClothes = socket.GetOldestInteractableSelected();
        GameObject heldClothes = ixrheldClothes.transform.gameObject;

        //Debug.Log(heldClothes);
        int hangerIndex = hangers.IndexOf(socket.gameObject);
        hungClothes[hangerIndex] = heldClothes;

        sorted = WardrobeCheck();
        if (sorted) light.SetActive(true);
        else if (!sorted) light.SetActive(false);
    }

    public void RemoveClothesFromList(XRSocketInteractor socket)
    {
        IXRSelectInteractable ixrheldClothes = socket.GetOldestInteractableSelected();
        GameObject heldClothes = ixrheldClothes.transform.gameObject;

        //Debug.Log(heldClothes);

        int hangerIndex = hangers.IndexOf(socket.gameObject);
        hungClothes[hangerIndex] = null;

        sorted = WardrobeCheck();
        if (sorted) light.SetActive(true);
        else if (!sorted) light.SetActive(false);
    }

    bool WardrobeCheck()
    {
        //If all hangers have been filled
        if (hungClothes.Count > 1 || hangerAmount == hungClothes.Count)
        {
            if (!sortByColor)
            {
                //Type check bools
                bool checkedJeans = false;
                bool checkedShirts = false;
                bool checkedJacket = false;

                //Check if the items types are sorted
                for (int i = 0; i < hungClothes.Count; i++)
                {
                    if (hungClothes[i] == null) { continue; }

                    if (i == hungClothes.Count - 1)
                    {
                        if (hungClothes[i - 1] != null || (hungClothes[i - 1] != null && hungClothes[i].GetComponent<Clothes>().Clothes_ScOb.type != hungClothes[i - 1].GetComponent<Clothes>().Clothes_ScOb.type))
                        {
                            Debug.Log("Type Checks =  " + "Jeans: " + checkedJeans + ", Jacket: " + checkedJacket + ", Shirts: " + checkedShirts + ", MyType: " + hungClothes[i].GetComponent<Clothes>().Clothes_ScOb.type);

                            //Set checked item type
                            if (hungClothes[i].GetComponent<Clothes>().Clothes_ScOb.type == Clothes_ScOb.ClothesType.Jeans && !checkedJeans)
                                checkedJeans = true;

                            else if (hungClothes[i].GetComponent<Clothes>().Clothes_ScOb.type == Clothes_ScOb.ClothesType.Shirt && !checkedShirts)
                                checkedShirts = true;

                            else if (hungClothes[i].GetComponent<Clothes>().Clothes_ScOb.type == Clothes_ScOb.ClothesType.Jacket && !checkedJacket)
                                checkedJacket = true;

                            //Next item type has already been encountered
                            else
                            {
                                Debug.Log("Return false");
                                return false;
                            }
                        }

                        continue;
                    }

                    //Is the same clothing type hanging next to it
                    if (hungClothes[i + 1] == null || (hungClothes[i + 1] != null && hungClothes[i].GetComponent<Clothes>().Clothes_ScOb.type != hungClothes[i + 1].GetComponent<Clothes>().Clothes_ScOb.type))
                    {
                        Debug.Log("Type Checks =  " + "Jeans: " + checkedJeans + ", Jacket: " + checkedJacket + ", Shirts: " + checkedShirts + ", MyType: " + hungClothes[i].GetComponent<Clothes>().Clothes_ScOb.type);

                        //Set checked item type
                        if (hungClothes[i].GetComponent<Clothes>().Clothes_ScOb.type == Clothes_ScOb.ClothesType.Jeans && !checkedJeans)
                            checkedJeans = true;

                        else if (hungClothes[i].GetComponent<Clothes>().Clothes_ScOb.type == Clothes_ScOb.ClothesType.Shirt && !checkedShirts)
                            checkedShirts = true;

                        else if (hungClothes[i].GetComponent<Clothes>().Clothes_ScOb.type == Clothes_ScOb.ClothesType.Jacket && !checkedJacket)
                            checkedJacket = true;

                        //Next item type has already been encountered
                        else
                        {
                            Debug.Log("Return false");
                            return false;
                        }
                    }
                    else
                    {
                        continue;
                    }
                }
            }
            else if (sortByColor)
            {
                //Color check bools
                bool checkedBlack = false;
                bool checkedRed = false;
                bool checkedBlue = false;

                //Check if the items colors are sorted
                for (int i = 0; i < hungClothes.Count; i++)
                {
                    if (hungClothes[i] == null) { continue; }

                    if (i == hungClothes.Count - 1)
                    {
                        //Is the same clothing color hanging next to it
                        if (hungClothes[i - 1] != null || (hungClothes[i - 1] != null && hungClothes[i].GetComponent<Clothes>().Clothes_ScOb.color != hungClothes[i - 1].GetComponent<Clothes>().Clothes_ScOb.color))
                        {
                            //Set checked item color
                            if (hungClothes[i].GetComponent<Clothes>().Clothes_ScOb.color == Clothes_ScOb.ClothesColor.Black && !checkedBlack)
                                checkedBlack = true;

                            else if (hungClothes[i].GetComponent<Clothes>().Clothes_ScOb.color == Clothes_ScOb.ClothesColor.Red && !checkedRed)
                                checkedRed = true;

                            else if (hungClothes[i].GetComponent<Clothes>().Clothes_ScOb.color == Clothes_ScOb.ClothesColor.Blue && !checkedBlue)
                                checkedBlue = true;

                            //Next item color has already been encountered
                            else
                            {
                                Debug.Log("Return false");
                                return false;
                            }
                        }

                        continue;
                    }

                    //Is the same clothing color hanging next to it
                    if (hungClothes[i + 1] != null || (hungClothes[i + 1] != null && hungClothes[i].GetComponent<Clothes>().Clothes_ScOb.color != hungClothes[i + 1].GetComponent<Clothes>().Clothes_ScOb.color))
                    {
                        //Set checked item color
                        if (hungClothes[i].GetComponent<Clothes>().Clothes_ScOb.color == Clothes_ScOb.ClothesColor.Black && !checkedBlack)
                            checkedBlack = true;

                        else if (hungClothes[i].GetComponent<Clothes>().Clothes_ScOb.color == Clothes_ScOb.ClothesColor.Red && !checkedRed)
                            checkedRed = true;

                        else if (hungClothes[i].GetComponent<Clothes>().Clothes_ScOb.color == Clothes_ScOb.ClothesColor.Blue && !checkedBlue)
                            checkedBlue = true;

                        //Next item color has already been encountered
                        else
                        {
                            Debug.Log("Return false");
                            return false;
                        }
                    }
                    else
                    {
                        continue;
                    }

                }
            }

            return true;
        }

        else
            return false;
    }
}