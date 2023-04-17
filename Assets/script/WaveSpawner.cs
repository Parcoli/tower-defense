using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField]
    private Transform mobPrefab;
    [SerializeField]
    private Transform spawnPoint;
    [SerializeField]
    private float timeBetweenWaves = 5f;

    private float countdown = 2f;

    private int waveIndex = 0;

    // Update is called once per frame
    void Update()
    {
        if(countdown <= 0f)
        {
            // Une coroutine s'apelle de cette mani�re
            // StartCoroutine(nomCoroutine);
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }

        countdown -= Time.deltaTime;
    }
    // Une coroutine permet d'avoir un d�lai entre 2 apelles, besoin d'un retour
    IEnumerator SpawnWave()
    {
        waveIndex++;

        for (int i = 0; i < waveIndex; i++)
        {
            SpawnMob();
            yield return new WaitForSeconds(0.5f);
        }

        
    }

    void SpawnMob()
    {
        Instantiate(mobPrefab,spawnPoint.position   ,spawnPoint.rotation);
    }
}
