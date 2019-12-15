using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public static MusicPlayer Instance { get; private set; }

    public AudioSource audioPlayer;

    void Awake()
    {
        audioPlayer.loop = true;
        MakeSingleton();
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
