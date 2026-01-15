using UnityEngine;

public class MusicFade : MonoBehaviour
{
    public Animator musicAnimator;

    public void FadeInMusic()
    {
        musicAnimator.SetTrigger("Start");
    }
}
