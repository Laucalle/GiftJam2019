using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeerComponent : MonoBehaviour
{
    public float timeToDestroy;
    float speed;
    public void SetSpeed(float speed_value)
    {
        speed = speed_value;
    }
    private void Start()
    {
        Destroy(gameObject, timeToDestroy);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(speed*Time.deltaTime,0,0));
    }
}
