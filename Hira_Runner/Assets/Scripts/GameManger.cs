using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GameManger : MonoBehaviour
{
    public AudioSource Audio;
    public AudioSource Audio2,Audio3;
    public TextMeshProUGUI TMPText;
    public Image Started;
    private bool ControlStart= true;
    public static int AudioStatus;
    public int pAudioStatus;
    void Start()
    {
        AudioStatus = pAudioStatus;
        Audio.Stop();
        Audio2.Stop();
        Audio3.Stop();
        PauseGame();
    }
    void Update()
    {
        AudioStatus = pAudioStatus;
        if (Input.GetKey("space") && ControlStart)
        {
            ResumeGame();
            TMPText.SetText("");
            Started.enabled = false;
            ControlStart = false;
        }
        if(Time.timeScale > 0)
        {
            SoundStarted();
        };
    }
    void PauseGame()
    {
        Time.timeScale = 0;
    }
    void ResumeGame()
    {
        Time.timeScale = 1;
    }
    void SoundStarted()
    {
        switch (AudioStatus)
        {
            case (0):
                if (!(Audio.isPlaying)) {
                    Audio3.Stop();
                    Audio2.Stop();
                    Audio.Play();
                }
                break;
            case (1):
                if (LaneChange.Track == "City")
                {
                    if (!(Audio2.isPlaying))
                    {            
                        Audio3.Stop();
                        Audio.Stop();
                        Audio2.Play();
                    }         
                }
                if (LaneChange.Track == "Florest")
                {
                    if (!(Audio3.isPlaying))
                    {
                        Audio2.Stop();
                        Audio.Stop();
                        Audio3.Play();
                    }
                }
                    break;
            default:
                Audio3.Stop();
                Audio2.Stop();
                Audio.Stop();
                break;
        }
    }
}