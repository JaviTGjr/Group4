using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class WaveSpawner : MonoBehaviour
{
    public Transform[] enemyPrefabs;

    public Transform spawnPoint;

    public float timeBetweenWaves = 10f;

    private float countdown = 10f;

    public Text waveCountdownText;

    private int waveNumber = 0;

    public Text currentWave;

     void Update()
    {
        if(countdown <= 0f)
        {
            
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }

        countdown -= Time.deltaTime;

        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

        waveCountdownText.text = string.Format("{0:00.0}", countdown);
    }

    IEnumerator SpawnWave()
    {
        waveNumber++;
        currentWave.text = PlayerStats.Rounds.ToString();
        PlayerStats.Rounds++;
        for (int i = 0; i < waveNumber*5; i++)
        {

            SpawnEnemy();
            yield return new WaitForSeconds(1f);

        }
    }
    
    void SpawnEnemy()
    {
        float offset = 1;
        Vector3 newSpawnPoint = new Vector3(spawnPoint.position.x + Random.Range(-offset, offset), spawnPoint.position.y + Random.Range(-offset, offset), spawnPoint.position.z + Random.Range(-offset, offset));
        Transform enemy = Instantiate(enemyPrefabs[Random.Range(0, 3)], spawnPoint.position, spawnPoint.rotation);
    }


}
