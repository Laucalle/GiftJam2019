using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintBallMovement : MonoBehaviour
{

    private bool isMoving = false;
    [SerializeField]
    public float speed;
    private Vector2 direction;

    // Update is called once per frame
    void Update()
    {
        if (isMoving) {
            transform.Translate(direction*speed*Time.deltaTime);
        }
    }

    public void StartMovingTowards(Vector2 direction)
    {
        isMoving = true;
        this.direction = direction;
        Destroy(transform.gameObject,7);
    }

    public void OnTriggerEnter(Collider otherCollider)
    {
        Monigote monigote = otherCollider.GetComponent(typeof(Monigote)) as Monigote;

        if (null != monigote) {
            ColorComponent bulletCollor = transform.GetComponent(typeof(ColorComponent)) as ColorComponent;
            if (null != bulletCollor) {
                monigote.BulletImpact(bulletCollor);
            }
        }
        Destroy(transform.gameObject,0);
    }
}
