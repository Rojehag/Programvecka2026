using UnityEngine;

public class FadeBattleMusic : FadeMusic
{
    [SerializeField] Animator fadeBattleMusicAnimator;

    public void BattleMusicFade()
    {
        fadeBattleMusicAnimator.SetTrigger("Start");
    }
}
