using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioPlayer : MonoBehaviour
{
    public static AudioPlayer Instance { get; private set; }

    public AudioSource musicAudioSource;
    [SerializeField] AudioSource hitAudioSource;
    [SerializeField] AudioSource killAudioSource;
    [SerializeField] AudioSource deathAudioSource;
    [SerializeField] AudioSource shootAudioSource;
    [SerializeField] AudioMixer mixer;

    public const string MASTER_VOLUME_LEVEL = "MasterVolumeLevel";
    public const string MUSIC_VOLUME_LEVEL = "MusicVolumeLevel";
    public const string EFFECTS_VOLUME_LEVEL = "EffectsVolumeLevel";

    double musicLoopTime;

    public float MasterVolumeLevel
    {
        get => PlayerPrefs.GetFloat(MASTER_VOLUME_LEVEL);
        set
        {
            PlayerPrefs.SetFloat(MASTER_VOLUME_LEVEL, value);
            mixer.SetFloat("MasterVolume", Mathf.Log10(value) * 20);
        }
    }
    public float MusicVolumeLevel
    {
        get => PlayerPrefs.GetFloat(MUSIC_VOLUME_LEVEL);
        set
        {
            PlayerPrefs.SetFloat(MUSIC_VOLUME_LEVEL, value);
            mixer.SetFloat("MusicVolume", Mathf.Log10(value) * 20);
        }
    }
    public float EffectsVolumeLevel
    {
        get => PlayerPrefs.GetFloat(EFFECTS_VOLUME_LEVEL);
        set
        {
            PlayerPrefs.SetFloat(EFFECTS_VOLUME_LEVEL, value);
            mixer.SetFloat("EffectsVolume", Mathf.Log10(value) * 20);
        }
    }

    void Awake()
    {
        MakeSingleton();
    }

    void Start()
    {
        InitMusicVolumeLevel();
    }

    void Update()
    {
        // print(musicAudioSource.time);
        // print(musicLoopTime);
        if (musicAudioSource.time >= musicAudioSource.clip.length)
        {
            print("hey");
            print(musicLoopTime);
            musicAudioSource.Stop();
            musicAudioSource.time = (float) musicLoopTime;
//            musicAudioSource.loop = true;
//            musicAudioSource.loop = false;
            musicAudioSource.Play();
        }
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

    public void InitMusicVolumeLevel()
    {
        // Start player prefs for first time
        if (!PlayerPrefs.HasKey(MASTER_VOLUME_LEVEL))
            MasterVolumeLevel = 0.25f;

        if (!PlayerPrefs.HasKey(MUSIC_VOLUME_LEVEL))
            MusicVolumeLevel = 0.5f;

        if (!PlayerPrefs.HasKey(EFFECTS_VOLUME_LEVEL))
            EffectsVolumeLevel = 0.25f;

        mixer.SetFloat("MasterVolume", Mathf.Log10(MasterVolumeLevel) * 20);
        mixer.SetFloat("MusicVolume", Mathf.Log10(MusicVolumeLevel) * 20);
        mixer.SetFloat("EffectsVolume", Mathf.Log10(EffectsVolumeLevel) * 20);
    }

    public void PlayHitSound()
    {
        hitAudioSource.Play();
    }

    public void PlayKillSound()
    {
        killAudioSource.Play();
    }

    public void PlayDeathSound()
    {
        deathAudioSource.Play();
    }

    public void PlayShootSound()
    {
        shootAudioSource.Play();
    }

    public void PlayMusic(AudioClip musicFile, double loopTime)
    {
        musicAudioSource.Stop();
        musicAudioSource.loop = true;
        musicAudioSource.time = 0;
        musicAudioSource.clip = musicFile;
        musicAudioSource.loop = false;
        musicLoopTime = (double) loopTime / 1000.0;
        musicAudioSource.Play();

    }

    public void StopMusic()
    {
        musicAudioSource.Stop();
    }
}
