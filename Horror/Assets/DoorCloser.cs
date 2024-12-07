using UnityEngine;

public class DoorCloser : MonoBehaviour
{
    public Animator animator; // Animator component
    public string openAnimationName = "open"; // Name of the open animation
    public string closeAnimationName = "close"; // Name of the close animation
    public float delayBeforeClose = 10.0f; // Delay in seconds

    private bool isOpenTriggered = false;
    private float timer = 0.0f;

    void Update()
    {
        // Check if the open animation was triggered
        if (isOpenTriggered)
        {
            // Increment timer
            timer += Time.deltaTime;

            // Trigger the close animation after the delay
            if (timer >= delayBeforeClose)
            {
                animator.Play(closeAnimationName);
                isOpenTriggered = false; // Reset trigger
            }
        }
    }

    public void TriggerOpen()
    {
        // Trigger the open animation
        animator.Play(openAnimationName);

        // Start the countdown for the close animation
        isOpenTriggered = true;
        timer = 0.0f; // Reset timer
    }
}
