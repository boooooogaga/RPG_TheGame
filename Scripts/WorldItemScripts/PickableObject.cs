using UnityEngine;
using static UnityEditor.Progress;

public class PickableObject : MonoBehaviour, IInteractable
{
    [SerializeField] private ItemData item;
    [SerializeField] private GameObject highlight;


    public void OnFocus()
    {
        if (highlight != null)
            highlight.SetActive(true);
    }

    public void OnUnfocus()
    {
        if (highlight != null)
            highlight.SetActive(false);
    }

    public void Interact(GameObject interactor)
    {
        Inventory inventory = interactor.GetComponent<Inventory>();
        if (inventory == null) return;
        Destroy(gameObject);
    }

    private void LateUpdate()
    {
        transform.forward = Camera.main.transform.forward;
    }

}
