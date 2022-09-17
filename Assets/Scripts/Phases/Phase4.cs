public class Phase4 : PhaseState
{
    public Phase4() : base(
        enemiesPerWave: Constants.Phases.Phase4.EnemiesPerWave,
        timeLeft: Constants.Phases.Phase4.TimeOfWave,
        timeBetweenSpawns: Constants.Phases.Phase4.TimeBetweenSpawns,
        next: new Phase5()) {}
}