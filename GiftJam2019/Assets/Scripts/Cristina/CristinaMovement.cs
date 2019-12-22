using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CristinaMovement : MonoBehaviour
{
    
    [SerializeField]
    private KeyCode moveLeftKey;
    
    [SerializeField]
    private KeyCode moveRightKey;

    [SerializeField]
    private KeyCode climbKey;

    [SerializeField]
    private float movementSpeed;

    [SerializeField]
    private float climbSpeed;

    private ClimbComponent currentClimbComponent;
    private bool isClimbing;

    void Start()
    {
        currentClimbComponent = null;
        isClimbing = false;
    }

    void Update()
    {
        if (isClimbing) {
            Climb();
        } else if (Input.GetKey(moveLeftKey)) {
            MoveLeft();
        } else if (Input.GetKey(moveRightKey)) {
            MoveRight();
        } else if(Input.GetKey(climbKey)) {
            BeginClimbing();
        }
    }

    private void MoveLeft()
    {
        transform.Translate(new Vector3(-1*movementSpeed*Time.deltaTime,0,0));
    }

    private void MoveRight()
    {
        transform.Translate(new Vector3(movementSpeed*Time.deltaTime,0,0));
    }

    private void Climb()
    {
        if(null != currentClimbComponent && (transform.position != currentClimbComponent.GetClimbComponent().transform.position)) {
            transform.position = Vector3.MoveTowards(transform.position, currentClimbComponent.GetClimbComponent().transform.position, climbSpeed*Time.deltaTime);
        } else {
            isClimbing = false;
        }
    }

    private void BeginClimbing()
    {
        if(null != currentClimbComponent)
        {
            isClimbing = true;
        }
    }

    private void OnTriggerEnter(Collider otherCollider)
    {
        ClimbComponent climbComponent;
        climbComponent = otherCollider.GetComponent(typeof(ClimbComponent)) as ClimbComponent;
        if (null != climbComponent && !isClimbing) {
            currentClimbComponent = climbComponent;
            Debug.Log(this.currentClimbComponent);
        }
    }

    private void OnTriggerExit(Collider otherCollider)
    {
        ClimbComponent climbComponent;
        climbComponent = otherCollider.GetComponent(typeof(ClimbComponent)) as ClimbComponent;
        if (null != climbComponent && !isClimbing) {
            currentClimbComponent = null;
            Debug.Log(this.currentClimbComponent);
        }
    }
}
