using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorComponent : MonoBehaviour
{

    [SerializeField]
    private string colorCode;

    public string GetColorCode() 
    {
        return colorCode;
    }
}
