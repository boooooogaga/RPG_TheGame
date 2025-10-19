using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
     private const float gravityScale = 9.8f,
                  speed = 8f,
                  turnSpeed = 90f;
    private float mouseX = 0f, VerticalSpeed = 0f;

    private CharacterController characterController;
    [SerializeField] Camera GoCamera;
    public Sword sword;

    private void CameraRotation()
    {
        mouseX = Input.GetAxis("Mouse X");
        transform.Rotate(new Vector3(0f, mouseX * turnSpeed * Time.deltaTime, 0f));
    }
    private void MoveCharacter()
    {
        Vector3 velocity = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        velocity = transform.TransformDirection(velocity) * speed; // ��������� �� ���������� ������ ��������� � ���������



        if (characterController.isGrounded) VerticalSpeed = 0f;
        else
        {
            VerticalSpeed -= gravityScale * Time.deltaTime;
            velocity.y = VerticalSpeed;
        }


        characterController.Move(velocity * Time.deltaTime);
    }
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        characterController = GetComponent<CharacterController>();
        
        
    }

    void Update()
    {
        CameraRotation();
        MoveCharacter();

        if (Input.GetMouseButtonDown(0))
        {
            sword.Attack();
        }
    }
}
