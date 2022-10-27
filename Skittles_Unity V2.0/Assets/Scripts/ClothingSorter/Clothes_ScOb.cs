using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Clothes_ScOb : ScriptableObject
{
    public enum ClothesType { Shirt, Jeans, Jacket};
    public ClothesType type;

    public Color color;
}