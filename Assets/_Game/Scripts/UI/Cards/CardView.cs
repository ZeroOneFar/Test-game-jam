using UnityEngine;
using UnityEngine.EventSystems;

public sealed class CardView : MonoBehaviour, IPointerClickHandler
{
    public CardModel Model;

    [SerializeField] private SpriteRenderer front;

    public void SetSprite(Sprite sprite)
    {
        front.sprite = sprite;
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        EventBus.Raise(new PlayFlipSfx());
        EventBus.Raise(new CardSelected(Model));
    }
}
