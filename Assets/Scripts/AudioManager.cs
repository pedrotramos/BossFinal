using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    private AudioSource sfxSource = default;
    [SerializeField]
    private static AudioManager _instance;

    void Awake()
    {
        _instance = this;
    }

    public static void PlaySFX(AudioClip audioClip, float vol)
    {
        _instance.sfxSource.PlayOneShot(audioClip, vol);
    }
}
