public class Phase2 : PhaseState
{
    public Phase2() : base(
        enemiesPerWave: Constants.Phases.Phase2.EnemiesPerWave,
        timeLeft: Constants.Phases.Phase2.TimeOfWave,
        timeBetweenSpawns: Constants.Phases.Phase2.TimeBetweenSpawns,
        next: new Phase3()) {}
}