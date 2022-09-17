public class PhasesContext
{
    private PhaseState _state;
    private Spawner _spawner;
    private WaveCounter _waveCounter;

    public PhasesContext(Spawner spawner, WaveCounter waveCounter, PhaseState state = null)
    {
        _spawner = spawner;
        if (state == null)
        {
            _state = new Phase1(earlySpawn: true);
        }
        else
        {
            _state = state;
        }
        _state.SetContext(this);
        _waveCounter = waveCounter;
    }

    public WaveCounter WaveCounter { get { return _waveCounter; } }

    public void SpawnEnemies()
    {
        _spawner.SpawnEnemies(_state.EnemiesPerWave);
    }

    public void TransitionTo(PhaseState state)
    {
        _state = state;
        _state.SetContext(this);
        _spawner.SpawnEnemies(_state.EnemiesPerWave);
    }

    public int EnemiesPerWave => _state.EnemiesPerWave;
    public float TimeBetweenSpawns => _state.TimeBetweenSpawns;

    public void Countdown(float timeToSubstract)
    {
        this._state.Countdown(timeToSubstract);
    }

    public float TimeLeft { get { return _state.TimeLeft; } }

    public bool NoMorePhases { get { return _state.Next == null; } }

    public string PhaseName { get { return _state.GetType().Name; } }

    public bool OutOfTime { get { return _state.OutOfTime; } }
}
