using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class MusicRoom : MonoBehaviour
{
    public MusicClip[] musicClips;
    public GameObject musicListContent;

    public Text composerComment;

    public GameObject buttonTemplate;

    public Slider musicProgressBar;

    AudioPlayer audioPlayer;

    List<GameObject> buttonClips;

    int contentTotalSize = 0;

    private void Start()
    {
        audioPlayer = AudioPlayer.Instance;
        buttonClips = CreateMusicList(musicClips);

        SetActiveMusicButton();

        // Initialize MusicProgressBar
        musicProgressBar.maxValue = audioPlayer.musicAudioSource.clip.length;
    }

    private void Update()
    {
        musicProgressBar.value = audioPlayer.musicAudioSource.time;
    }

    List<GameObject> CreateMusicList(MusicClip[] clips)
    {
        List <GameObject> buttonClips = new List<GameObject>();
        int ypos = 0;
        for (int i = 0; i < clips.Length; i++)
        {
            int x = i;
            // Set size of container to fit the new music track
            contentTotalSize = contentTotalSize + 40;

            RectTransform parentObject = musicListContent.GetComponentInParent<RectTransform>();

            musicListContent.GetComponent<RectTransform>().sizeDelta = new Vector2(parentObject.sizeDelta.x, contentTotalSize);


            GameObject tempButton = Instantiate(buttonTemplate, musicListContent.transform);
            tempButton.name = "MusicClip" + (x + 1);
            tempButton.GetComponentInChildren<Text>().text = clips[x].musicTitle;
            tempButton.GetComponent<RectTransform>().localPosition += new Vector3(0, ypos, 0);
            tempButton.GetComponent<Button>().onClick.AddListener(delegate { RunMusic(musicClips[x]); });
            buttonClips.Add(tempButton);
            ypos = ypos - 40;
        }

        return buttonClips;
    }

    public void RunMusic(MusicClip clip)
    {
        PlayMusic(clip.musicClip);
        composerComment.text = clip.composerComment;
        
        SetActiveMusicButton();
    }

    public void PlayMusic(AudioClip clip)
    {
        if (audioPlayer.musicAudioSource.clip != clip)
        {
            audioPlayer.PlayMusic(clip, 0);
            musicProgressBar.maxValue = audioPlayer.musicAudioSource.clip.length;
            StopMusic();
            PlayTrack();
        }
    }

    public void StopMusic()
    {
        if (audioPlayer.musicAudioSource.clip != null)
        {
            audioPlayer.musicAudioSource.Stop();
            SetTrackTime(0);
            audioPlayer.musicAudioSource.time = 0;
        }
    }

    public void PlayTrack()
    {
        if (audioPlayer.musicAudioSource.clip != null)
        {
            if (!audioPlayer.musicAudioSource.isPlaying)
                audioPlayer.musicAudioSource.Play();
        }
    }

    public void PauseMusic()
    {
        if (audioPlayer.musicAudioSource.clip != null)
        {
            audioPlayer.musicAudioSource.Pause();
        }
    }

    public void SetTrackTime(float sliderValue)
    {
        if (sliderValue < musicProgressBar.maxValue && sliderValue > musicProgressBar.minValue)
        {
            audioPlayer.musicAudioSource.time = sliderValue;
        }
    }

    public void SetActiveMusicButton()
    {
        Button[] buttons = ConvertToButtonArray(buttonClips);

        for (int i = 0; i < musicClips.Length; i++)
        {
            if (musicClips[i].musicClip == audioPlayer.musicAudioSource.clip)
            {
                var thisColors = buttons[i].colors;
                thisColors.normalColor = new Color(0.5f, 0.5f, 0.2f, 0.5f);
                thisColors.highlightedColor = new Color(0.5f, 0.5f, 0.2f, 0.5f);
                thisColors.pressedColor = new Color(0.5f, 0.5f, 0.2f, 0.5f);
                thisColors.selectedColor = new Color(0.5f, 0.5f, 0.2f, 0.5f);
                thisColors.disabledColor = new Color(0.5f, 0.5f, 0.2f, 0.5f);
                buttons[i].colors = thisColors;
            }
            else
            {
                print(buttons[i].gameObject.name);
                var thisColors = buttons[i].colors;
                thisColors.normalColor = new Color(0, 0, 0, 0); ;
                thisColors.highlightedColor = new Color(0, 0, 0, 0); ;
                thisColors.pressedColor = new Color(0, 0, 0, 0); ;
                thisColors.selectedColor = new Color(0, 0, 0, 0); ;
                thisColors.disabledColor = new Color(0, 0, 0, 0); ;
                buttons[i].colors = thisColors;
            }
        }
    }

    public Button[] ConvertToButtonArray(List<GameObject> buttonObjects)
    {
        List<Button> resultList = new List<Button>();

        foreach (GameObject buttonObject in buttonObjects)
        {
            resultList.Add(buttonObject.GetComponent<Button>());
        }
        return resultList.ToArray();
    }
}
