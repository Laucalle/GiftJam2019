using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallComponent : MonoBehaviour
{

    [SerializeField]
    int points;
    [SerializeField]
    BallRespawner ballRespawner = null;

    public AnimationCurve fall_x;
    public AnimationCurve fall_y;
    bool dead = false;
    float time_from_death = 0f;
    Vector3 originalPos;

    private void Update()
    {
        if (dead)
        {
            time_from_death += Time.deltaTime;
            transform.position = originalPos + new Vector3(fall_x.Evaluate(time_from_death*0.1f/0.3f), fall_y.Evaluate(time_from_death*0.1f/0.3f), 0);
        }
    }

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
        dead = true;
        originalPos = transform.position;
        Destroy(gameObject, 2f);
    }
}
