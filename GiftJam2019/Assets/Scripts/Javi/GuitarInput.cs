using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuitarInput : MonoBehaviour
{
    [SerializeField]
    private KeyCode [] keySecuence;
    private int nextKeyIndexExpected;

    void Start()
    {
        nextKeyIndexExpected = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown) {
            if (Input.GetKeyDown(keySecuence[nextKeyIndexExpected])) {
                nextKeyIndexExpected++;
                nextKeyIndexExpected = nextKeyIndexExpected % keySecuence.Length;

                if (nextKeyIndexExpected == 0) {
                    AddPoints();
                }
            } else {
                Fail();
            }
        }
        
    }

    private void AddPoints()
    {
        Debug.Log("asertaste wey");
    }
    private void Fail()
    {
        Debug.Log("FAIL");
        nextKeyIndexExpected = 0;
    }
}
