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

    public Animator anim;
    public AudioSource AS;
    public AudioClip climb_sfx;

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
            anim.SetFloat("speed", 0);
            BeginClimbing();
        } else
        {
            anim.SetFloat("speed", 0);
        }
    }

    private void MoveLeft()
    {
        transform.Translate(new Vector3(-1*movementSpeed*Time.deltaTime,0,0));
        anim.SetFloat("speed", -1);
    }

    private void MoveRight()
    {
        transform.Translate(new Vector3(movementSpeed*Time.deltaTime,0,0));
        anim.SetFloat("speed", 1);
    }

    private void Climb()
    {
        if(null != currentClimbComponent && (transform.position != currentClimbComponent.GetClimbComponent().transform.position)) {
            transform.position = Vector3.MoveTowards(transform.position, currentClimbComponent.GetClimbComponent().transform.position, climbSpeed*Time.deltaTime);
        } else {
            isClimbing = false;
            anim.SetBool("climbing", isClimbing);
        }
    }

    private void BeginClimbing()
    {
        if(null != currentClimbComponent)
        {
            isClimbing = true;
            AS.clip = climb_sfx;
            AS.Play();
            anim.SetBool("climbing", isClimbing);
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

    private void OnTriggerStay(Collider otherCollider)
    {
        ClimbComponent climbComponent;
        climbComponent = otherCollider.GetComponent(typeof(ClimbComponent)) as ClimbComponent;
        if (null != climbComponent && !isClimbing) {
            currentClimbComponent = climbComponent;
            Debug.Log(this.currentClimbComponent);
        }
    }
}
