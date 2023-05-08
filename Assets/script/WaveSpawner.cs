using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField]
    private Transform mobPrefab;
    [SerializeField]
    private Transform spawnPoint;
    [SerializeField]
    private float timeBetweenWaves = 5f;
    [SerializeField]
    private Text waveCountDownTimer;

    private float countdown = 5f;

    private int waveIndex = 0;

    // Update is called once per frame
    void Update()
    {
        if(countdown <= 0f)
        {
            // Une coroutine s'apelle de cette manière
            // StartCoroutine(nomCoroutine);
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }

        countdown -= Time.deltaTime;
        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);
        waveCountDownTimer.text = string.Format("{0:00.00}",countdown);
    }
    // Une coroutine permet d'avoir un délai entre 2 apelles, besoin d'un retour
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
        Instantiate(mobPrefab,spawnPoint.position,spawnPoint.rotation);
    }
}
