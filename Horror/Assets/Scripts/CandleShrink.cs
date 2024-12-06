using UnityEngine;

public class CandleShrink : MonoBehaviour
{
    public float shrinkRate = 0.1f; 
    public float minHeight = 0.1f;
    public bool isTriggered = false;
    public GameObject candlePointLight; // Reference to the child point light object

    private Vector3 originalScale;
    private bool lightTurnedOff = false; // Track if the light is already off

    void Start()
    {
        originalScale = transform.localScale;

        // Find the candlePointLight if not assigned
        if (candlePointLight == null)
        {
            candlePointLight = transform.Find("Candle Point Light")?.gameObject;
        }
    }

    void Update()
    {
        if (isTriggered)
        {
            ShrinkCandle();
        }
    }

    private void ShrinkCandle()
    {
        if (transform.localScale.y > minHeight)
        {
            transform.localScale -= new Vector3(0, shrinkRate * Time.deltaTime, 0);
            if (transform.localScale.y < minHeight)
            {
                transform.localScale = new Vector3(originalScale.x, minHeight, originalScale.z);
            }
        }

        // Turn off the point light when the candle reaches the minimum height
        if (transform.localScale.y <= minHeight && !lightTurnedOff)
        {
            if (candlePointLight != null)
            {
                candlePointLight.SetActive(false); 
                Destroy(gameObject);
            }
            lightTurnedOff = true; // Prevent multiple calls
        }
    }

    public void OnPickup()
    {
        isTriggered = true; 
    }
}
