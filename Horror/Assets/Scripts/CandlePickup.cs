using UnityEngine;
using TMPro;

public class CandlePickup : MonoBehaviour
{
    public float pickupRange = 3f; // Maximum distance to pick up an object
    public float sphereRadius = 0.5f; // Radius of the sphere for the SphereCast
    public Transform holdPosition; // Position to hold the picked-up object
    public TextMeshProUGUI interactText; // TextMeshPro UI text for interaction
    private GameObject heldObject; // Currently held object
    private Rigidbody heldObjectRigidbody;

    private GameObject currentDiary; // Reference to the current diary object
    private Canvas activeDiaryCanvas; // Currently active diary canvas

    void Start()
    {
        // Ensure the interact text is initially hidden
        interactText.gameObject.SetActive(false);
    }

    void Update()
    {
        if (heldObject == null && activeDiaryCanvas == null)
        {
            CheckForInteractableObject();
        }
        else
        {
            ClearInteraction();
        }

        if (Input.GetKeyDown(KeyCode.E)) // Press 'E' to interact
        {
            if (heldObject == null && activeDiaryCanvas == null)
            {
                TryInteractWithObject();
            }
        }
        else if (Input.GetKeyDown(KeyCode.R)) // Drop object with 'R'
        {
            if (heldObject != null)
            {
                DropObject();
            }
        }
        else if (Input.GetMouseButtonDown(1)) // Close diary with right mouse button
        {
            CloseDiary();
        }
    }

    void CheckForInteractableObject()
    {
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        RaycastHit hit;

        if (Physics.SphereCast(ray, sphereRadius, out hit, pickupRange))
        {
            if (hit.collider.CompareTag("Candle"))
            {
                // Show interaction text for pickup objects
                interactText.gameObject.SetActive(true);
                interactText.text = "Press E to Interact";

                // Update text position to follow the object in world space
                interactText.transform.position = Camera.main.WorldToScreenPoint(hit.collider.transform.position);
            }
            
            else
            {
                // Hide text if not looking at an interactable object
                ClearInteraction();
            }
        }
        else
        {
            // Hide text if not looking at an interactable object
            ClearInteraction();
        }
    }

    void TryInteractWithObject()
    {
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        RaycastHit hit;

        if (Physics.SphereCast(ray, sphereRadius, out hit, pickupRange))
        {
            if (hit.collider.CompareTag("Candle"))
            {
                PickupObject(hit.collider.gameObject);
            }
        }
    }

    void PickupObject(GameObject obj)
    {
        heldObject = obj;
        heldObjectRigidbody = obj.GetComponent<Rigidbody>();

        if (heldObjectRigidbody != null)
        {
            heldObjectRigidbody.isKinematic = true; // Disable physics
        }

        obj.transform.position = holdPosition.position; // Move to hold position
        obj.transform.parent = holdPosition; // Parent to hold position

        // Notify the CandleShrink script if the object is a candle
        CandleShrink candleShrink = obj.GetComponent<CandleShrink>();
        if (candleShrink != null)
        {
            candleShrink.OnPickup();
        }

        interactText.gameObject.SetActive(false); // Hide interaction text
    }

    void ClearInteraction()
    {
        interactText.gameObject.SetActive(false);
    }
}