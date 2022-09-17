public class Phase5 : PhaseState
{
    public Phase5(bool earlySpawn = false) : base(
        enemiesPerWave: Constants.Phases.Phase5.EnemiesPerWave,
        timeLeft: Constants.Phases.Phase5.TimeOfWave,
        timeBetweenSpawns: Constants.Phases.Phase5.TimeBetweenSpawns,
        next: null,
        earlySpawn: earlySpawn) {}
}