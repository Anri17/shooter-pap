using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    AudioSource audioPlayer;

    public static MusicPlayer Instance { get; private set; }
    public float VolumeLevel
    {
        get { return audioPlayer.volume; }
        set { audioPlayer.volume = value; }
    }

    void Awake()
    {
        audioPlayer = GetComponent<AudioSource>();
        MakeSingleton();
        audioPlayer.loop = true;
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
        audioPlayer.clip = musicFile;
        audioPlayer.Play();
    }

    public void SetVolume(float volume)
    {
        audioPlayer.volume = volume;
    }

    public float GetVolume()
    {
        return audioPlayer.volume;
    }
}
