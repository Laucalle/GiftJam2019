using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GermanManager : MiniGameManager
{
    public GameObject shootingStar;
    public Vector2 min_spawn;
    public Vector2 max_spawn;
    public float spawn_freq;
    float spawn_timer = 0;

    public float min_speed = 4;
    public float max_speed = 6;

    // Start is called before the first frame update
    void Start()
    {
        score.current_scene = SCENES.GERMAN;
    }

    // Update is called once per frame
    void Update()
    {
        this.CheckTimer();
        if (IsRunning())
        {
            spawn_timer += Time.deltaTime;
            if (spawn_timer >= spawn_freq)
            {
                float x = Random.Range(min_spawn.x, max_spawn.x);
                float y = Random.Range(min_spawn.y, max_spawn.y);

                int i = Random.Range(0, 4);
                Vector3 t = Vector3.zero;
                switch (i)
                {
                    case 0:
                        t = new Vector3(min_spawn.x, y, 0);
                        break;
                    case 1:
                        t = new Vector3(max_spawn.x, y, 0);
                        break;
                    case 2:
                        t = new Vector3(x, min_spawn.y, 0);
                        break;
                    case 3:
                        t = new Vector3(x, max_spawn.y, 0);
                        break;
                }
                ShootingStarComponent star = Instantiate(shootingStar, t, Quaternion.identity, transform).GetComponent<ShootingStarComponent>();
                Vector2 dif = new Vector2(Random.Range(min_spawn.x, max_spawn.x) - t.x, Random.Range(min_spawn.y, max_spawn.y) - t.y);
                star.SetSpeed(dif.normalized * Random.Range(min_speed, max_speed));
                spawn_timer = 0;
            }
        }
    }
}
