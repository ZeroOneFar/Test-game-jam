using UnityEngine;
using UnityEngine.EventSystems;

public sealed class CardView : MonoBehaviour, IPointerClickHandler
{
    public CardModel Model;

    public void OnPointerClick(PointerEventData eventData)
    {
        EventBus.Raise(new CardSelected(Model));
        EventBus.Raise(new PlayFlipSfx());
        EventBus.Raise(new CardSelected(Model));

    }
}
