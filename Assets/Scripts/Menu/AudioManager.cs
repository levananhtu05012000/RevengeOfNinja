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
        audioClips.Add(AudioClipName.Slice, Resources.Load<AudioClip>("ButtonClick"));
        audioClips.Add(AudioClipName.Hit, Resources.Load<AudioClip>("ButtonClick"));
        audioClips.Add(AudioClipName.Up, Resources.Load<AudioClip>("ButtonClick1"));
        audioClips.Add(AudioClipName.Down, Resources.Load<AudioClip>("ButtonClick1"));
        audioClips.Add(AudioClipName.FleshTakehit, Resources.Load<AudioClip>("flesh-takehit"));
        audioClips.Add(AudioClipName.SkeletonTakehit, Resources.Load<AudioClip>("skeleton-takehit"));
        audioClips.Add(AudioClipName.SkeletonDie, Resources.Load<AudioClip>("skeleton-die"));
        //audioClips.Add(AudioClipName.Explosion, Resources.Load<AudioClip>("Explosion"));        // Big Explosion 
        audioClips.Add(AudioClipName.Explosion, Resources.Load<AudioClip>("Explosion-smaller"));
        audioClips.Add(AudioClipName.GoblinAttack, Resources.Load<AudioClip>("goblin-attack"));
        audioClips.Add(AudioClipName.MushroomDetection, Resources.Load<AudioClip>("mushroom-detection"));
        audioClips.Add(AudioClipName.TrapAttack, Resources.Load<AudioClip>("trap-attack"));
        audioClips.Add(AudioClipName.PlayerAttack, Resources.Load<AudioClip>("player-attack"));
        //audioClips.Add(AudioClipName.PlayerAttack, Resources.Load<AudioClip>("player-attack-1"));
        audioClips.Add(AudioClipName.PlayerAttackCrit, Resources.Load<AudioClip>("player-attack-crit"));
        //audioClips.Add(AudioClipName.PlayerAttackCrit, Resources.Load<AudioClip>("player-attack-crit-1"));
        audioClips.Add(AudioClipName.PlayerShuriken, Resources.Load<AudioClip>("player-shuriken"));
        audioClips.Add(AudioClipName.PlayerDie, Resources.Load<AudioClip>("player-die"));
        //audioClips.Add(AudioClipName.PlayerDie, Resources.Load<AudioClip>("player-die-1"));
        audioClips.Add(AudioClipName.PlayerDash, Resources.Load<AudioClip>("player-dash"));
        //audioClips.Add(AudioClipName.Jump, Resources.Load<AudioClip>("ButtonClick"));
        audioClips.Add(AudioClipName.Jump, Resources.Load<AudioClip>("player-jump"));

        initialized = true;
    }
    
    public static void Play(AudioClipName name)
    {
        audioSource.PlayOneShot(audioClips[name]);
    }
}
