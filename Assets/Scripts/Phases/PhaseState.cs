using System;
using UnityEngine;

[Serializable]
public abstract class PhaseState
{
    protected PhasesContext _context;
    protected PhaseState _next;
    protected int _enemiesPerWave;
    [SerializeField]
    protected float _timeLeft;
    protected float _timeBetweenSpawns;
    private bool _spawned;
    private bool _earlySpawn;

    public PhaseState(
        int enemiesPerWave, float timeLeft, float timeBetweenSpawns, PhaseState next, bool earlySpawn = false)
    {
        _enemiesPerWave = enemiesPerWave;
        _timeLeft = timeLeft;
        _timeBetweenSpawns = timeBetweenSpawns;
        _next = next;
        _spawned = false;
        _earlySpawn = earlySpawn;
    }

    public bool EarlySpawn { get { return _earlySpawn; } }

    public void SetContext(PhasesContext context)
    {
        _context = context;
    }

    public virtual void Countdown(float timeToSubstract)
    {
        if (_earlySpawn && !_spawned)
        {
            _context.SpawnEnemies();
            _spawned = true;
        }

        _timeLeft -= timeToSubstract;
        
        if (OutOfTime)
        {
            _context.WaveCounter.WavesLeft--;
            if (_next != null)
            {
                _context.TransitionTo(this._next);
            }
        }
    }

    public bool OutOfTime { get { return _timeLeft <= 0; } }
    public float TimeLeft { get { return _timeLeft; } }

    public int EnemiesPerWave { get { return _enemiesPerWave; } }

    public float TimeBetweenSpawns { get { return _timeBetweenSpawns; } }

    public PhaseState Next { get { return _next; } }
}
