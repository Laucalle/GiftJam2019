using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LauraGameManager : MiniGameManager
{
    void Start()
    {
        score.current_scene = SCENES.LAURA;
    }
    private void Update()
    {
        CheckTimer();
    }
}
