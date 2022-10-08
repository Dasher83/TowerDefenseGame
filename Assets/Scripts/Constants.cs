public static class Constants
{
    public static class Turret
    {
        public const float BabyMinimumSafeDistance = 0.35f;
        public const float InnerRingGizmoRadio = 0.25f;

        public const float UpdateTargetRate = 0.1f;

        public const int InitialTotalLives = 5;
    }

    public static class Unit
    {
        public const float MinimumSafeDistance = 1.5f;
    }

    public static class Bullet
    {
        public const float TimeOut = 5f;
    }

    public static class SpawnPoint
    {
        public const float OffSet = 1.5f;
    }

    public static class Waves
    {
        public const int WaveLimit = 10;
    }

    public static class Phases
    {
        public static class Phase1
        {
            public const int EnemiesPerWave = 5;
            public const float TimeOfWave = 6.5f;
            public const float TimeBetweenSpawns = 1f;
        }

        public static class Phase2
        {
            public const int EnemiesPerWave = 7;
            public const float TimeOfWave = 6.5f;
            public const float TimeBetweenSpawns = 1f;
        }

        public static class Phase3
        {
            public const int EnemiesPerWave = 9;
            public const float TimeOfWave = 6.5f;
            public const float TimeBetweenSpawns = 1f;
        }

        public static class Phase4
        {
            public const int EnemiesPerWave = 11;
            public const float TimeOfWave = 6.5f;
            public const float TimeBetweenSpawns = 1f;
        }

        public static class Phase5
        {
            public const int EnemiesPerWave = 13;
            public const float TimeOfWave = 6.5f;
            public const float TimeBetweenSpawns = 1f;
        }
    }

    public static class HealthBar
    {
        public const float DefaultMaximum = 5f;
        public const float Minimum = 0f;
    }

    public static class Tags
    {
        public const string Unit = "Unit";
        public const string Respawn = "Respawn";
        public const string Player = "Player";
        public const string Wallet = "Wallet";
    }

    public static class LevelManager
    {
        public const float InitialIndependentShotDamage = 1f;
        public const int InitialCriticalFactor = 12;
        public const float CriticalDamageMultiplierMinimum = 1.5f;
        public const float CriticalDamageMultiplierMaximum = 2.5f;
        public const float InitialBulletDamage = 1f;
    }
}
