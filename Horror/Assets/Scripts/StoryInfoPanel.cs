using UnityEngine;

public class StoryInfoPanel : MonoBehaviour
{
    public GameObject infoPanel;  // Reference to the story info panel

    public void CloseInfo()
    {
        infoPanel.SetActive(false);  // Deactivate the info panel when the button is clicked
    }
}
