using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("General Wave Attributes")]
    public static Transform[] SpawnPoints;
    public GameObject[] Enemies;
    public Transform target;
    public ProgressBar progressBar;

    [SerializeField]
    private WaveCounter _waveCounter;
    [SerializeField]
    private string _currentPhaseName; // This is just to monitor it from the inspector
    private PhasesContext _phasesContext;

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
        _waveCounter = new WaveCounter();
        _phasesContext = new PhasesContext(this, _waveCounter);
        progressBar.Maximum = _phasesContext.TimeLeft;
    }

    private void Update()
    {
        _currentPhaseName = _phasesContext.PhaseName;
        if (_phasesContext.NoMorePhases && _phasesContext.OutOfTime)
        {
            _phasesContext = new PhasesContext(this, _waveCounter, new Phase5(earlySpawn: true));
        }

        if(_waveCounter.WavesLeft > 0)
        {
            _phasesContext.Countdown(Time.deltaTime);
            progressBar.Current = _phasesContext.TimeLeft;
        }
    }

    public void SpawnEnemies(int enemies)
    {
        StartCoroutine(SpawnEnemiesCorutine(enemies));
    }

    IEnumerator SpawnEnemiesCorutine(int enemies)
    {
        if(_phasesContext == null)
        {
            yield break;
        }

        for(int i = 0; i < enemies; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(_phasesContext.TimeBetweenSpawns);
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
