using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    #region Fields
    [SerializeField]
    private float verticalInputAcceleration = 1, horizontalInputAcceleration = 20;

    [SerializeField]
    private float maxSpeed = 10, maxRotationSpeed = 100;

    [SerializeField]
    private float velocityDrag = 1, rotationDrag = 1;

    private Vector3 velocity;
    private float rotationVelocity;
    private Rigidbody rb;
    #endregion

    #region Mono_Functions
    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        velocity = velocity * (1 - Time.deltaTime * velocityDrag);

        velocity = Vector3.ClampMagnitude(velocity, maxSpeed);

        rotationVelocity = rotationVelocity * (1 - Time.deltaTime * rotationDrag);

        rotationVelocity = Mathf.Clamp(rotationVelocity, -maxRotationSpeed, maxRotationSpeed);

        rb.position += velocity * Time.deltaTime;
        transform.Rotate(0, -rotationVelocity * Time.deltaTime, 0);
    }
    #endregion

    #region Public_Functions
    public void ChangeAcceleration(float speed)
    {
        Vector3 acceleration = speed * verticalInputAcceleration * transform.right;
        velocity += acceleration * Time.deltaTime;
    }

    public void ChangeRotation(float rotationSpeed)
    {
        float turnAcceleration = -1 * rotationSpeed * horizontalInputAcceleration;
        rotationVelocity += turnAcceleration * Time.deltaTime;
    }

    public void Strafe(int strafeDirection)
    {

    }
    #endregion

    #region Private_Functions
    #endregion
}
