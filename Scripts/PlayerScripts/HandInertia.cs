using UnityEngine;

public class HandInertia : MonoBehaviour
{
    public Transform cameraTransform;

    [Header("Inertia settings")]
    public float positionStrength = 0.05f;
    public float rotationStrength = 2f;
    public float smooth = 8f;

    private Vector3 lastCamEuler;
    private Vector3 targetPos;
    private Quaternion targetRot;

    private Vector3 startLocalPos;
    private Quaternion startLocalRot;

    void Start()
    {
        startLocalPos = transform.localPosition;
        startLocalRot = transform.localRotation;
        lastCamEuler = cameraTransform.eulerAngles;
    }

    void Update()
    {
        Vector3 camDelta = cameraTransform.eulerAngles - lastCamEuler;

        // фиксим скачки 0 → 360
        camDelta.x = Mathf.DeltaAngle(0, camDelta.x);
        camDelta.y = Mathf.DeltaAngle(0, camDelta.y);

        // позиционная инерция
        targetPos = startLocalPos +
                    new Vector3(
                        -camDelta.y * positionStrength,
                        -camDelta.x * positionStrength,
                        0f
                    );

        // вращательная инерция
        targetRot = startLocalRot *
                    Quaternion.Euler(
                        camDelta.x * rotationStrength,
                        camDelta.y * rotationStrength,
                        0f
                    );

        transform.localPosition = Vector3.Lerp(
            transform.localPosition,
            targetPos,
            Time.deltaTime * smooth
        );

        transform.localRotation = Quaternion.Slerp(
            transform.localRotation,
            targetRot,
            Time.deltaTime * smooth
        );

        lastCamEuler = cameraTransform.eulerAngles;
    }
}