using UnityEngine;

public static class ScorePersistence
{
    private const string LastScoreKey = "last_score";

    public static void Save(long score)
    {
        PlayerPrefs.SetString(LastScoreKey, score.ToString());
        PlayerPrefs.Save();
    }
}
