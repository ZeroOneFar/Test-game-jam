using TMPro;
using UnityEngine;
using UnityEngine.UI;

public sealed class AddPlayerPanel : MonoBehaviour
{
    [SerializeField] private TMP_InputField nameInput;
    [SerializeField] private Button confirmButton;

    private void Awake()
    {
        confirmButton.onClick.AddListener(OnConfirm);
    }

    private void OnConfirm()
    {
        var name = nameInput.text.Trim();

        if (string.IsNullOrEmpty(name))
            return;

        EventBus.Raise(new PlayerAddConfirmed(name));
        nameInput.text = string.Empty;
        gameObject.SetActive(false);
    }
}

