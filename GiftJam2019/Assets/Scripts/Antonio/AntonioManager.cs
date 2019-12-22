using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntonioManager : MiniGameManager
{

    public Transform max_spawn;
    public Transform min_spawn;
    public GameObject[] candy;
    public float spawn_freq;
    float spawn_timer = 0;

    private void Start()
    {
        score.current_scene = SCENES.ANTONIO;
    }
    // Update is called once per frame
    void Update()
    {
        this.CheckTimer();
        if (IsRunning())
        {
            spawn_timer += Time.deltaTime;
            if(spawn_timer >= spawn_freq)
            {
                int i = Random.Range(0,candy.Length);
                Vector3 t = new Vector3(Random.Range(min_spawn.position.x,max_spawn.position.x),min_spawn.position.y ,0);
                Instantiate(candy[i], t, Quaternion.identity, transform);
                spawn_timer = 0;
            }
        }
        //spawn cosas
    }
}
