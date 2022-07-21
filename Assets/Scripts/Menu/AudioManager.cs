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
        audioClips.Add(AudioClipName.FleshTakehit, Resources.Load<AudioClip>("flesh-takehit"));
        audioClips.Add(AudioClipName.SkeletonTakehit, Resources.Load<AudioClip>("skeleton-takehit"));
        audioClips.Add(AudioClipName.SkeletonDie, Resources.Load<AudioClip>("skeleton-die"));
        audioClips.Add(AudioClipName.Explosion, Resources.Load<AudioClip>("Explosion"));
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
        audioClips.Add(AudioClipName.Boss_death_1, Resources.Load<AudioClip>("Boss_death_1"));
        audioClips.Add(AudioClipName.Boss_death_2, Resources.Load<AudioClip>("Boss_death_2"));
        audioClips.Add(AudioClipName.Boss_enrage_1, Resources.Load<AudioClip>("Boss_enrage_1"));
        audioClips.Add(AudioClipName.Boss_enrage_2, Resources.Load<AudioClip>("Boss_enrage_2"));
        audioClips.Add(AudioClipName.Boss_enrage_3, Resources.Load<AudioClip>("Boss_enrage_3"));
        audioClips.Add(AudioClipName.Boss_Fire_blasting_Boss_skill1, Resources.Load<AudioClip>("Boss_Fire_blasting_Boss_skill1"));
        audioClips.Add(AudioClipName.Boss_Fireball_fly, Resources.Load<AudioClip>("Boss_Fireball_fly"));
        audioClips.Add(AudioClipName.Boss_Fireball_Spell, Resources.Load<AudioClip>("Boss_Fireball_Spell"));
        audioClips.Add(AudioClipName.Boss_Heavy_sword, Resources.Load<AudioClip>("Boss_Heavy_sword"));
        audioClips.Add(AudioClipName.Boss_jump, Resources.Load<AudioClip>("Boss_jump"));
        audioClips.Add(AudioClipName.Boss_take_hit, Resources.Load<AudioClip>("Boss_take_hit"));
        audioClips.Add(AudioClipName.Boss_tranform_1, Resources.Load<AudioClip>("Boss_tranform_1"));
        audioClips.Add(AudioClipName.Boss_walking_1, Resources.Load<AudioClip>("Boss_walking_1"));
        audioClips.Add(AudioClipName.Boss_walking_2, Resources.Load<AudioClip>("Boss_walking_2"));

        initialized = true;
    }
    
    public static void Play(AudioClipName name)
    {
        audioSource.PlayOneShot(audioClips[name]);
    }
}
