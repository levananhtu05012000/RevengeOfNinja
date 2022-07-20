using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AudioManager
{
    static bool initialized = false;
    static AudioSource audioSource;
    static Dictionary<AudioClipName, AudioClip> audioClips; 

    public static bool Initialized
    {        
        get { return initialized; }
    }
    public static void Initialize(AudioSource source)
    {
        audioClips = new Dictionary<AudioClipName, AudioClip>();
        audioSource = source;
        audioClips.Add(AudioClipName.Music, Resources.Load<AudioClip>("MysteriousLongM"));
        audioClips.Add(AudioClipName.Button, Resources.Load<AudioClip>("ButtonClick"));
        audioClips.Add(AudioClipName.Dash, Resources.Load<AudioClip>("ButtonClick"));
        audioClips.Add(AudioClipName.Jump, Resources.Load<AudioClip>("ButtonClick"));
        audioClips.Add(AudioClipName.Slice, Resources.Load<AudioClip>("ButtonClick"));
        audioClips.Add(AudioClipName.Hit, Resources.Load<AudioClip>("ButtonClick"));
        audioClips.Add(AudioClipName.Up, Resources.Load<AudioClip>("ButtonClick1"));
        audioClips.Add(AudioClipName.Down, Resources.Load<AudioClip>("ButtonClick1"));
        
        initialized = true;
    }
    
    public static void Play(AudioClipName name)
    {
        audioSource.PlayOneShot(audioClips[name]);
    }
}
