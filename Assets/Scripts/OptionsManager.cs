using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsManager : MonoBehaviour
{
    public GameObject sliderGameObject;
    public float volume;

    private Slider slider;

    void Awake()
    {
        slider = sliderGameObject.GetComponent<Slider>();
        slider.value = MusicPlayer.Instance.GetVolume(); // set slider value to music volume at the start of the scene
    }

    void Update()
    {
        volume = slider.value;
        MusicPlayer.Instance.SetVolume(volume);
    }
}
