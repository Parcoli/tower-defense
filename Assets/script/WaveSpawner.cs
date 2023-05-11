using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public static int _mobAlive = 0;

    public Wave[] waves;
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

        if(_mobAlive > 0)
        {
            return;
        }

        if(countdown <= 0f)
        {
            // Une coroutine s'apelle de cette manière
            // StartCoroutine(nomCoroutine);
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
            return;
        }

        countdown -= Time.deltaTime;
        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);
        waveCountDownTimer.text = string.Format("{0:00.00}",countdown);
    }
    // Une coroutine permet d'avoir un délai entre 2 apelles, besoin d'un retour
    IEnumerator SpawnWave()
    {

        PlayerStats.rounds++;

        Wave wave = waves[waveIndex];

        for (int i = 0; i < wave.count; i++)
        {
            SpawnMob(wave.mob);
            yield return new WaitForSeconds(1f/wave.rate);
        }

        waveIndex++;

        if(waveIndex == waves.Length)
        {
            Debug.Log("GG !");
            this.enabled = false;
        }
    }

    void SpawnMob(GameObject mob)
    {
        Instantiate(mob,spawnPoint.position,spawnPoint.rotation);
        _mobAlive++;
    }
}
