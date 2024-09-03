using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingMovement : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 45f;
    [SerializeField] private Transform rotateAround;

    private bool isClockwise = true;

    void Update()
    {
        HandleRotation();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            ToggleRotationDirection();
        }
    }

    private void HandleRotation()
    {
        float currentRotationSpeed = isClockwise ? rotationSpeed : -rotationSpeed;

        RotateSelf(currentRotationSpeed);

        if (rotateAround != null)
        {
            RotateAroundPoint(currentRotationSpeed);
        }
    }

    private void RotateSelf(float speed)
    {
        this.transform.Rotate(Vector3.forward, speed * Time.deltaTime);
    }

    private void RotateAroundPoint(float speed)
    {
        this.transform.RotateAround(rotateAround.position, Vector3.forward, speed * Time.deltaTime);
    }

    private void ToggleRotationDirection()
    {
        isClockwise = !isClockwise;
    }
}

