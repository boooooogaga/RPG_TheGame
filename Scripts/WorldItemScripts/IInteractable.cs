using UnityEngine;

public interface IInteractable
{
    void OnFocus();
    void OnUnfocus();
    void Interact(GameObject interactor);
}
