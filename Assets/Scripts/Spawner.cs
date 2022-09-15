using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("General Wave Attributes")]
    public static Transform[] SpawnPoints;
    public GameObject[] Enemies;
    public Transform target;
    public ProgressBar progressBar;

    [Header("Wave Customization")]
    private int waveIndex;
    public int waveLimit;
    public float timer;
    public float timeOfWaves;
    public int enemiesPerWave;

    [Header("Wave internal Attributes")]
    public WavePhase wavePhase;

    private void Awake()
    {
        SpawnPoints = new Transform[transform.childCount];

        for(int i = 0; i < SpawnPoints.Length; i++)
        {
            SpawnPoints[i] = transform.GetChild(i);
        }
    }

    private void Start()
    {
        waveIndex = 0;
        wavePhase = WavePhase.PHASE_1;
        waveLimit = 25;
        timer = 2.5f;
        timeOfWaves = 6.5f;
        enemiesPerWave = 5;
    }

    private void Update()
    {
        if(waveIndex != waveLimit)
        {
            if(timer <= 0.0f)
            {
                StartCoroutine(WavePhaseState());
                timer = timeOfWaves;
            }
        }

        timer -= Time.deltaTime;
        progressBar.current = timer;
    }

    IEnumerator WavePhaseState()
    {
        waveIndex++;
        switch (wavePhase)
        {
            case WavePhase.PHASE_1:
                wavePhase = WavePhase.PHASE_2;
                break;
            case WavePhase.PHASE_2:
                enemiesPerWave += 2;
                wavePhase = WavePhase.PHASE_3;
                break;
            case WavePhase.PHASE_3:
                enemiesPerWave += 2;
                wavePhase = WavePhase.PHASE_4;
                break;
            case WavePhase.PHASE_4:
                enemiesPerWave += 2;
                wavePhase = WavePhase.PHASE_5;
                break;
            case WavePhase.PHASE_5:
                enemiesPerWave += 2;
                break;
            default:
                waveIndex--;
                break;
        }

        for(int i = 0; i < enemiesPerWave; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(1f);
        }
    }

    private void SpawnEnemy()
    {
        int randomEnemyIndex = Random.Range(0, Enemies.Length);
        int randomPointIndex = Random.Range(0, SpawnPoints.Length);
        Enemies[randomEnemyIndex].GetComponent<Unit>().target = target;
        Instantiate(Enemies[randomEnemyIndex], SpawnPoints[randomPointIndex].position, Quaternion.identity);
    } 
}
