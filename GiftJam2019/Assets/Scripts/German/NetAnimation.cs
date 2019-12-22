using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetAnimation : MonoBehaviour
{
    public Vector3 target;
    Vector3 originalPos;
    public float speedGo;
    public float speedBack;
    bool going = false;
    bool coming = false;

    public void Go(Vector3 t)
    {
        target = t;
        going = true;
        coming = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        originalPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (going)
        {
            if ((transform.position - target).sqrMagnitude < 0.01)
            {
                going = false;
                coming = true;
            }
            transform.position = Vector3.Lerp(transform.position, target, Time.deltaTime * speedGo);
        } else if (coming)
        {
            if ((transform.position - originalPos).sqrMagnitude < 0.01)
            {
                coming = false;
            }
            transform.position = Vector3.Lerp(transform.position, originalPos, Time.deltaTime * speedBack);

        }
    }
}
