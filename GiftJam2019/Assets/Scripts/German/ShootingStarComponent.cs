using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingStarComponent : MonoBehaviour
{
    [SerializeField]
    private float xAxisSpeed;
    [SerializeField]
    private float yAxisSpeed;

    [SerializeField]
    private float timeToDestroy;

    bool dead = false;
    public void Start()
    {
        DestroyAfterTime();
    }
    public void Update()
    {
        Move();
    }

    public void TrapStar()
    {
        Destroy(gameObject, 1f);
        dead = true;
    }

    private void Move()
    {
        if (dead) return;
        transform.Translate(new Vector3(xAxisSpeed*Time.deltaTime, yAxisSpeed*Time.deltaTime,0));
    }
    
    private void DestroyAfterTime()
    {
        Destroy(gameObject,timeToDestroy);
    }
    public void SetSpeed(Vector2 v)
    {
        xAxisSpeed = v.x;
        yAxisSpeed = v.y;
    }
}
