using System;
using UnityEngine;

public static class SessionPersistence
{
    private const string HasActiveRunKey = "session_active";
    private const string LastPausedUtcKey = "session_last_paused";

    public static GameSession Load()
    {
        if (!PlayerPrefs.HasKey(HasActiveRunKey))
            return null;

        var hasActiveRun = PlayerPrefs.GetInt(HasActiveRunKey) == 1;

        DateTime lastPaused = DateTime.MinValue;
        if (PlayerPrefs.HasKey(LastPausedUtcKey))
        {
            var ticks = long.Parse(PlayerPrefs.GetString(LastPausedUtcKey));
            lastPaused = new DateTime(ticks, DateTimeKind.Utc);
        }

        var session = new GameSession();
        session.Restore(hasActiveRun, lastPaused);
        return session;
    }

    public static void Save(GameSession session)
    {
        PlayerPrefs.SetInt(HasActiveRunKey, session.HasActiveRun ? 1 : 0);
        PlayerPrefs.SetString(
            LastPausedUtcKey,
            session.LastPausedUtc.Ticks.ToString()
        );

        PlayerPrefs.Save();
    }

    public static void Clear()
    {
        PlayerPrefs.DeleteKey(HasActiveRunKey);
        PlayerPrefs.DeleteKey(LastPausedUtcKey);
        PlayerPrefs.Save();
    }
}
