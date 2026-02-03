using System;

[Serializable]
public class GameSessionData
{
    public int currentGameScore;
    public int mismatchCount;

    // already exists:
    public float previewShowTime;
    public DateTime lastSavedUtc;
}
