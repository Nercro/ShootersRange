using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour {

    public float movementSpeed = 3.0f;
    public float gravity = -9.81f;

    private CharacterController _characterController;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();

    }

    private void Update()
    {
        Vector3 movementZ = Input.GetAxisRaw("Vertical") * Vector3.forward * movementSpeed * Time.deltaTime;
        Vector3 movementx = Input.GetAxisRaw("Horizontal") * Vector3.right * movementSpeed * Time.deltaTime;

        Vector3 movement = transform.InverseTransformDirection(movementZ + movementx);
        movement.y = gravity * Time.deltaTime;
        _characterController.Move(movement);

    }
}

