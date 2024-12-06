using UnityEngine;

public class Door2 : MonoBehaviour
{
  private PickupController pickupScript; // Reference to the PickupObject script
    public TMPro.TextMeshProUGUI interactionText; // UI text for door interaction prompts
    public Transform door; // Reference to the door Transform
    public Animator openanim;
    private Collider doorCollider; // Non-trigger collider for the door

    private bool isDoorUnlocked = false;
    private bool playerInRange = false;

    private void Start()
    {
        // Attempt to find the player and PickupObject script
        GameObject player = GameObject.FindWithTag("Player");
        interactionText.text = "";
        if (player != null)
        {
            pickupScript = player.GetComponent<PickupController>();
            if (pickupScript != null)
            {
                Debug.Log("PickupObject script found successfully.");
            }
            else
            {
                Debug.LogError("PickupObject script not found on the player object.");
            }
        }
        else
        {
            Debug.LogError("Player object not found! Ensure it is tagged as 'Player'.");
        }

        // Get the non-trigger collider
        doorCollider = GetComponent<Collider>();
        if (doorCollider == null)
        {
            Debug.LogError("Non-trigger collider not found on the door object.");
        }
    }

    private void Update()
    {
        if (pickupScript == null || isDoorUnlocked || !playerInRange) return;

        GameObject heldObject = pickupScript.heldObject;
        if (heldObject != null)
        {
            // Check if the held object has a child tagged "Key"
            Transform keyChild = heldObject.transform.Find("Key");
            if (keyChild != null && keyChild.CompareTag("Key"))
            {
                interactionText.text = "Press E to unlock door";
                interactionText.enabled = true;

                if (Input.GetKeyDown(KeyCode.E))
                {
                    UnlockAndOpenDoor();
                }
            }
            else
            {
                interactionText.enabled = false;
            }
        }
        else
        {
            interactionText.enabled = false;
        }
    }

    private void UnlockAndOpenDoor()
    {
        isDoorUnlocked = true;
        interactionText.enabled = false;

        // Example door opening logic
        Debug.Log("Door unlocked and opened!");
        openanim.SetTrigger("open");
        if (doorCollider != null)
        {
            doorCollider.enabled = false; // Disable the door's physical barrier
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            Debug.Log("Player is near the door.");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            Debug.Log("Player left the door area.");
            interactionText.enabled = false;
        }
    }
}