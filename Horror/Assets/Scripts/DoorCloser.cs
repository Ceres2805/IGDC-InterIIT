using UnityEngine;

public class DoorCloser : MonoBehaviour
{
    public Animator animator; // Animator component
    public string openAnimationName = "open"; // Name of the open animation
    public string closeAnimationName = "close"; // Name of the close animation
    public float delayBeforeClose = 10.0f; // Delay in seconds

    private bool isTimerActive = false;
    private float timer = 0.0f;

    void Update()
    {
        if (isTimerActive)
        {
            // Increment the timer based on Time.deltaTime
            timer += Time.deltaTime;

            // Check if the delay has elapsed
            if (timer >= delayBeforeClose)
            {
                TriggerClose();
                isTimerActive = false; // Stop the timer
            }
        }
    }

    public void TriggerOpen()
    {
        if (animator == null)
        {
            Debug.LogError("Animator not assigned!");
            return;
        }

        // Trigger the open animation
        animator.Play(openAnimationName);
        Debug.Log("Open animation triggered.");

        // Start the timer for the close animation
        isTimerActive = true;
        timer = 0.0f; // Reset the timer
    }

    private void TriggerClose()
    {
        if (animator == null)
        {
            Debug.LogError("Animator not assigned!");
            return;
        }

        // Trigger the close animation
        animator.Play(closeAnimationName);
        Debug.Log("Close animation triggered.");
    }
}
