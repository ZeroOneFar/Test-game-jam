using UnityEngine;
using UnityEngine.UI;

public sealed class GameOverScreen : MonoBehaviour
{
    [SerializeField] private Button continueButton;

    private void Awake()
    {
        continueButton.onClick.AddListener(OnContinue);
    }

    private void OnContinue()
    {
        EventBus.Raise(new GameOverAcknowledged());
    }
}
public readonly struct GameOverAcknowledged { }
