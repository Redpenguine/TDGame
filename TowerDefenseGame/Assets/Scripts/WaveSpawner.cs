using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPreafab;

    public Transform spawnPoint;

    public Text waveCountdownText;

    public float timeBetweenWawes = 5.5f;
    private float coutdown = 2f;

    private int waveIndex = 1;

    void Update()
    {
        if(coutdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            coutdown = timeBetweenWawes;
            
        }
        coutdown -= Time.deltaTime;
        coutdown = Mathf.Clamp(coutdown, 0f, Mathf.Infinity);

        waveCountdownText.text = string.Format("{0:00.00}", coutdown);
        
        
    }

    IEnumerator SpawnWave()
    {
        for (int i = 0; i < waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
        }
        waveIndex++;
    }

    void SpawnEnemy()
    {
        Instantiate(enemyPreafab, spawnPoint.position, spawnPoint.rotation);
    }
}
