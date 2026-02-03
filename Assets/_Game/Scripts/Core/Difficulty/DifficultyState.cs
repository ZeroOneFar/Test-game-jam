public sealed class DifficultyState
{
    public double CurrentPreviewTime { get; private set; } = 3.0;

    public void Reduce()
    {
        CurrentPreviewTime -= 0.025;
        if (CurrentPreviewTime < 0)
            CurrentPreviewTime = 0;
    }

    public void Restore(double value)
    {
        CurrentPreviewTime = value;
    }
}
