using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallRespawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] balls;
    private bool isBallActive;
    private float spawnTimer = 0;
    public float spawnFreq = 0;

     void Start()
     {
        isBallActive = false;
     }

    // Update is called once per frame
    void Update()
    {
        if (!isBallActive) {
            spawnTimer += Time.deltaTime;
            if (spawnTimer >= spawnFreq) {
                int ballIndex = Random.Range(0,balls.Length-1);
                BallComponent currentBall = Instantiate(balls[ballIndex], transform.position, Quaternion.identity, transform).GetComponent(typeof(BallComponent)) as BallComponent;
                currentBall.SetBallRespawner(this);
                isBallActive = true;
            }
        }
    }

    public void SetBallAsInActive()
    {
        isBallActive = false;
        spawnTimer = 0;
        spawnFreq = Random.Range(2,7);
    }
}
