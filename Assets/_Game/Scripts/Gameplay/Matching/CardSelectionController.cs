using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class CardSelectionController : MonoBehaviour
{
    private CardView _first;
    private readonly HashSet<CardView> _inFlight = new();
    private readonly Queue<(CardView, CardView)> _queue = new();
    private bool _resolving;
    private MatchResolver _resolver;

    private void Awake()
    {
        _resolver = new MatchResolver();
    }


    private void OnEnable()
    {
        EventBus.Subscribe<CardClicked>(OnClicked);
        EventBus.Subscribe<OutsideClicked>(_ => CancelSelection());
        EventBus.Subscribe<CardsMatched>(e => OnPairResolved(e.A,e.B));
        EventBus.Subscribe<CardsMismatched>(e => OnPairResolved(e.A,e.B));
    }

    private void OnClicked(CardClicked e)
    {
        // cannot select inflight card
        if (_inFlight.Contains(e.Card))
        {
            CancelSelection();
            return;
        }

        // first card
        if (_first == null)
        {
            _first = e.Card;
            return;
        }

        // clicking same card twice cancels
        if (_first == e.Card)
        {
            CancelSelection();
            return;
        }

        // second card → VALID PAIR
        EnqueuePair(_first, e.Card);
        _first = null;
    }

    private void EnqueuePair(CardView a, CardView b)
    {
        _inFlight.Add(a);
        _inFlight.Add(b);

        _queue.Enqueue((a, b));

        if (!_resolving)
            StartCoroutine(ProcessQueue());
    }

    private IEnumerator ProcessQueue()
    {
        _resolving = true;

        while (_queue.Count > 0)
        {
            var (a, b) = _queue.Dequeue();

            yield return new WaitForSeconds(0.25f); // let visuals settle

            _resolver.OnResolve(new ResolverHandler(a,b));
        }

        _resolving = false;
    }

    private void CancelSelection()
    {
        if (_first == null)
            return;

        _first.SetFaceDown();
        _first = null;
    }

    private void OnPairResolved(CardView a, CardView b)
    {
        Debug.Log("cards resolved: " + a.name + " ," + b.name);
        _inFlight.Remove(a);
        _inFlight.Remove(b);
    }

    internal class ResolverHandler : IMatchPairHandler
    {
        private CardView a;
        private CardView b;


        internal ResolverHandler(CardView A, CardView B)
        {
            a = A;
            b = B;
        }

        public CardModel A() => a.Model;
        public CardModel B() => b.Model;

        public void Matched()
        {
            EventBus.Raise( new CardsMatched(a,b));
            EventBus.Raise(new PlayMatchSfx());
        }

        public void MisMached()
        {
            EventBus.Raise( new CardsMismatched(a,b));
            EventBus.Raise(new PlayMismatchSfx());
        }
    }
}




public struct OutsideClicked{}
