using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{ // Скорость затухания
    Vector3 originalPos;

    void Start()
    {
        originalPos = transform.localPosition;
    }

    public void CameraShake(float duration, float amount ,float decreaseFactor)
    {
        if (duration > 0)
        {
            transform.localPosition = originalPos + Random.insideUnitSphere * amount;
            duration -= Time.deltaTime * decreaseFactor;
        }
        else
        {
            duration = 0f;
            transform.localPosition = originalPos; // Возврат в исходную позицию
        }
    }
}
