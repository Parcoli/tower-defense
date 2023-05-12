using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public static int _mobAlive = 0;

    public Wave wave;
    [SerializeField]
    private Transform spawnPoint;
    [SerializeField]
    private float timeBetweenWaves = 5f;
    [SerializeField]
    private Text waveCountDownTimer;

    private float countdown = 5f;

    private int MobsNumber = 0;

    void Update()
    {

        if(_mobAlive > 0)
        {
            return;
        }

        if(countdown <= 0f)
        {
            // Une coroutine s'apelle de cette mani�re
            // StartCoroutine(nomCoroutine);
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
            return;
        }

        countdown -= Time.deltaTime;
        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);
        waveCountDownTimer.text = string.Format("{0:00.00}",countdown);
    }
    // Une coroutine permet d'avoir un d�lai entre 2 apelles, besoin d'un retour
    IEnumerator SpawnWave()
    {

        PlayerStats.rounds++;
        _mobAlive = PlayerStats.rounds;


        for (int i = 0; i < PlayerStats.rounds; i++)
        {
            int generate = Random.Range(0, 20);

            if (generate >= 10)
            { 
                SpawnMob(wave.mobNormal); 
            }
            else if (generate >= 7)
            {
                SpawnMob(wave.mobSlow);
            }
            else
            {
                SpawnMob(wave.mobFast);
            }

            yield return new WaitForSeconds(1f/wave.rate);
        }

    }

    void SpawnMob(GameObject mob)
    {
        Instantiate(mob,spawnPoint.position,spawnPoint.rotation);
    }
}
