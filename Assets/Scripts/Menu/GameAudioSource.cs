using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameAudioSource : MonoBehaviour
{
    [SerializeField]
    Slider sld;
    void Awake()
    {
        AudioSource audioSource;
        //if (!AudioManager.Initialized)
        //{
        audioSource = gameObject.AddComponent<AudioSource>();
        AudioManager.Initialize(audioSource);
        DontDestroyOnLoad(gameObject);
        //}
        //else
        //{
        //    Destroy(gameObject);
        //}


        if (sld != null)
        {
            float volume = 1f;
            if (PlayerPrefs.HasKey("gameVolume"))
                volume = PlayerPrefs.GetFloat("gameVolume");

            PlayerPrefs.SetFloat("gameVolume", volume);

            audioSource.volume = volume;
            sld.value = volume;

            sld.onValueChanged.AddListener((float value) =>
            {
                PlayerPrefs.SetFloat("gameVolume", sld.value);
                audioSource.volume = volume;
            });
        }
    }


}
