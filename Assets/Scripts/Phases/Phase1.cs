public class Phase1 : PhaseState
{
    public Phase1(bool earlySpawn = true) : base(
        enemiesPerWave: Constants.Phases.Phase1.EnemiesPerWave,
        timeLeft: Constants.Phases.Phase1.TimeOfWave,
        timeBetweenSpawns: Constants.Phases.Phase1.TimeBetweenSpawns,
        next: new Phase2(), 
        earlySpawn: earlySpawn) {}
}
