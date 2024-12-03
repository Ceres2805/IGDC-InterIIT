using UnityEngine;

public class ApplyForce : MonoBehaviour
{
     public float speed = 5f; // Movement speed

    void Update()
    {
        // Move the GameObject in the positive Z direction
        MoveForward();
    }

    void MoveForward()
    {
        Vector3 movement = Vector3.forward * speed * Time.deltaTime;
        transform.Translate(movement, Space.World);
    }
}

