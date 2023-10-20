using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
    Camera mainCamera;
 
    public Rigidbody rb;
    float stopVelocity = 0.2f;
    float shotPower;
    float maxPower = 100f;

    bool isAiming, isIdle, isShooting;

    private float holdDownStartTime, holdDownTime;

    Vector3? worldPoint;

    [SerializeField] Text shotText;

    private void Awake()
    {
        mainCamera = Camera.main;
        rb.maxAngularVelocity = 1000;
        isAiming = false;
    }

    private void Update()
    {
        if (rb.velocity.magnitude < stopVelocity)
        {
            ProcessAim();

            if (Input.GetMouseButtonDown(0))
            {
                if (isIdle)
                    isAiming = true;

                holdDownStartTime = Time.time;
            }

            if (Input.GetMouseButtonUp(0))
            {
                holdDownTime = Time.time - holdDownStartTime;
                isShooting = true;
            }
        }
    }

    private void FixedUpdate()
    {
        if (rb.velocity.magnitude < stopVelocity)
        {
            Stop();
        }

        if (isShooting)
        {
            Shoot(worldPoint.Value);
            isShooting = false;
        }
    }

    private void ProcessAim()
    {
        if (!isAiming && !isIdle) return;

        worldPoint = CastMouseClickRay();
        if (!worldPoint.HasValue) return;
    }

    private Vector3? CastMouseClickRay()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
            return hit.point;
        else return null;
    }

    private void Stop()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;

        isIdle = true;
    }

    private void Shoot(Vector3 point)
    {
        isAiming = false;
        Vector3 horizontalWorldPoint = new Vector3(point.x, transform.position.y, point.z);
        Vector3 direction = (horizontalWorldPoint - transform.position).normalized;

        float strength = Vector3.Distance(transform.position, horizontalWorldPoint);

        rb.AddForce(direction * strength * CalculateHoldDownForce(holdDownTime));
    }

    private float CalculateHoldDownForce(float holdTime)
    {
        float maxForceHoldDownTime = 2f;
        float holdTimeNormalized = Mathf.Clamp01(holdTime / maxForceHoldDownTime);
        shotPower = holdTimeNormalized * maxPower;
        shotText.text = "Shot Power: " + shotPower;
        return shotPower;
    }
}
