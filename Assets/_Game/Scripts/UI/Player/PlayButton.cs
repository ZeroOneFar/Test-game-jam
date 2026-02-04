using UnityEngine;
using UnityEngine.UI;

public sealed class PlayButton : MonoBehaviour
{
    [SerializeField] private Button button;

    void Awake()
    {
        button.onClick.AddListener(() =>
        {
            EventBus.Raise(new PlayerAddConfirmed());
        });
    }

}
