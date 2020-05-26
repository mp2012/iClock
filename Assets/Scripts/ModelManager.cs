using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModelManager : MonoBehaviour
{
    // Start is called before the first frame update
    public bool Time24Mode = true;//时间模式24小时制true,12false;
    public bool ShowSecondMode = true;//是否显示秒 true显示 false不显示;
    public bool ShowWeek = true;//是否显示周，true显示，false不显示。
    public bool ShowDay = true;//是否显示年月日，true显示，false不显示。
    

    //番茄闹钟～～～～～～～～～～～～～～
    public bool ShowAlarm = true;//是否显示闹铃。
    public int TomatoClockAlamTime = 1;//番茄闹钟时间，-1表示未开启闹钟，25表示闹钟时间为25分钟。
    public DateTime TomatoClockAlamStartTime ;//番茄闹钟开启时间，，-1表示未设定番茄闹钟。25表示剩余时间为25分钟。
    public int AlmClipId = 0;//番茄闹钟提示音id,-1表示没有闹铃音，1表示闹铃音为sound【1】的clip。


    //背景音乐～～～～～～～～～～～～～～～
    public int BgmClipId = -1;//白噪声id

    public int FontId = 2;//字体id
    public int FontColorId = 0;//字体颜色   
    public int BgColorId = 0;//背景颜色

    // public FontColor[0] = Color(100,255,255);


    void Start()
    {
        // print("ModelManager Start");
    }
    // Update is called once per frame
    void Update()
    {

    }
}
