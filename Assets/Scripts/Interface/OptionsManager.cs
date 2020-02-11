using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsManager : MonoBehaviour
{
    private AudioPlayer AudioPlayer;

    private Slider generalVolumeSlider;
    private Slider musicVolumeSlider;

    public GameObject generalVolumeSliderGameObject;
    public GameObject musicVolumeSliderGameObject;

    void Awake()
    {
        AudioPlayer = AudioPlayer.Instance;
        InitMusicVolumeLevel();
        InitGeneralVolumeLevel();
    }

    void InitMusicVolumeLevel()
    {
        musicVolumeSlider = musicVolumeSliderGameObject.GetComponent<Slider>();
        musicVolumeSlider.value = AudioPlayer.MusicVolumeLevel;
        musicVolumeSlider.onValueChanged.AddListener(delegate { OnVolumeChange(); });
    }

    void InitGeneralVolumeLevel()
    {
        generalVolumeSlider = generalVolumeSliderGameObject.GetComponent<Slider>();
        generalVolumeSlider.value = AudioPlayer.GeneralVolumeLevel;
        generalVolumeSlider.onValueChanged.AddListener(delegate { OnVolumeChange(); });
    }

    public void OnVolumeChange()
    {
        AudioPlayer.MusicVolumeLevel = musicVolumeSlider.value;
        AudioPlayer.GeneralVolumeLevel = generalVolumeSlider.value;
    }
}
