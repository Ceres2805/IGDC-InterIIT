using UnityEngine;

public class FlickerLight : MonoBehaviour
{
    public Light flickerLight;
    public float minIntensity = 0.5f;
    public float maxIntensity = 2f;
    public float flickerSpeed = 0.1f;

    private void Start()
    {
        if (flickerLight == null)
        {
            flickerLight = GetComponent<Light>();
        }
    }

    private void Update()
    {
        flickerLight.intensity = Mathf.Lerp(minIntensity, maxIntensity, Mathf.PerlinNoise(Time.time * flickerSpeed, 0.0f));
    }
}
