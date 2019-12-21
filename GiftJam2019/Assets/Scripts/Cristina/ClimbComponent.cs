using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbComponent : MonoBehaviour
{

    [SerializeField]
    ClimbComponent destinyClimbComponent;

    public ClimbComponent GetClimbComponent()
    {
        return destinyClimbComponent;
    }
}
