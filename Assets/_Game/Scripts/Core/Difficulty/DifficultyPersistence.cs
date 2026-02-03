using UnityEngine;

public static class DifficultyPersistence
{
    private const string PreviewTimeKey = "difficulty_preview_time";

    public static void Load(DifficultyState state)
    {
        if (!PlayerPrefs.HasKey(PreviewTimeKey))
            return;

        var value = PlayerPrefs.GetFloat(PreviewTimeKey);
        state.Restore(value);
    }

    public static void Save(DifficultyState state)
    {
        PlayerPrefs.SetFloat(
            PreviewTimeKey,
            (float)state.CurrentPreviewTime
        );
        PlayerPrefs.Save();
    }

    public static void Clear()
    {
        PlayerPrefs.DeleteKey(PreviewTimeKey);
        PlayerPrefs.Save();
    }
}
