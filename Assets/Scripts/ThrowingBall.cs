using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThrowingBall : MonoBehaviour
{
    [SerializeField] float addForce;
    [SerializeField] LineRenderer lineRenderer;
    Ray ray;
    RaycastHit raycastHit;
    Rigidbody _rigidbody;

    

    private void Start() {
        _rigidbody = GetComponent<Rigidbody>();
    }
    private void Update() {
        LinerendererCalculate();
        DragDrop();
    }
    void LinerendererCalculate()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out raycastHit, 100) && GameManager.Instance.isStart == true)
        {
            lineRenderer.enabled = true;
            lineRenderer.SetPosition(0, transform.position);
            raycastHit.point = new Vector3 (raycastHit.point.x, raycastHit.point.y, raycastHit.point.z);
            lineRenderer.SetPosition(1, raycastHit.point);
        }
        else
        {lineRenderer.enabled = false;}
        
    }
    void DragDrop()
    {
        if(Input.GetMouseButtonDown(1) && GameManager.Instance.isStart == true)
        {
            GameManager.Instance.ReplayButton();
            GameManager.Instance.isCamOn = true;
            //_rigidbody.isKinematic = false;
            _rigidbody.AddForce(ray.direction * addForce);
            GameManager.Instance.isStart = false;
        }
    }
}
