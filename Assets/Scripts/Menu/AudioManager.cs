using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AudioManager
{
    static bool initialized = false;
    static AudioSource audioSource;
    static Dictionary<AudioClipName, AudioClip> audioClips = new Dictionary<AudioClipName, AudioClip>();

    public static bool Initialized
    {
        get { return initialized; }
    }
    public static void Initialize(AudioSource source)
    {
        initialized = true;
        audioSource = source;
        audioClips.Add(AudioClipName.Music, Resources.Load<AudioClip>("m-mysterious-long"));
        audioClips.Add(AudioClipName.Button, Resources.Load<AudioClip>("m-mysterious-long"));
        audioClips.Add(AudioClipName.Dash, Resources.Load<AudioClip>("m-mysterious-long"));
        audioClips.Add(AudioClipName.Jump, Resources.Load<AudioClip>("m-mysterious-long"));
        audioClips.Add(AudioClipName.Slice, Resources.Load<AudioClip>("m-mysterious-long"));
        audioClips.Add(AudioClipName.Hit, Resources.Load<AudioClip>("m-mysterious-long"));    
    }
    public static void Play(AudioClipName name)
    {
        audioSource.PlayOneShot(audioClips[name]);
    }
}
