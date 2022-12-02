using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.XR;

public class PlayerController : MonoBehaviourPunCallbacks
{
    public float speed = 10f;
    public Transform cameraTransform;

    void Start()
    {

    }

    void Update()
    {
        if (photonView.IsMine)
        {
            //this is local client
            Camera.main.transform.position = cameraTransform.position;
            Camera.main.transform.eulerAngles = cameraTransform.eulerAngles;

            float x = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
            float z = Input.GetAxis("Vertical") * speed * Time.deltaTime;
            transform.Translate(x, 0, z);
        }
    }


}
