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

    SettingsData settings;

    public float MasterVolumeLevel
    {
        get => SettingsManager.Instance.Settings.masterVolumeLevel;
        set
        {
            SettingsData settingsData = settings;
            settingsData.masterVolumeLevel = value;
            settings = settingsData;
            mixer.SetFloat("MasterVolume", Mathf.Log10(value) * 20);
        }
    }
    public float MusicVolumeLevel
    {
        get => SettingsManager.Instance.Settings.musicVolumeLevel;
        set
        {
            SettingsData settingsData = settings;
            settingsData.musicVolumeLevel = value;
            settings = settingsData;
            mixer.SetFloat("MusicVolume", Mathf.Log10(value) * 20);
        }
    }
    public float EffectsVolumeLevel
    {
        get => SettingsManager.Instance.Settings.effectsVolumeLevel;
        set
        {
            SettingsData settingsData = settings;
            settingsData.effectsVolumeLevel = value;
            settings = settingsData;
            mixer.SetFloat("EffectsVolume", Mathf.Log10(value) * 20);
        }
    }

    void Awake()
    {
        MakeSingleton();
        settings = SettingsManager.Instance.Settings;
    }

    void Start()
    {
        InitAudio();
    }

    void Update()
    {
        if (musicAudioSource.time >= musicAudioSource.clip.length)
        {
            print("hey");
            print(musicLoopTime);
            musicAudioSource.Stop();
            musicAudioSource.time = (float) musicLoopTime;
            musicAudioSource.Play();
        }
    }

    void InitAudio()
    {
        MasterVolumeLevel = MasterVolumeLevel;
        MusicVolumeLevel = MusicVolumeLevel;
        EffectsVolumeLevel = EffectsVolumeLevel;
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
