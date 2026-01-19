using UnityEngine;

public class FadeBattleMusic : MonoBehaviour
{
    [SerializeField] Animator fadeBattleMusicAnimator;

    public void BattleMusicFade()
    {
        fadeBattleMusicAnimator.SetTrigger("Start");
    }
}
