using UnityEngine;

public sealed class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioConfig config;

    private void Awake()
    {
        var source = gameObject.AddComponent<AudioSource>();
        source.playOnAwake = false;

        var map = new AudioEventMap(config, source);
        map.Bind();
    }
}
