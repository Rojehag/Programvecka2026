using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundEffect : MonoBehaviour
{
    [SerializeField] List<AudioClip> sufferingDamageSounds = new List<AudioClip>();
    [SerializeField] List<AudioClip> punchSounds = new List<AudioClip>();

    [SerializeField] AudioClip dieSound;
    [SerializeField] AudioClip SwordAttackSound;

    AudioSource audioSource;

    int randomIndex;

    public void PlayDamageSound()
    {
        randomIndex = Random.RandomRange(0, sufferingDamageSounds.Count);

        audioSource = GetComponent<AudioSource>();
        audioSource.clip = sufferingDamageSounds[randomIndex];
        audioSource.volume = 1;
        audioSource.Play();
    }

    public void PlayDieSound()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = dieSound;
        audioSource.volume = 0.25f;
        audioSource.Play();
    }

    public void PlayPunchSound()
    {
        randomIndex = Random.RandomRange(0, punchSounds.Count);
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = punchSounds[randomIndex];
        audioSource.volume = 1;
        audioSource.Play();
    }

    public void PlaySwordAttackSound()
    {
        
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = SwordAttackSound;
        audioSource.volume = 1;
        audioSource.Play();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            PlayDieSound();
        }
    }

}
