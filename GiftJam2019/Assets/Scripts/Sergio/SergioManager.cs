using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SergioManager : MiniGameManager
{
    public Transform beerSpawnTransform;
    public GameObject beerPrefab;
    public float beerSpeed;
    public LayerMask beerLayer;

    public Vector2 spawnFreqRange;
    float spawntimer;
    float selected_time;

    public GameObject character;
    public float inputReload;
    float reloadTimer;

    public AudioClip win;
    public AudioClip lose;

    // Start is called before the first frame update
    void Start()
    {
        score.current_scene = SCENES.SERGIO;
        spawntimer = 0;
        reloadTimer = 0;
        selected_time = Random.Range(spawnFreqRange.x, spawnFreqRange.y);
    }

    // Update is called once per frame
    void Update()
    {
        this.CheckTimer();
        if (!IsRunning()) return;
        CheckSpawner();

        reloadTimer += Time.deltaTime;
        if (reloadTimer >= inputReload && Input.GetKeyDown(KeyCode.Space))
        {
            reloadTimer = 0;
            Collider[] hitColliders = Physics.OverlapSphere(character.transform.position, .5f);
            if (hitColliders.Length>0)
            {
                Destroy(hitColliders[0].transform.gameObject);
                AddPoints(10);
                character.GetComponent<Animator>().SetTrigger("catch");
                character.GetComponent<AudioSource>().clip = win;
                character.GetComponent<AudioSource>().Play();
                // trigger drinking animation and sound
            }
            else
            {
                character.GetComponent<Animator>().SetTrigger("miss");
                character.GetComponent<AudioSource>().clip = lose;
                character.GetComponent<AudioSource>().Play();
            }// else trigger empy hand
        }
    }

    void CheckSpawner()
    {
        spawntimer += Time.deltaTime;
        if (spawntimer >= selected_time)
        {
            spawntimer = 0;
            selected_time = Random.Range(spawnFreqRange.x, spawnFreqRange.y);
            var beer = Instantiate(beerPrefab, beerSpawnTransform);
            beer.GetComponent<BeerComponent>().SetSpeed(beerSpeed);
        }
    }
}
