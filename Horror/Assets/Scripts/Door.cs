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
    public GameObject intText3;
    public GameObject info1;

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

           

            else
            {
                intText.SetActive(false);
            }
        }
        else
        {
            intText.SetActive(false);
           
        }

        if (Input.GetKeyDown(KeyCode.R) && currentObject != null)
        {
            DropObject();
            info1.SetActive(false);
        }
    }
    void DropObject()
    {
        currentObject.GetComponent<Rigidbody>().isKinematic = false;  // Re-enable physics
        currentObject.transform.SetParent(null);  // Unparent the object
        currentObject = null;
    }
}