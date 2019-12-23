using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JaviManager : MiniGameManager
{
    // Start is called before the first frame update
    void Start()
    {
        score.current_scene = SCENES.ANTONIO;score.current_scene = SCENES.JAVI;
    }

    // Update is called once per frame
    void Update()
    {
        this.CheckTimer();
    }
}
