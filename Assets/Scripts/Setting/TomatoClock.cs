using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TomatoClock : MonoBehaviour
{
    // Start is called before the first frame update
    public Text Time;
    private UIManager uiManager;
    private ModelManager modelManager;
    private AudioManager audioManager;
    private int TomatoClockAlamStartTimeHour;
    private int TomatoClockAlamStartTimeMinute;
    private int TomatoClockAlamStartTimeSecond;
    private int hour;
    private int minute;
    private int second;
    private int TimeRemainMinute;//剩余时间分
    private int TimeRemainSecond;//剩余时间秒


    //音乐播放器
    // public AudioSource MusicPlayer;
    //音效播放器
    // public AudioSource[] SoundPlayer;


    void openTomatoClock()
    {
        if (modelManager.TomatoClockAlamTime != -1 && modelManager.TomatoClockAlamStartTime != null)
        {
            DateTime dt1 = DateTime.Now;
            DateTime dt2 = modelManager.TomatoClockAlamStartTime.AddMinutes(modelManager.TomatoClockAlamTime);
            // DateTime dt2 = modelManager.TomatoClockAlamStartTime.AddSeconds(modelManager.TomatoClockAlamTime);

            if (dt2 <= dt1)
            {
                // print("时间到了～～～～");
                Time.text = "00:00:00";
                PlayAlamAudio();
                modelManager.TomatoClockAlamTime = -1;
                return;
            }
            TimeSpan ts = dt2 - dt1;
            Time.text = ts.Hours.ToString("00") + ":" + ts.Minutes.ToString("00") + ":" + ts.Seconds.ToString("00");
        }
    }
    void PlayAlamAudio()
    {
        audioManager.PlayAlamAudio();
    }
    void Start()
    {
        modelManager = GameObject.Find("ModelManager").GetComponent<ModelManager>();
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
    }
    // Update is called once per frame
    void Update()
    {
        openTomatoClock();
        // print(modelManager.TomatoClockAlamStartTime - DateTime.Now).);
        // intUI();
    }
}
