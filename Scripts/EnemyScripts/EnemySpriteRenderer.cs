using UnityEngine;

public class EnemySpriteRenderer : MonoBehaviour
{
    [Header("References")]
    public Transform spriteObject;          // Дочерний объект со спрайтом
    public SpriteRenderer spriteRenderer;   // SpriteRenderer внутри spriteObject

    [Header("Directional Sprites (4 directions)")]
    public Sprite front;
    public Sprite back;
    public Sprite left;
    public Sprite right;

    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;

        spriteRenderer = spriteObject.GetComponent<SpriteRenderer>();
    }

    void LateUpdate()
    {
        if (mainCamera == null) return;

        RotateToCamera();
        UpdateSpriteDirection();
    }

    void RotateToCamera()
    {
        Vector3 direction = spriteObject.position - mainCamera.transform.position;
        direction.y = 0f;

        spriteObject.rotation = Quaternion.LookRotation(direction);
    }

    void UpdateSpriteDirection()
    {
        Vector3 toCamera = (mainCamera.transform.position - transform.position).normalized;
        toCamera.y = 0f;

        float angle = Vector3.SignedAngle(
            transform.forward,
            toCamera,
            Vector3.up
        );

            // 4 направления
            if (angle > -45f && angle <= 45f)
            {
                spriteRenderer.sprite = front;
            }
            else if (angle > 45f && angle <= 135f)
            {
                spriteRenderer.sprite = right;
            }
            else if (angle <= -45f && angle > -135f)
            {
                spriteRenderer.sprite = left;
            }
            else
            {
                spriteRenderer.sprite = back;
            }
        
    }
}
