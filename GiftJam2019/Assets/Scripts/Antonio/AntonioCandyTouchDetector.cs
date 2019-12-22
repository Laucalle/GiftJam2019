using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntonioCandyTouchDetector : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        CandyPointsComponent candyPointsComponent;
        candyPointsComponent = other.GetComponent(typeof(CandyPointsComponent)) as CandyPointsComponent;
        if (null != candyPointsComponent) {
            AddPoint(candyPointsComponent);
            Destroy(candyPointsComponent.gameObject);
        }
    }
    
    private void AddPoint(CandyPointsComponent candyPointsComponent)
    {
        Debug.Log(candyPointsComponent.GetPoints());
    }
}
