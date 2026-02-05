using UnityEngine;
using UnityEngine.EventSystems;

public sealed class CardView : MonoBehaviour, IPointerClickHandler
{
    public CardModel Model { get; private set; }

    [SerializeField] private SpriteRenderer front;
    [SerializeField] private SpriteRenderer back;

    private bool _isFaceUp;
    private bool _initialized;

    public void Init(CardModel model, Sprite frontSprite)
    {
        Model = model;
        front.sprite = frontSprite;
        SetFaceDown();
        _initialized = true;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("clicked on card");
        if (!_initialized || _isFaceUp)
            return;

        SetFaceUp();

        EventBus.Raise(new PlayFlipSfx());
        EventBus.Raise(new CardSelected(Model));
    }

    // ===== VISUAL STATE =====

    public void SetFaceUp()
    {
        Debug.Log("card face up" + gameObject.name);
        _isFaceUp = true;
        front.enabled = true;
        back.enabled = false;
    }

    public void SetFaceDown()
    {
        Debug.Log("card face down" + gameObject.name);
        _isFaceUp = false;
        front.enabled = false;
        back.enabled = true;
    }

    public void Remove()
    {
        gameObject.SetActive(false);
    }
}

