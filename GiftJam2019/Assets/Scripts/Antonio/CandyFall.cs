using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandyFall : MonoBehaviour
{
    [SerializeField]
    private float speed;
    // Update is called once per frame
    void Update()
    {
        transform.Translate(0,-1*(speed*Time.deltaTime),0);
    }
}
