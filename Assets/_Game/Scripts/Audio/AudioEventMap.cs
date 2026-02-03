using UnityEngine;

public sealed class AudioEventMap
{
    private readonly AudioConfig _config;
    private readonly AudioSource _source;

    public AudioEventMap(AudioConfig config, AudioSource source)
    {
        _config = config;
        _source = source;
    }

    public void Bind()
    {
        EventBus.Subscribe<PlayFlipSfx>(_ =>
            _source.PlayOneShot(_config.flip, _config.flipVolume));

        EventBus.Subscribe<PlayMatchSfx>(_ =>
            _source.PlayOneShot(_config.match, _config.matchVolume));

        EventBus.Subscribe<PlayMismatchSfx>(_ =>
            _source.PlayOneShot(_config.mismatch, _config.mismatchVolume));

        EventBus.Subscribe<PlayGameOverSfx>(_ =>
            _source.PlayOneShot(_config.gameOver, _config.gameOverVolume));
    }
}
