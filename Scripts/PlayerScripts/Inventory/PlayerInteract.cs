using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private float interactDistance;

    private IInteractable currentTarget;

    void LateUpdate()
    {
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f));

        if (Physics.Raycast(ray, out RaycastHit hit, interactDistance))
        {
            IInteractable interactable = hit.collider.GetComponentInParent<IInteractable>();

            if (interactable != currentTarget)
            {
                currentTarget?.OnUnfocus();
                currentTarget = interactable;
                currentTarget?.OnFocus();
            }

            if (Input.GetKeyDown(KeyCode.E) && currentTarget != null)
            { 
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
