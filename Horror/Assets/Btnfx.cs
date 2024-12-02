using UnityEngine;

public class Btnfx : MonoBehaviour
{
    public AudioSource Btfx;
    public AudioClip hover;
    public AudioClip click;
    public void Hoverbtn()
    {
        Btfx.PlayOneShot(hover);
    }
    public void ClickBtn()
    {
        Btfx.PlayOneShot(click);
    }
}
