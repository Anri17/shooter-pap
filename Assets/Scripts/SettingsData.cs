using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsData
{
    public float masterVolumeLevel;
    public float musicVolumeLevel;
    public float effectsVolumeLevel;

    public SettingsData()
    {
        masterVolumeLevel = 1;
        musicVolumeLevel = 1;
        effectsVolumeLevel = 0.5f;
    }
}