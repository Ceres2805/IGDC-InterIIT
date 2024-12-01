using UnityEngine;

public class Door : MonoBehaviour
{
    public float openDistance = 2f;    // How far the door should open
    public float doorSpeed = 2f;       // Speed at which the door opens and closes
    public KeyCode interactKey = KeyCode.F;  // Key to open/close the door

    private Vector3 closedPosition;    // Door's position when closed
    private Vector3 openPosition;      // Door's position when open
    private bool isOpening = false;    // Is the door currently opening?
    private bool isClosing = false;    // Is the door currently closing?

    private void Start()
    {
        closedPosition = transform.position;  // Initial position (closed)
        openPosition = transform.position + transform.right * openDistance;  // Open position (right direction)
    }

    private void Update()
    {
        // Check if the interact key is pressed
        if (Input.GetKeyDown(interactKey))
        {
            if (transform.position == closedPosition)
            {
                // Start opening the door
                isOpening = true;
                isClosing = false;
            }
            else if (transform.position == openPosition)
            {
                // Start closing the door
                isOpening = false;
                isClosing = true;
            }
        }

        // Handle the door's movement
        if (isOpening)
        {
            // Move the door towards the open position
            transform.position = Vector3.MoveTowards(transform.position, openPosition, doorSpeed * Time.deltaTime);
        }
        else if (isClosing)
        {
            // Move the door towards the closed position
            transform.position = Vector3.MoveTowards(transform.position, closedPosition, doorSpeed * Time.deltaTime);
        }
    }
}
