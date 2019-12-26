using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrstinaDropBall : MonoBehaviour
{
    

    [SerializeField]
    private KeyCode dropBallKey;
    private BallComponent currentBall;
    [SerializeField]
    private CristinaGameManager cristinaGameManager;

    void Start()
    {
        currentBall = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(dropBallKey) && null != currentBall) {
            currentBall.Drop();
            cristinaGameManager.AddPoints(currentBall.GetPoints());
        }
    }

    private void OnTriggerEnter(Collider otherColliedr)
    {
        BallComponent currentBall = otherColliedr.GetComponent(typeof(BallComponent)) as BallComponent;
        if (null != currentBall) {
            this.currentBall = currentBall;
            Debug.Log("tengo una bola");
        }
    }

    private void OnTriggerExit(Collider otherColliedr)
    {
        BallComponent currentBall = otherColliedr.GetComponent(typeof(BallComponent)) as BallComponent;
        if (null != currentBall) {
            this.currentBall = null;
        }
    }
}
