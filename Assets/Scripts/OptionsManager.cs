using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsManager : MonoBehaviour
{
    private Slider slider;
    private MusicPlayer musicPlayer;

    public GameObject sliderGameObject;

    void Awake()
    {
        musicPlayer = MusicPlayer.Instance;
        slider = sliderGameObject.GetComponent<Slider>();
        slider.value = musicPlayer.VolumeLevel;
    }

    void Update()
    {
        SetVolume(slider.value);
    }

    void SetVolume(float volume)
    {
        musicPlayer.VolumeLevel = volume;
    }
}
