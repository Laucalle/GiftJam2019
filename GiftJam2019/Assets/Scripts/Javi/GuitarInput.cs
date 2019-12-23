using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuitarInput : MonoBehaviour
{
    [SerializeField]
    private KeyCode [] keySecuence;
    [SerializeField]
    private JaviManager javiManager;

    [SerializeField]
    private int pointsAdditionPerSecuence;

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
        javiManager.AddPoints(pointsAdditionPerSecuence);
    }
    private void Fail()
    {
        nextKeyIndexExpected = 0;
    }
}
