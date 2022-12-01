using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))] //using Player Input for movement control
public class PlayerMovement : MonoBehaviour
{
    CharacterController character;
    Vector3 moveVector;
    Vector3 rotateVector;

    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float rotationSpeed = 60f;

    void Start()
    {
        character = GetComponent<CharacterController>();
    }

    void FixedUpdate()
    {
        transform.Translate(moveVector * moveSpeed * Time.fixedDeltaTime);
        transform.Rotate(rotateVector * rotationSpeed * Time.fixedDeltaTime);
    }

    //to be called in PlayerInput.Move
    public void OnRotationChanged(InputAction.CallbackContext context)
    {
        Vector2 direction = context.ReadValue<Vector2>();
        Debug.Log("direction: " + direction);
        rotateVector = new Vector3(0, direction.y, 0);
    }

    //to be called in PlayerInput.Rotate
    public void OnMovementChanged(InputAction.CallbackContext context)
    {
        Vector2 direction = context.ReadValue<Vector2>();
        moveVector = new Vector3(direction.x, 0, direction.y);
    }
}
