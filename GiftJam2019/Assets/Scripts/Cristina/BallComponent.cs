using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallComponent : MonoBehaviour
{

    [SerializeField]
    int points;
    [SerializeField]
    BallRespawner ballRespawner = null;
    public int GetPoints()
    {
        return points;
    }

    public void SetBallRespawner(BallRespawner ballRespawner)
    {
        this.ballRespawner = ballRespawner;
    }

    public void Drop()
    {
        ballRespawner.SetBallAsInActive();
        Destroy(gameObject);
    }
}
