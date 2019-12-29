using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntonioCandyTouchDetector : MonoBehaviour
{
    public AntonioManager GM;
    public AudioSource AS;
    public AudioClip win_sfx;
    public AudioClip lose_sfx;

    private void OnTriggerEnter(Collider other)
    {
        CandyPointsComponent candyPointsComponent;
        candyPointsComponent = other.GetComponent(typeof(CandyPointsComponent)) as CandyPointsComponent;
        if (null != candyPointsComponent) {
            AS.clip = win_sfx;
            if (candyPointsComponent.GetPoints() < 0)
            {
                AS.clip = lose_sfx;
            }
            AS.Play();
            AddPoint(candyPointsComponent);
            Destroy(candyPointsComponent.gameObject);
        }
    }
    
    private void AddPoint(CandyPointsComponent candyPointsComponent)
    {
        GM.AddPoints(candyPointsComponent.GetPoints());
        Debug.Log("Catched sth");
    }
}
