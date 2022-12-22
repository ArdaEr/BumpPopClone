using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

[RequireComponent(typeof(CinemachineVirtualCamera))]
public class CinemachineVirtualDynamic : MonoBehaviour
{
    
    [SerializeField] Transform _transformFinishLine;
    //[SerializeField] GameObject _player;
    private CinemachineVirtualCamera cinemachineVirtualCamera;
    Transform target;
   

    private void Start() {
        cinemachineVirtualCamera = GetComponent<CinemachineVirtualCamera>();
    
    }
    private void Update() {
        FindClosestBall();
        AimCamera();
    }

    void FindClosestBall()
    {
        Transform closestTarget = null;
        float maxDistance = Mathf.Infinity;

        foreach(var unit in GameManager.Instance.Units)
        {
            
            //float targetDistance = Vector3.Distance(transform.position, enemy.transform.position);
            Vector3 directionVector = _transformFinishLine.transform.position - unit.transform.position;
            float targetDistance = directionVector.sqrMagnitude;

            if(targetDistance < maxDistance)
            {
                //lookAtTarget = true;
                closestTarget = unit.transform;
                maxDistance = targetDistance;
            }

        }
            target = closestTarget;      
    }
    void AimCamera()
    {
        if(GameManager.Instance.isCamOn == true)
        {
        cinemachineVirtualCamera.Follow = target;
        cinemachineVirtualCamera.LookAt = target;
        }
    }
}
