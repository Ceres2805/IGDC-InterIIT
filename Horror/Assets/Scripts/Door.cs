using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public float interactionDistance;
    public GameObject intText;
    public string doorOpenAnimName, doorCloseAnimName;
    public AudioClip doorOpen, doorClose;
    public Transform holdPosition;   // Position to hold the object
    private GameObject currentObject = null;
    public GameObject intText2;
    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactionDistance))
        {
            if (hit.collider.gameObject.tag == "door")
            {
                GameObject doorParent = hit.collider.gameObject;
                Animator doorAnim = doorParent.GetComponent<Animator>();
                AudioSource doorSound = hit.collider.gameObject.GetComponent<AudioSource>();
                intText.SetActive(true);

                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (doorAnim.GetCurrentAnimatorStateInfo(0).IsName(doorOpenAnimName))
                    {
                        doorSound.clip = doorClose;
                        doorSound.Play();
                        doorAnim.ResetTrigger("open");
                        doorAnim.SetTrigger("close");
                    }

                    if (doorAnim.GetCurrentAnimatorStateInfo(0).IsName(doorCloseAnimName))
                    {
                        doorSound.clip = doorOpen;
                        doorSound.Play();
                        doorAnim.ResetTrigger("close");
                        doorAnim.SetTrigger("open");
                    }
                }
            }

            else if (hit.collider.gameObject.tag == "Pickup")
            {
                intText2.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E) && currentObject == null)
                {
                    currentObject = hit.collider.gameObject;
                    currentObject.GetComponent<Rigidbody>().isKinematic = true;  // Disable physics
                    currentObject.transform.position = holdPosition.position;
                    currentObject.transform.SetParent(holdPosition);  // Parent to player hold position
                }
            }

            else if (hit.collider.gameObject.tag == "Diary")
            {
                intText2.SetActive(true);
                BookInteraction bookInteraction = hit.collider.gameObject.GetComponent<BookInteraction>();
                if (Input.GetKeyDown(KeyCode.E) && bookInteraction != null)
                {
                    bookInteraction.isPlayerNearby = true;
                }
            }

            else
            {
                intText.SetActive(false);
                intText2.SetActive(false);
            }
        }
        else
        {
            intText.SetActive(false);
            intText2.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.R) && currentObject != null)
        {
            DropObject();
        }
    }
    void DropObject()
    {
        currentObject.GetComponent<Rigidbody>().isKinematic = false;  // Re-enable physics
        currentObject.transform.SetParent(null);  // Unparent the object
        currentObject = null;
    }
}