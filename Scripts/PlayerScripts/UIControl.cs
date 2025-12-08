using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIControl : MonoBehaviour
{
    [SerializeField] public Image Compass;
    private void Update()
    {
        float playerY = transform.eulerAngles.y;
        Compass.transform.rotation = Quaternion.Euler(0f, 0f, -playerY);
    }
}
