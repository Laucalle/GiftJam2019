using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            RaycastHit raycastHit;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray, out raycastHit)) {
                ShootingStarComponent shootingStarComponent = raycastHit.collider.GetComponent(typeof(ShootingStarComponent)) as ShootingStarComponent;
                if(null != shootingStarComponent ) {
                    shootingStarComponent.TrapStar();
                }
            }
        }
    }
}
