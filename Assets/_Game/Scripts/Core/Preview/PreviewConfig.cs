using UnityEngine;

[CreateAssetMenu(
    fileName = "PreviewConfig",
    menuName = "Game/Preview Config"
)]
public sealed class PreviewConfig : ScriptableObject
{
    [Min(0f)]
    public float previewDurationSeconds = 3.0f;

    [Min(0f)]
    public float resumeRevealSeconds = 1.0f;
}
