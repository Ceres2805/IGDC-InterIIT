using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // For UI components

public class codedoor : MonoBehaviour
{
    public float interactionDistance = 3f;
    public GameObject intText; // Interaction text
    public GameObject passwordPanel; // UI panel containing the password input
    public InputField passwordInputField; // Input field for the password
    public string correctPassword = "1234"; // Password to unlock the door
    public string doorOpenAnimName, doorCloseAnimName;
    public AudioClip doorOpen, doorClose;

    private bool isDoorUnlocked = false; // Tracks if the door is unlocked
    private bool isPasswordPanelActive = false; // Tracks if the password panel is active

    private Animator doorAnim;
    private AudioSource doorSound;

    void Start()
    {
        passwordPanel.SetActive(false); // Hide the password panel initially
    }

    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactionDistance))
        {
            if (hit.collider.gameObject.tag == "codedoor")
            {
                doorAnim = hit.collider.gameObject.GetComponent<Animator>();
                doorSound = hit.collider.gameObject.GetComponent<AudioSource>();
                intText.SetActive(true);

                if (Input.GetKeyDown(KeyCode.E) && !isPasswordPanelActive)
                {
                    if (!isDoorUnlocked)
                    {
                        // Show the password input panel
                        passwordPanel.SetActive(true);
                        passwordInputField.text = "";
                        isPasswordPanelActive = true;
                    }
                    else
                    {
                        // Open or close the door if unlocked
                        ToggleDoorState();
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
    }

    public void SubmitPassword()
    {
        // Check if the entered password is correct
        if (passwordInputField.text == correctPassword)
        {
            isDoorUnlocked = true;
            passwordPanel.SetActive(false);
            isPasswordPanelActive = false;
            Debug.Log("Door Unlocked!");
        }
        else
        {
            Debug.Log("Incorrect Password!");
        }
    }

    public void CancelPassword()
    {
        // Hide the password panel without unlocking the door
        passwordPanel.SetActive(false);
        isPasswordPanelActive = false;
    }

    private void ToggleDoorState()
    {
        if (doorAnim.GetCurrentAnimatorStateInfo(0).IsName(doorOpenAnimName))
        {
            doorSound.clip = doorClose;
            doorSound.Play();
            doorAnim.ResetTrigger("open");
            doorAnim.SetTrigger("close");
        }
        else if (doorAnim.GetCurrentAnimatorStateInfo(0).IsName(doorCloseAnimName))
        {
            doorSound.clip = doorOpen;
            doorSound.Play();
            doorAnim.ResetTrigger("close");
            doorAnim.SetTrigger("open");
        }
    }
}
