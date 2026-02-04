using TMPro;
using UnityEngine;
using UnityEngine.UI;

public sealed class PlayerButton : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI label;
    [SerializeField] private Button button;

    private PlayerProfile _player;

    public void Bind(PlayerProfile player)
    {
        _player = player;
        label.text = player.Name;

        button.onClick.AddListener(() =>
        {
            EventBus.Raise(new PlayerSelected(player));            
        });
    }
}
