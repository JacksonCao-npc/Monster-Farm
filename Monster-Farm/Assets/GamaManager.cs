using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamaManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemy", 2f, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    float RandomX()
    {
        float x = Random.Range(-2, -15);
        return x;
    }

    float RandomY()
    {
        float y = Random.Range(-5, 7);
        return y;
    }

    Vector3 RandomSpawnPostion()
    {
        Vector3 spawnPostion = new Vector3(RandomX(), RandomY(), 0);
        return spawnPostion;
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab,RandomSpawnPostion(),enemyPrefab.transform.rotation);
    }


}
