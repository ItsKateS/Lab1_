using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineForce : MonoBehaviour
{
    public Camera mainCamera;
    public LayerMask ground;
    
    LineRenderer lineRenderer;

    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    private void LateUpdate()
    {
        RaycastHit hit;
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, transform.position);

        if (Physics.Raycast(ray, out hit, 1000, ground))
        {
            Vector3 point = hit.point;
            point.y = transform.position.y;

            Vector3 directon = (point - transform.position).normalized;
            directon *= 2;

            lineRenderer.SetPosition(1, (transform.position + directon));
        }
    }
}
