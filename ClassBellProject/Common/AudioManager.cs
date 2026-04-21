namespace ClassBellProject.Common
{
    public static class AudioManager
    {
        // SemaphoreSlim(1, 1) înseamnă că o singură "persoană" poate trece prin poartă deodată.
        public static readonly SemaphoreSlim AudioLock = new SemaphoreSlim(1, 1);
    }
}
