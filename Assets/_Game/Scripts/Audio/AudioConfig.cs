using UnityEngine;

[CreateAssetMenu(
    fileName = "AudioConfig",
    menuName = "Game/Audio Config"
)]
public sealed class AudioConfig : ScriptableObject
{
    [Header("Clips")]
    public AudioClip flip;
    public AudioClip match;
    public AudioClip mismatch;
    public AudioClip gameOver;

    [Header("Volume")]
    [Range(0f, 1f)] public float flipVolume = 0.7f;
    [Range(0f, 1f)] public float matchVolume = 0.9f;
    [Range(0f, 1f)] public float mismatchVolume = 0.9f;
    [Range(0f, 1f)] public float gameOverVolume = 1.0f;
}
