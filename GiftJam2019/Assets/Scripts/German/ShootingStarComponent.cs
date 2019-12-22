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
        Destroy(gameObject);
    }

    private void Move()
    {
        transform.Translate(new Vector3(xAxisSpeed*Time.deltaTime, yAxisSpeed*Time.deltaTime,0));
    }
    
    private void DestroyAfterTime()
    {
        Destroy(gameObject,timeToDestroy);
    }
}
