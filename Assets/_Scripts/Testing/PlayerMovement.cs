using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))] //using Player Input for movement control
//Actions = Default Controls
//Behaviour = Invoke Unity Events

public class PlayerMovement : MonoBehaviourPunCallbacks
{
    Vector3 moveVector;
    Vector3 rotateVector;

    public Transform cameraTransform;

    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float rotationSpeed = 100f;

    void Start()
    {

    }

    void FixedUpdate()
    {
        if (photonView.IsMine)
        {
            transform.Translate(moveVector * moveSpeed * Time.fixedDeltaTime);
            transform.Rotate(rotateVector * rotationSpeed * Time.fixedDeltaTime);
        }
    }

    private void LateUpdate()
    {
        if (photonView.IsMine)
        {
            Camera.main.transform.position = cameraTransform.position;
            Camera.main.transform.eulerAngles = cameraTransform.eulerAngles;
        }
    }

    //to be called in PlayerInput.Move
    public void OnRotationChanged(InputAction.CallbackContext context)
    {
        Vector2 direction = context.ReadValue<Vector2>();
        Debug.Log("direction: " + direction);
        rotateVector = new Vector3(0, direction.x, 0);
    }

    //to be called in PlayerInput.Rotate
    public void OnMovementChanged(InputAction.CallbackContext context)
    {
        Vector2 direction = context.ReadValue<Vector2>();
        moveVector = new Vector3(direction.x, 0, direction.y);
    }
}
