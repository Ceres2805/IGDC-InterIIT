using UnityEngine;

public class CandleShrink : MonoBehaviour
{
    public float shrinkRate = 0.1f;
    public float minHeight = 0.1f; 
    public bool isTriggered = false; 

    private Vector3 originalScale;

    void Start()
    {
        originalScale = transform.localScale;
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
    }
}
