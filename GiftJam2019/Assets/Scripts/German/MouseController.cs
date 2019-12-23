using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    public NetAnimation net;
    public GermanManager GM;
    public int pointsPerStart;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(mousePosition.x, mousePosition.y, transform.position.z);
        if (Input.GetMouseButtonDown(0)) {
            net.Go(transform.position);
            RaycastHit raycastHit;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray, out raycastHit)) {
                ShootingStarComponent shootingStarComponent = raycastHit.collider.GetComponent(typeof(ShootingStarComponent)) as ShootingStarComponent;
                if(null != shootingStarComponent ) {
                    shootingStarComponent.TrapStar();
                    GM.AddPoints(pointsPerStart);
                }
            }
        }
    }
}
