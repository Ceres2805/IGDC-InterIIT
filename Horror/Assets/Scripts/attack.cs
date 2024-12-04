using UnityEngine;

public class attack : MonoBehaviour
{
    public float speed = 5f; // Movement speed

    void Update()
    {
        // Move the GameObject in the negative Z direction (backward)
        MoveBackward();
    }

    void MoveBackward()
    {
        // Moves the GameObject in the negative Z direction (backward)
        Vector3 movement = Vector3.back * speed * Time.deltaTime;
        transform.Translate(movement, Space.World);
    }
}
