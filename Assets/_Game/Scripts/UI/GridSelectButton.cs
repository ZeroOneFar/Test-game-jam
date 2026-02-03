using UnityEngine;
using UnityEngine.UI;

public sealed class GridSelectButton : MonoBehaviour
{
    [SerializeField] private CardGridConfig gridConfig;
    [SerializeField] private Button button;

    private void Awake()
    {
        button.onClick.AddListener(() =>
            EventBus.Raise(new GridSelected(gridConfig)));
    }
}
public readonly struct GridSelected
{
    public readonly CardGridConfig Config;
    public GridSelected(CardGridConfig config) => Config = config;
}
