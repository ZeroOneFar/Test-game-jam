public interface IMatchPairHandler
{
    bool IsMatch();

    void OnMatched();
    void OnMismached();

}
public sealed class MatchResolver
{
    public MatchResolver()
    {
        
    }

    public void OnResolve(IMatchPairHandler pairObj)
    {

        if (pairObj.IsMatch())
        {

            pairObj.OnMatched();
        }
        else
        {
            pairObj.OnMismached();
        }

    }
}
