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

    public static class Tags
    {
        public const string Unit = "Unit";
        public const string Respawn = "Respawn";
    }
}
