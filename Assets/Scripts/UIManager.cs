using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update
    private ModelManager modelManager;
    private FontManager fontManager;
    public GameObject HMWin;//时分窗口
    public GameObject HMSWin;//时分秒窗口
    public GameObject SettingWin;//设置窗口
    public GameObject DisplaySettingWin;//显示设置窗口    
    public GameObject AlarmWin;//番茄闹钟主界面的时间
    public GameObject AlarmTimeSettingWin;//番茄闹钟设置窗口
    public GameObject AlarmAudioSettingWin;//番茄闹钟音效设定窗口。
    public GameObject BgmSettingWin;//白噪声设定窗口；
    // public GameObject HMWinAMPM;//HMWinAMPM界面的标示；
    // public GameObject HMWinAMPM;//HMWinAMPM界面的标示；
    public GameObject FontSettingWin;//字体设定窗口；
    public GameObject FontColorSettingWin;//字体颜色设定窗口；

    public GameObject BgColorSettingWin;//背景颜色设定窗口；
    public GameObject BgWin;//背景图片；

    private ColorManager colorManager;

    public void OpneSettingWin()
    {
        SettingWin.SetActive(true);
    }
    public void CloseSettingWin()
    {
        SettingWin.SetActive(false);
    }
    public void OpenDisplaySettingWin()
    {
        DisplaySettingWin.SetActive(true);
    }
    public void CloseDisplaySettingWin()
    {
        DisplaySettingWin.SetActive(false);
    }
    public void OpenAlarmTimeSettingWin()
    {
        AlarmTimeSettingWin.SetActive(true);
    }
    public void CloseAlarmTimeSettingWin()
    {
        AlarmTimeSettingWin.SetActive(false);
    }
    public void OpenAlarmAudioSettingWin()
    {
        AlarmAudioSettingWin.SetActive(true);
    }
    public void CloseAlarmAudioSettingWin()
    {
        AlarmAudioSettingWin.SetActive(false);
    }

    public void OpenBgmSettingWin()
    {
        BgmSettingWin.SetActive(true);
    }
    public void CloseBgmSettingWin()
    {
        BgmSettingWin.SetActive(false);
    }
    public void OpenFontSettingWin()
    {
        FontSettingWin.SetActive(true);
    }
    public void CloseFontSettingWin()
    {
        FontSettingWin.SetActive(false);
    }
    public void OpenFontColorSettingWin()
    {
        FontColorSettingWin.SetActive(true);
    }
    public void CloseFontColorSettingWin()
    {
        FontColorSettingWin.SetActive(false);
    }
    public void OpenBgColorSettingWin()
    {
        BgColorSettingWin.SetActive(true);
    }
    public void CloseBgColorSettingWin()
    {
        BgColorSettingWin.SetActive(false);
    }

    public void IsSecondMode()//秒模式和分模式的判断显示
    {
        if (modelManager.ShowSecondMode == true)
        {
            HMSWin.SetActive(true);
            HMWin.SetActive(false);
        }
        else
        {
            HMSWin.SetActive(false);
            HMWin.SetActive(true);
        }
    }

    public void IsShowWeek()//是否显示周
    {
        if (modelManager.ShowWeek == true)
        {
            HMWin.GetComponent<timeManager>().Week.SetActive(true);
            HMSWin.GetComponent<timeManager>().Week.SetActive(true);
        }
        else
        {
            HMWin.GetComponent<timeManager>().Week.SetActive(false);
            HMSWin.GetComponent<timeManager>().Week.SetActive(false);
        }
    }
    public void IsShowDay()//是否显示周
    {
        if (modelManager.ShowDay == true)
        {
            HMWin.GetComponent<timeManager>().Day.SetActive(true);
            HMSWin.GetComponent<timeManager>().Day.SetActive(true);
        }
        else
        {
            HMWin.GetComponent<timeManager>().Day.SetActive(false);
            HMSWin.GetComponent<timeManager>().Day.SetActive(false);
        }
    }
    public void IsShowAlarm()//是否显示番茄闹钟
    {
        if (modelManager.ShowAlarm == true)
        {
            AlarmWin.SetActive(true);
        }
        else
        {
            AlarmWin.SetActive(false);
        }
    }
    public void IsShow24HourMode()//是否显示24小时模式
    {
        // print("UIManager IsShow24HourMode");
        HMSWin.GetComponent<timeManager>().IntTime();
        HMWin.GetComponent<timeManager>().IntTime();
    }

    public void SetFonts()//设置字体
    {
        HMSWin.GetComponent<timeManager>().SetFonts();
        HMWin.GetComponent<timeManager>().SetFonts();
    }
    public void SetFontsColor()//设置字体颜色
    {
        HMSWin.GetComponent<timeManager>().SetFontsColor();
        HMWin.GetComponent<timeManager>().SetFontsColor();
    }
    public void SetBgColor()//设置背景颜色
    {
        colorManager = GameObject.Find("ColorManager").GetComponent<ColorManager>();
        BgWin.GetComponent<Image>().color = colorManager.mycolor[modelManager.BgColorId];
    }
    public void intUI()
    {
        // print("UIManager intUI");
        IsSecondMode();
        IsShowWeek();
        IsShowDay();
        IsShowAlarm();
        IsShow24HourMode();
        SetFonts();
    }
    void Awake()
    {
        // print("UIManager Awake");
        modelManager = GameObject.Find("ModelManager").GetComponent<ModelManager>();
        fontManager = GameObject.Find("FontManager").GetComponent<FontManager>();

    }
    void Start()
    {
        print("UIManager Start");
        intUI();
    }
    // Update is called once per frame
    void Update()
    {

    }
}
