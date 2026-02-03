using UnityEngine;

public sealed class CardVisibilityController : MonoBehaviour
{
    private void OnEnable()
    {
        EventBus.Subscribe<PreviewStarted>(_ => RevealAll());
        EventBus.Subscribe<PreviewFinished>(_ => HideAll());

        EventBus.Subscribe<ResumeRevealStarted>(_ => RevealAll());
        EventBus.Subscribe<ResumeRevealFinished>(_ => HideAll());
    }

    private void RevealAll()
    {
        // Placeholder — real card logic comes in STEP 5
        Debug.Log("Reveal all remaining cards");
    }

    private void HideAll()
    {
        Debug.Log("Hide all cards");
    }
}
