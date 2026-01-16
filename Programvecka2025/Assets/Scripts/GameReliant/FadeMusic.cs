using UnityEngine;

public class FadeMusic : MonoBehaviour
{
    [SerializeField] Animator fadeMusicAnimator;

    public void MusicFade()
    {
        fadeMusicAnimator.SetTrigger("Start");
    }
}
