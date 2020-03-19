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

    AudioPlayer audioPlayer;

    List<GameObject> buttonClips;

    int contentTotalSize = 0;

    private void Start()
    {
        composerComment.text = "";
        audioPlayer = AudioPlayer.Instance;
        buttonClips = CreateMusicList(musicClips);
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
            musicListContent.GetComponent<RectTransform>().sizeDelta += new Vector2(0, contentTotalSize);


            GameObject tempButton = Instantiate(buttonTemplate, musicListContent.transform);
            tempButton.name = "MusicClip" + (x + 1);
            tempButton.GetComponentInChildren<Text>().text = clips[x].musicTitle;
            tempButton.GetComponent<RectTransform>().localPosition += new Vector3(0, ypos, 0);
            tempButton.GetComponent<Button>().onClick.AddListener(delegate { RunMusic(musicClips[x]); });
            buttonClips.Add(tempButton);
            ypos = ypos - 40;

            print(ypos);
            print(contentTotalSize);
        }

        return buttonClips;
    }

    public void RunMusic(MusicClip clip)
    {
        PlayMusic(clip.musicClip);
        composerComment.text = clip.composerComment;
    }

    public void PlayMusic(AudioClip clip)
    {
        if (audioPlayer.musicAudioSource.clip != clip)
            audioPlayer.PlayMusic(clip);
    }
}
