using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Velocidade de movimento
    public float moveSpeed = 5f;

    // Altura do pulo
    public float jumpHeight = 2f;

    // Rotação do mouse
    public float mouseSensitivity = 3f;

    // Referência para a câmera
    public Camera playerCamera;

    // Rotação do personagem
    private float verticalRotation = 0f;

    // Componente CharacterController do personagem
    private CharacterController controller;

    // Gravidade aplicada ao personagem
    private float gravity = -9.81f;

    // Velocidade de queda do personagem
    private float verticalVelocity = 0f;

    private void Start()
    {
        // Obter o componente CharacterController
        controller = GetComponent<CharacterController>();

        // Desabilitar o cursor do mouse e travá-lo no centro da tela
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        // Capturar a entrada do mouse
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        // Rotação vertical do personagem (olhar para cima/baixo)
        verticalRotation -= mouseY;
        verticalRotation = Mathf.Clamp(verticalRotation, -90f, 90f);
        playerCamera.transform.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f);

        // Rotação horizontal do personagem (virar para os lados)
        transform.Rotate(Vector3.up * mouseX);

        // Movimento do personagem
        float moveX = Input.GetAxis("Horizontal") * moveSpeed;
        float moveZ = Input.GetAxis("Vertical") * moveSpeed;

        Vector3 moveDirection = transform.right * moveX + transform.forward * moveZ;

        // Aplicar gravidade
        verticalVelocity += gravity * Time.deltaTime;

        // Pulo
        if (controller.isGrounded && Input.GetButtonDown("Jump"))
        {
            verticalVelocity = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        moveDirection.y = verticalVelocity;

        controller.Move(moveDirection * Time.deltaTime);
    }
}
