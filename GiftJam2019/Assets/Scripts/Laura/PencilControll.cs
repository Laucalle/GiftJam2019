using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PencilControll : MonoBehaviour
{

    [SerializeField]
    private float movementSpeed;
    [SerializeField]
    private KeyCode leftMovementKey;
    [SerializeField]
    private KeyCode rightMovementKey;

    [SerializeField]
    private KeyCode shootKey;

    [SerializeField]
    private GameObject[] templateBullet;

    [SerializeField]
    private GameObject pointOfPencil; 
    private float timeToShoot = 0;
    [SerializeField]
    private float timeBetweenShoot;

    private int selectedColor = 0; 

    [SerializeField]
    private KeyCode changeColorKey;

    [SerializeField]
    private Sprite[] pencilsSprites;

    void Update()
    {
        if (Input.GetKey(leftMovementKey) && (transform.eulerAngles.z >= 270 || transform.eulerAngles.z <= 90)) {
            MoveLeft();
        } else if(Input.GetKey(rightMovementKey) && (transform.eulerAngles.z >= 270 || transform.eulerAngles.z <= 90)) {
            MoveRight();
        } else if (Input.GetKeyDown(shootKey) && timeToShoot < 0) {
            Shoot();
        } else if (Input.GetKeyDown(changeColorKey)) {
            ChangeColorKey();
        }

        timeToShoot -= Time.deltaTime;
    }

    private void MoveLeft()
    {
        transform.Rotate(new Vector3(0, 0, movementSpeed*Time.deltaTime));
        if (transform.eulerAngles.z > 90 && transform.eulerAngles.z < 270) {
            transform.eulerAngles = new Vector3(0,0,90);
        }
    }

    private void MoveRight()
    {
        transform.Rotate(new Vector3(0, 0, -1*movementSpeed*Time.deltaTime));
        if (transform.eulerAngles.z < 270 && transform.eulerAngles.z > 90) {
            transform.eulerAngles = new Vector3(0,0,270);
        }
    }

    private void Shoot()
    {
        PaintBallMovement bullet = Instantiate(this.templateBullet[selectedColor], pointOfPencil.transform.position, transform.rotation, null).GetComponent(typeof(PaintBallMovement)) as PaintBallMovement;

        if (null != bullet) {
            Vector2 direction = new Vector2(0,1);
            bullet.StartMovingTowards(direction);
            timeToShoot = timeBetweenShoot;
        }
    }

    private void ChangeColorKey()
    {
        selectedColor = (1 + selectedColor)%templateBullet.Length;
        SpriteRenderer renderer = transform.GetComponent(typeof(SpriteRenderer)) as SpriteRenderer;
        renderer.sprite = pencilsSprites[selectedColor];
    }
}
