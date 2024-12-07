using UnityEngine;

public class GravityModifier : MonoBehaviour
{
  
    public float gravityScale = 0.5f; // Custom gravity value

    private Rigidbody rb;

    void Start()
    {
        // Get the Rigidbody component
        rb = GetComponent<Rigidbody>();

        if (rb == null)
        {
            Debug.LogWarning("No Rigidbody found on the object. Gravity cannot be modified.");
            return;
        }

        // Adjust the gravity scale
        rb.useGravity = false; // Disable default Unity gravity
    }

    void FixedUpdate()
    {
        if (rb != null)
        {
            // Apply custom gravity
            rb.AddForce(Physics.gravity * gravityScale, ForceMode.Acceleration);
        }
    }
}


