using UnityEngine;

public class IncreaseFogOverTime : MonoBehaviour
{
    [Header("Fog Settings")]
    public float startDensity = 0.01f; // Initial fog density
    public float targetDensity = 0.04f; // Maximum fog density
    public float duration = 120.0f; // Time in seconds to reach target density

    private float elapsedTime = 0.0f;

    void Start()
    {
        // Enable fog and set the initial density
        RenderSettings.fog = true;
        RenderSettings.fogDensity = startDensity;
    }

    void Update()
    {
        if (elapsedTime < duration)
        {
            // Increment elapsed time
            elapsedTime += Time.deltaTime;

            // Calculate the new fog density
            float newDensity = Mathf.Lerp(startDensity, targetDensity, elapsedTime / duration);
            RenderSettings.fogDensity = newDensity;
        }
    }
}
