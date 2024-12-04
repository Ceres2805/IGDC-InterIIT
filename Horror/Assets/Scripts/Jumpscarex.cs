using UnityEngine;
using System.Collections;

public class Jumpscarex : MonoBehaviour
{
    public GameObject jumpscareObject;
    public float wait = 3.0f;
    public float flickerDuration = 0.1f; 
    private Renderer[] jumpscareRenderers;

    void Start () {
        jumpscareObject.SetActive(false);

        jumpscareRenderers = jumpscareObject.GetComponentsInChildren<Renderer>();
    }
    
    void OnTriggerEnter (Collider player) {
        if (player.CompareTag("Player")) {
            jumpscareObject.SetActive(true);
            StartCoroutine(FlickerAndDestroy());
        }        
    }

    IEnumerator FlickerAndDestroy() {
        float elapsedTime = 0f;

        while (elapsedTime < wait) {
            foreach (Renderer renderer in jumpscareRenderers) {
                renderer.enabled = !renderer.enabled;
            }
            
            yield return new WaitForSeconds(flickerDuration);
            elapsedTime += flickerDuration;
        }

        foreach (Renderer renderer in jumpscareRenderers) {
            renderer.enabled = true;
        }

        yield return new WaitForSeconds(wait - elapsedTime);

        Destroy(jumpscareObject);
        Destroy(gameObject);
    }
}
