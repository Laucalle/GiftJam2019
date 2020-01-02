using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonigoteRespawner : MonoBehaviour
{
    [SerializeField]
    private Monigote[] enemies;
    private bool isEnemyActive;
    private float spawnTimer;
    public float spawnFreq = 3;
    //public AudioSource win;
    // Start is called before the first frame update
    void Start()
    {
       isEnemyActive = false; 
       spawnTimer = Random.Range(0,2.0f*spawnFreq);
    }

    // Update is called once per frame
    void Update()
    {
        if (!isEnemyActive) {
            spawnTimer += Time.deltaTime;
            if (spawnTimer >= spawnFreq+Random.Range(0,3.0f)) {
                int ballIndex = Random.Range(0,enemies.Length);
                Monigote enemy = Instantiate(enemies[ballIndex], transform.position, Quaternion.identity, transform).GetComponent(typeof(Monigote)) as Monigote;
                enemy.SetEnemyRespawner(this);
                isEnemyActive = true;
            }
        }
    }

    public void SetEnemyAsInactive() 
    {
        isEnemyActive = false;
        spawnTimer = 0;
    }
}
