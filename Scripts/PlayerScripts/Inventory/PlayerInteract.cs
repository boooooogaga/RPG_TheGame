using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private float interactDistance = 3f;

    private IInteractable currentTarget;

    void Update()
    {
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f));

        if (Physics.Raycast(ray, out RaycastHit hit, interactDistance))
        {
            IInteractable interactable = hit.collider.GetComponent<IInteractable>();

            if (interactable != currentTarget)
            {
                currentTarget?.OnUnfocus();
                currentTarget = interactable;
                currentTarget?.OnFocus();
            }

            if (Input.GetKeyDown(KeyCode.E) && currentTarget != null)
            {
                Inventory inventory = GetComponent<Inventory>();
                currentTarget.Interact(gameObject);
            }
        }
        else
        {
            currentTarget?.OnUnfocus();
            currentTarget = null;
        }
    }
}
