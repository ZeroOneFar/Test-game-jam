public interface IMatchPairHandler
{
    public  CardModel A();
    public  CardModel B();

    void Matched();
    void MisMached();

}
public sealed class MatchResolver
{
    public MatchResolver()
    {
        
    }

    public void OnResolve(IMatchPairHandler pairObj)
    {

        if (pairObj.A().Id.Value == pairObj.B().Id.Value)
        {
            pairObj.A().MarkMatched();
            pairObj.B().MarkMatched();

            pairObj.Matched();
        }
        else
        {
            pairObj.MisMached();
        }

    }
}
