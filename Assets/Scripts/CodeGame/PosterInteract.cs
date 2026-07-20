using UnityEngine;

public class PosterInteract : Interactable
{
    public GameObject posterPanel; // PosterPanel shu yerga biriktiriladi

    private void Start()
    {
        interactionName = "Afishani ko'rish";
    }

    public override void Interact()
    {
        posterPanel.SetActive(true);
        ObjectiveUIManager.Instance.HideInteraction();
    }
}
