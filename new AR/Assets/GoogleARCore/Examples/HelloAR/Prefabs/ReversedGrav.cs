using UnityEngine;

public class ReversedGrav : MonoBehaviour
{
    public float thrust = -9.81f;
    public Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
		     rb.AddForce(-transform.up * thrust);
    }
}
