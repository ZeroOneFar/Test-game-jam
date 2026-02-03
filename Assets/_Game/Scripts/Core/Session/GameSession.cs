using System;

public sealed class GameSession
{
    public bool HasActiveRun { get; private set; }
    public DateTime LastPausedUtc { get; private set; }

    public static GameSession LoadOrCreate()
    {
        return SessionPersistence.Load() ?? new GameSession();
    }

    public void StartRun()
    {
        HasActiveRun = true;
        SessionPersistence.Save(this);
    }

    public void MarkPaused()
    {
        LastPausedUtc = TimeProvider.UtcNow();
        SessionPersistence.Save(this);
    }

    public void Restore(bool hasActiveRun, DateTime lastPausedUtc)
    {
        HasActiveRun = hasActiveRun;
        LastPausedUtc = lastPausedUtc;
    }

    public void Clear()
    {
        HasActiveRun = false;
        SessionPersistence.Clear();
    }
}
