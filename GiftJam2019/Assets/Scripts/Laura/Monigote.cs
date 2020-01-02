using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monigote : MonoBehaviour
{

    private MonigoteRespawner enemyRespawner;
    [SerializeField]
    private Sprite sprite;
    private bool moving = false;
    [SerializeField]
    private GameObject monigoteDestiny;
    [SerializeField]
    private float speed;
    [SerializeField]
    private LauraGameManager gameManager;
    [SerializeField]
    private int points = 5;

    void Update()
    {
        if (moving) {
            float dirX = monigoteDestiny.transform.position.x - transform.position.x;
            float dirY = monigoteDestiny.transform.position.y - transform.position.y;
            transform.Translate(new Vector2(dirX,dirY)*Time.deltaTime*speed);
        }
    } 

    public void BulletImpact(ColorComponent bulletCollorComponent)
    {
        ColorComponent colorComponent = transform.GetComponent(typeof(ColorComponent)) as ColorComponent;
        if (null != colorComponent) {
            if (bulletCollorComponent.GetColorCode() == colorComponent.GetColorCode()) {
                enemyRespawner.SetEnemyAsInactive();
                ChangeToColoredSprite();
                moving = true;
                gameManager.AddPoints(points);
                Destroy(transform.gameObject,3);
            }
        }
    }

    public void SetEnemyRespawner(MonigoteRespawner enemyRespawner)
    {
        this.enemyRespawner = enemyRespawner;
    }

    private void DisableCollider()
    {
        Collider collider = transform.GetComponent(typeof(Collider)) as Collider;
        collider.enabled = false;
    }

    private void ChangeToColoredSprite()
    {
        SpriteRenderer renderer = transform.GetComponent(typeof(SpriteRenderer)) as SpriteRenderer;
        renderer.sprite = sprite;
    }
}
