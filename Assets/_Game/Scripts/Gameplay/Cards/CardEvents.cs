public readonly struct CardClicked
{
    public readonly CardView Card;
    public CardClicked(CardView card) => Card = card;
}

public readonly struct CardsMatched
{
    public readonly CardView A;
    public readonly CardView B;

    public CardsMatched(CardView a, CardView b)
    {
        A = a;
        B = b;
    }
}

public readonly struct CardsMismatched
{
        public readonly CardView A;
    public readonly CardView B;

    public CardsMismatched(CardView a, CardView b)
    {
        A = a;
        B = b;
    }
}
