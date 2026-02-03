using UnityEngine;
using UnityEngine.UI;

public sealed class HomeScreen : MonoBehaviour
{
    [SerializeField] private Button playButton;
    [SerializeField] private Button exitButton;

    private void Awake()
    {
        playButton.onClick.AddListener(OnPlay);
        exitButton.onClick.AddListener(OnExit);
    }

    private void OnPlay()
    {
        EventBus.Raise(new RequestPlay());
    }

    private void OnExit()
    {
        Application.Quit();
    }
}

public readonly struct RequestPlay { }
