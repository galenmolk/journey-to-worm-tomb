using UnityEngine;

public class Car : MonoBehaviour
{
    public Rigidbody rb;
    public float driveSpeed = 5;
    public float turnSpeed = 5;

    private void Update()
    {
        if (Input.GetKey(KeyCode.W))
            rb.velocity = transform.forward * driveSpeed;

        if (Input.GetKey(KeyCode.A))
            transform.Rotate(Time.deltaTime * turnSpeed * -Vector3.up);

        if (Input.GetKey(KeyCode.D))
            transform.Rotate(Time.deltaTime * turnSpeed * Vector3.up);
    }
}