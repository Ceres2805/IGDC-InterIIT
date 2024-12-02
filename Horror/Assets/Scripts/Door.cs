using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{    
    //Distance from which the player can interact with the door
    public float interactionDistance;

    //The text that appears
    public GameObject intText;

    //The names of the door open and door close animations
    public string doorOpenAnimName, doorCloseAnimName;

    //The door open and door close sounds
    public AudioClip doorOpen, doorClose;

    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);

        RaycastHit hit;

        //If the raycast hits something
        if(Physics.Raycast(ray, out hit, interactionDistance))
        {
            //If the object the raycast hits is tagged as door
            if (hit.collider.gameObject.tag == "door")
            {
                GameObject doorParent = hit.collider.gameObject;

                Animator doorAnim = doorParent.GetComponent<Animator>();

                AudioSource doorSound = hit.collider.gameObject.GetComponent<AudioSource>();

                //The interaction text is set active
                intText.SetActive(true);

                if (Input.GetKeyDown(KeyCode.E))
                {
                    //If the door's Animator's state is set to the open animation
                    if (doorAnim.GetCurrentAnimatorStateInfo(0).IsName(doorOpenAnimName))
                    {
                        //The doorSound's audio clip will change to the door close sound
                        doorSound.clip = doorClose;

                        //The door close sound will play
                        doorSound.Play();

                        //The door's open animation trigger is reset
                        doorAnim.ResetTrigger("open");

                        //The door's close animation trigger is set (it plays)
                        doorAnim.SetTrigger("close");
                    }
                    //If the door's Animator's state is set to the close animation
                    if (doorAnim.GetCurrentAnimatorStateInfo(0).IsName(doorCloseAnimName))
                    {
                        //The doorSound's audio clip will change to the door open sound
                        doorSound.clip = doorOpen;

                        //The door open sound will play
                        doorSound.Play();

                        //The door's close animation trigger is reset
                        doorAnim.ResetTrigger("close");

                        //The door's open animation trigger is set (it plays)
                        doorAnim.SetTrigger("open");
                    }
                }
            }
            //else, if not looking at the door
            else
            {
                //The interaction text is disabled
                intText.SetActive(false);
            }
        }
        //else, if not looking at anything
        else
        {
            //The interaction text is disabled
            intText.SetActive(false);
        }
    }
}