using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float smoothFactor = 0.5f;
    public bool lookAtTarget;
    public Vector3 offset;

    void Start()
    {
        offset = transform.position - target.transform.position;
    }

    private void LateUpdate() 
    {
       Vector3 newPosition = transform.position = target.position + offset;
       transform.position = Vector3.Slerp(transform.position, newPosition, smoothFactor);

       if(lookAtTarget)
       {
        transform.LookAt(target);
       }
    }
}
