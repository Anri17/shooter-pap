using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    public static AudioPlayer Instance { get; private set; }

    [SerializeField] AudioSource musicAudioSource;

    public const string MUSIC_VOLUME_LEVEL = "MusicVolumeLevel";
    public const string GENERAL_VOLUME_LEVEL = "GeneralVolumeLevel";

    public float MusicVolumeLevel
    {
        get { return PlayerPrefs.GetFloat(MUSIC_VOLUME_LEVEL); }
        set
        {
            PlayerPrefs.SetFloat(MUSIC_VOLUME_LEVEL, value);
            musicAudioSource.volume = value;
        }
    }
    public float GeneralVolumeLevel
    {
        get { return PlayerPrefs.GetFloat(GENERAL_VOLUME_LEVEL); }
        set
        {
            PlayerPrefs.SetFloat(GENERAL_VOLUME_LEVEL, value);
            AudioListener.volume = value;
        }
    }

    void Awake()
    {
        MakeSingleton();
        MusicVolumeLevel = PlayerPrefs.GetFloat(MUSIC_VOLUME_LEVEL);
        GeneralVolumeLevel = PlayerPrefs.GetFloat(GENERAL_VOLUME_LEVEL);
    }

    private void MakeSingleton()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayMusic(AudioClip musicFile)
    {
        musicAudioSource.clip = musicFile;
        musicAudioSource.Play();
    }
}
