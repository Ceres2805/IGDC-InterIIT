using UnityEngine;

public class BookInteraction : MonoBehaviour
{
    public GameObject infoPanel; // Reference to the info panel
    public bool isPlayerNearby = false;

    void Start()
    {
        // Ensure the info panel is disabled initially
        infoPanel.SetActive(false);
    }

    void Update()
    {
        // If the player is nearby, ensure the panel stays active
        if (isPlayerNearby)
        {
            ShowStoryInfo();
        }
        else
        {
            HideStoryInfo();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = false;
        }
    }

    void ShowStoryInfo()
    {
        infoPanel.SetActive(true); // Activate the info panel to show book information
    }

    void HideStoryInfo()
    {
        infoPanel.SetActive(false); // Deactivate the info panel
    }
}
