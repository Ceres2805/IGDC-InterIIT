using UnityEngine;

public class Footsteps : MonoBehaviour
{
    public AudioSource foot;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W)||Input.GetKey(KeyCode.A)||Input.GetKey(KeyCode.S)||Input.GetKey(KeyCode.D))
        {
            foot.enabled = true;
        }
        else
        {
            foot.enabled = false;
        }
    }
}
