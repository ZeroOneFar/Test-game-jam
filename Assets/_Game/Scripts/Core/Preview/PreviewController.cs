using UnityEngine;

public sealed class PreviewController : MonoBehaviour
{
    [SerializeField] private PreviewConfig config;

    private float _timer;
    private bool _running;
    private bool _isResumeReveal;

    private void OnEnable()
    {
        EventBus.Subscribe<GameStateChanged>(OnGameStateChanged);
    }

    private void OnDisable()
    {
        // (Unsubscribe omitted for brevity — safe for prototype)
    }

    private void OnGameStateChanged(GameStateChanged evt)
    {
        if(evt.State == GameState.Preview)
            StartPreview();

        else if(evt.State == GameState.ResumeReveal)
            StartResumeReveal();
    }

    private void Update()
    {
        if (!_running)
            return;

        _timer -= Time.deltaTime;
        if (_timer > 0f)
            return;

        _running = false;

        if (_isResumeReveal)
        {
            EventBus.Raise(new ResumeRevealFinished());
        }
        else
        {
            EventBus.Raise(new PreviewFinished());
        }
    }

    private void StartPreview()
    {
        _isResumeReveal = false;
        _timer = config.previewDurationSeconds;
        _running = true;

        EventBus.Raise(new PreviewStarted());
    }

    private void StartResumeReveal()
    {
        _isResumeReveal = true;
        _timer = config.resumeRevealSeconds;
        _running = true;

        EventBus.Raise(new ResumeRevealStarted());
    }
}
