using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockAvatarPosition : MonoBehaviour
{
    public GameObject target;

    void Update()
    {
        if (target != null)
        {
            target.transform.position = new Vector3(transform.position.x, target.transform.position.y, transform.position.z);
            target.transform.eulerAngles = new Vector3(target.transform.eulerAngles.x, transform.eulerAngles.y, target.transform.eulerAngles.z);
        }
    }
}
