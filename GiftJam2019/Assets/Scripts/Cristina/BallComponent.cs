using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallComponent : MonoBehaviour
{
    public void Drop()
    {
        Destroy(gameObject);
    }
}
