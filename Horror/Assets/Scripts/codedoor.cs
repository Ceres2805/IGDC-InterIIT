using UnityEngine;
using UnityEngine.UI;

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
        LockCursor(); // Ensure the cursor starts locked
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
                        // Show the password input panel and unlock cursor
                        passwordPanel.SetActive(true);
                        UnlockCursor();
                        passwordInputField.ActivateInputField(); // Focus the input field
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

        // Close the password panel with Escape
        if (isPasswordPanelActive && Input.GetKeyDown(KeyCode.Escape))
        {
            CancelPassword();
        }
    }

    public void SubmitPassword()
    {
        // Check if the entered password is correct
        if (passwordInputField.text == correctPassword)
        {
            isDoorUnlocked = true;
            Debug.Log("Door Unlocked!");
            ClosePasswordPanel();
        }
        else
        {
            Debug.Log("Incorrect Password!");
        }
    }

    public void CancelPassword()
    {
        ClosePasswordPanel(); // Close without unlocking
    }

    private void ClosePasswordPanel()
    {
        passwordPanel.SetActive(false);
        isPasswordPanelActive = false;
        LockCursor();
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

    private void UnlockCursor()
    {
        Cursor.lockState = CursorLockMode.None; // Unlock the cursor
        Cursor.visible = true; // Make the cursor visible
    }

    private void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked; // Lock the cursor
        Cursor.visible = false; // Hide the cursor
    }
}
