using UnityEngine;

public class PickupController : MonoBehaviour
{
    public float pickupRange = 2.5f;  // Maximum distance for pickup
    public Transform holdPosition;   // Position to hold the object
    private GameObject currentObject = null;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && currentObject == null)
        {
            TryPickup();
        }
        
        if (Input.GetKeyDown(KeyCode.R) && currentObject != null)
        {
            DropObject();
        }
    }

    void TryPickup()
    {
        Ray ray = new Ray(transform.position, transform.forward); // Cast ray forward from player
        if (Physics.Raycast(ray, out RaycastHit hit, pickupRange))
        {
            if (hit.collider.gameObject.CompareTag("Pickup"))
            {
                currentObject = hit.collider.gameObject;
                currentObject.GetComponent<Rigidbody>().isKinematic = true;  // Disable physics
                currentObject.transform.position = holdPosition.position;
                currentObject.transform.SetParent(holdPosition);  // Parent to player hold position
            }
        }
    }

    void DropObject()
    {
        currentObject.GetComponent<Rigidbody>().isKinematic = false;  // Re-enable physics
        currentObject.transform.SetParent(null);  // Unparent the object
        currentObject = null;
    }
}