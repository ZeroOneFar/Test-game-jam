using System;
using System.Collections.Generic;
using UnityEngine;

public sealed class CardVisibilityController : MonoBehaviour
{
    private readonly List<CardView> _cards = new();
    private void OnEnable()
    {
        EventBus.Subscribe<CardSpawnFinishedFromPreviw>(_ => RevealAll());

        EventBus.Subscribe<ResumeRevealStarted>(_ => RevealAll());

        EventBus.Subscribe<PreviewFinished>(_ => HideAll());

        EventBus.Subscribe<CardsMatched>(OnCardsMatched);
        EventBus.Subscribe<CardsMismatched>(OnCardMismatched);
    }

    private void OnCardMismatched(CardsMismatched e)
    {
        e.A.View.SetFaceDown();
        e.B.View.SetFaceDown();
    }

    public void Register(CardView view)
    {
        if (!_cards.Contains(view))
            _cards.Add(view);
    }

    
    public void Clear()
    {
        _cards.Clear();
    }

    private void RevealAll()
    {
        // Placeholder — real card logic comes in STEP 5
        Debug.Log("Reveal all remaining cards");
        Debug.Log("[CardVisibilityController] Reveal all cards");
        Debug.Log("cards count: "+ _cards.Count);
        foreach (var card in _cards)
        {
            card.SetFaceUp();
        }
    }

    private void HideAll()
    {
        Debug.Log("Hide all cards");
        foreach (var card in _cards)
            card.SetFaceDown();
    }
    private void OnCardsMatched(CardsMatched e)
    {
        // matched cards should not be flipped again

        e.A.View.Remove();
        e.B.View.Remove();
        _cards.Remove(e.A.View);
        _cards.Remove(e.B.View);
    }
}
