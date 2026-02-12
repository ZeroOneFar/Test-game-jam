using TMPro;
using UnityEngine;
using UnityEngine.UI;

public sealed class GridSelectToggle : MonoBehaviour
{
    [SerializeField] private CardGridConfig gridConfig;
    [SerializeField] private Toggle toggle;
    [SerializeField] private TextMeshProUGUI toggleText;

    private bool _initialized;
    private void Awake()
    {
        toggle.onValueChanged.AddListener(OnChanged);
    }

    private void OnEnable()
    {
        // Force initial selection event once
        if (!_initialized && toggle.isOn)
        {
            _initialized = true;
            EventBus.Raise(new GridSelected(gridConfig));
        }

        toggleText.text = $"{gridConfig.rows}x{gridConfig.columns}";
    }

    private void OnChanged(bool isOn)
    {
        if (!isOn)
            return;

        EventBus.Raise(new GridSelected(gridConfig));
    }
}

public readonly struct GridSelected
{
    public readonly CardGridConfig Config;
    public GridSelected(CardGridConfig config) => Config = config;
}
