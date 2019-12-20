using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntonioMovement : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed;
    [SerializeField]
    private KeyCode left;
    [SerializeField]
    private KeyCode right;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(left)) {
            transform.Translate(-1*(movementSpeed*Time.deltaTime),0,0);
        } else if(Input.GetKey(right)){
            transform.Translate((movementSpeed*Time.deltaTime),0,0);
        } 
    }
}
