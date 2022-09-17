public class Phase3 : PhaseState
{
    public Phase3() : base(
        enemiesPerWave: Constants.Phases.Phase3.EnemiesPerWave,
        timeLeft: Constants.Phases.Phase3.TimeOfWave,
        timeBetweenSpawns: Constants.Phases.Phase3.TimeBetweenSpawns,
        next: new Phase4()) {}
}