using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timeManager : MonoBehaviour
{
    private int hour;
    private int minute;
    private int second;
    private int year;
    private int month;
    private int day;
    private int showTime;
    private string week;
    // public Text HourText;
    public Text HourUpUpText;
    public Text HourUpDownText;
    public Text HourDownUpText;
    public Text HourDownDownText;
    public Text MinuteUpUpText;
    public Text MinuteUpDownText;
    public Text MinuteDownUpText;
    public Text MinuteDownDownText;

    public Text SecondUpUpText;
    public Text SecondUpDownText;
    public Text SecondDownUpText;
    public Text SecondDownDownText;
    public Text WeekText;
    public GameObject Week;
    public Text DayText;
    public GameObject Day;
    public Animator HourChangeAnim;
    public Animator MinuteChangeAnim;
    public Animator SecondChangeAnim;
    public Text LogText;
    public Text AMPM;

    private ModelManager modelManager;
    private FontManager fontManager;
    private ColorManager colorManager;

    void CnWeek()
    //显示中文星期
    {
        week = DateTime.Now.DayOfWeek.ToString();
        string[] Day = new string[] { "星期日", "星期一", "星期二", "星期三", "星期四", "星期五", "星期六" };
        string today_day = Day[Convert.ToInt16(DateTime.Now.DayOfWeek)];
        WeekText.text = today_day;

    }
    void AMPMTextDisplayWeekText()
    {//秒模式 且 24小时模式下 Week显示“”，AMPM显示week
        if (modelManager.Time24Mode == true && modelManager.ShowSecondMode == true)
        {
            WeekText.text = "";
            AMPM.text = DateTime.Now.DayOfWeek.ToString();
        }
    }
    //
    public void IntTime()//初始化，获取时间，并刷新界面
    {
        // print("timeManager IntTime  ");
        modelManager = GameObject.Find("ModelManager").GetComponent<ModelManager>();
        // print("timeManager IntTime  modelManager.Time24Mode   " + modelManager.Time24Mode);
        //获取当前时间
        // showTime = DateTime.Now;
        hour = DateTime.Now.Hour;
        minute = DateTime.Now.Minute;
        second = DateTime.Now.Second;
        year = DateTime.Now.Year;
        month = DateTime.Now.Month;
        day = DateTime.Now.Day;

        //12 24小时模式处理
        // print("modelManager.Time24Mode" + modelManager.Time24Mode);
        if (modelManager.Time24Mode == false)//12小时模式
        {
            if (hour > 12)
            {

                AMPM.text = "PM";
                HourUpUpText.text = (hour - 12).ToString("00");
                HourUpDownText.text = (hour - 12).ToString("00");
                HourDownUpText.text = (hour - 12).ToString("00");
                HourDownDownText.text = (hour - 12).ToString("00");
            }
            else
            {
                AMPM.text = "AM";
                HourUpUpText.text = hour.ToString("00");
                HourUpDownText.text = hour.ToString("00");
                HourDownUpText.text = hour.ToString("00");
                HourDownDownText.text = hour.ToString("00");
            }
        }
        else//24小时模式
        {
            AMPM.text = "";
            HourUpUpText.text = hour.ToString("00");
            HourUpDownText.text = hour.ToString("00");
            HourDownUpText.text = hour.ToString("00");
            HourDownDownText.text = hour.ToString("00");
        }


        // HourUpUpText.text = hour.ToString("00");
        // HourUpDownText.text = hour.ToString("00");
        // HourDownUpText.text = hour.ToString("00");
        // HourDownDownText.text = hour.ToString("00");

        MinuteUpUpText.text = minute.ToString("00");
        MinuteUpDownText.text = minute.ToString("00");
        MinuteDownUpText.text = minute.ToString("00");
        MinuteDownDownText.text = minute.ToString("00");

        SecondUpUpText.text = second.ToString("00");
        SecondUpDownText.text = second.ToString("00");
        SecondDownUpText.text = second.ToString("00");
        SecondDownDownText.text = second.ToString("00");

        // CnWeek();
        WeekText.text = DateTime.Now.DayOfWeek.ToString();
        DayText.text = year.ToString("0000") + "年" + month.ToString("00") + "月" + day.ToString("00") + "日";
        // DayText.text = DateTime.Now.ToShortDateString().ToString();     
        DayText.text = DateTime.Now.ToString("MMM dd yyyy");

        AMPMTextDisplayWeekText();

    }


    void hourModeControl()//判断12或24小时模式
    {
        // print("hourModeControl");
        if (modelManager.Time24Mode == false)
        {
            hourControl12HourMode();
        }
        else
        {
            hourControl();
        }
    }

    void hourControl12HourMode()//12小时模式显示控制
    {
        // print("hourControl12HourMode");
        //动画是否在播放
        AnimatorStateInfo HourAnimatorInfo = HourChangeAnim.GetCurrentAnimatorStateInfo(0);
        if (HourAnimatorInfo.normalizedTime >= 1.0f)//播放判断//未播放        //normalizedTime的值为0~1，0为开始，1为结束。
        {
            if (hour == DateTime.Now.Hour) //相同
            {
                return;
            }
            else//不同
            {
                //上午
                if (hour <= 12)
                {
                    //上层面板更新
                    HourUpUpText.text = hour.ToString("00");
                    HourUpDownText.text = hour.ToString("00");
                    //下层面板更新
                    hour = DateTime.Now.Hour;
                    HourDownUpText.text = hour.ToString("00");
                    HourDownDownText.text = hour.ToString("00");
                    //播放动画
                    HourChangeAnim.Play("flip", 0, 0f);
                }
                //下午
                else
                {
                    //上层面板更新
                    HourUpUpText.text = (hour - 12).ToString("00");
                    HourUpDownText.text = (hour - 12).ToString("00");
                    //下层面板更新
                    hour = DateTime.Now.Hour;
                    HourDownUpText.text = (hour - 12).ToString("00");
                    HourDownDownText.text = (hour - 12).ToString("00");
                    //播放动画
                    HourChangeAnim.Play("flip", 0, 0f);

                }
            }
        }
        else//播放中
        {
            return;
        }
    }
    void hourControl()//默认的，24小时显示模式
    {
        // print("hourControl");
        //时~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        //动画是否在播放
        AnimatorStateInfo HourAnimatorInfo = HourChangeAnim.GetCurrentAnimatorStateInfo(0);
        if (HourAnimatorInfo.normalizedTime >= 1.0f)//播放判断//未播放        //normalizedTime的值为0~1，0为开始，1为结束。
        {
            if (hour == DateTime.Now.Hour) //相同
            {
                return;
            }
            else//不同
            {
                //上层面板更新
                HourUpUpText.text = hour.ToString("00");
                HourUpDownText.text = hour.ToString("00");
                //下层面板更新
                hour = DateTime.Now.Hour;
                HourDownUpText.text = hour.ToString("00");
                HourDownDownText.text = hour.ToString("00");
                //播放动画
                HourChangeAnim.Play("flip", 0, 0f);
            }
        }
        else//播放中
        {
            return;
        }
    }
    void minuteControl()
    {
        //分~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        //动画是否在播放
        AnimatorStateInfo MinuteAnimatorInfo = MinuteChangeAnim.GetCurrentAnimatorStateInfo(0);
        if (MinuteAnimatorInfo.normalizedTime >= 1.0f)//播放判断//未播放        //normalizedTime的值为0~1，0为开始，1为结束。
        {
            // print("动画播放完成");          
            //显示时间和实际时间是否相同
            if (minute == DateTime.Now.Minute) //相同
            {
                return;
            }
            else//不同
            {
                //上层面板更新
                MinuteUpUpText.text = minute.ToString("00");
                MinuteUpDownText.text = minute.ToString("00");
                //下层面板更新
                minute = DateTime.Now.Minute;
                MinuteDownUpText.text = minute.ToString("00");
                MinuteDownDownText.text = minute.ToString("00");
                //播放动画
                MinuteChangeAnim.Play("flip", 0, 0f);
            }
        }
        else//播放中
        {
            return;
        }
    }
    void secondControl()
    {
        //秒~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        //动画是否在播放
        AnimatorStateInfo SecondAnimatorInfo = SecondChangeAnim.GetCurrentAnimatorStateInfo(0);
        if (SecondAnimatorInfo.normalizedTime >= 1.0f)//播放判断//未播放        //normalizedTime的值为0~1，0为开始，1为结束。
        {
            // print("动画播放完成");          
            //显示时间和实际时间是否相同
            if (second == DateTime.Now.Second) //相同
            {
                return;
            }
            else//不同
            {
                //上层面板更新
                SecondUpUpText.text = second.ToString("00");
                SecondUpDownText.text = second.ToString("00");
                //下层面板更新
                second = DateTime.Now.Second;
                SecondDownUpText.text = second.ToString("00");
                SecondDownDownText.text = second.ToString("00");
                //播放动画
                SecondChangeAnim.Play("flip", 0, 0f);
            }
        }
        else//播放中
        {
            return;
        }
    }


    public void SetFonts()//设置字体
    {
        print("SetFonts");
        int i = 0;
        i = modelManager.FontId;
        fontManager = GameObject.Find("FontManager").GetComponent<FontManager>();
        // print(HourUpUpText.font.name);
        HourUpUpText.font = fontManager.font[i];
        HourUpDownText.font = fontManager.font[i];
        HourDownUpText.font = fontManager.font[i];
        HourDownDownText.font = fontManager.font[i];
        MinuteUpUpText.font = fontManager.font[i];
        MinuteUpDownText.font = fontManager.font[i];
        MinuteDownUpText.font = fontManager.font[i];
        MinuteDownDownText.font = fontManager.font[i];
        SecondUpUpText.font = fontManager.font[i];
        SecondUpDownText.font = fontManager.font[i];
        SecondDownUpText.font = fontManager.font[i];
        SecondDownDownText.font = fontManager.font[i];
        // print(HourUpUpText.font.name);
    }

    public void SetFontsColor()
    {

        // print("SetFontsColor" + colorManager.mycolor[3]);
        // print("SetFontsColor" + Color.red);
        // // return;
        // HourUpUpText.color = colorManager.mycolor[0];
        // HourUpDownText.color = colorManager.mycolor[0];
        // HourDownUpText.color = colorManager.mycolor[0];
        // HourDownDownText.color = colorManager.mycolor[0];
        // MinuteUpUpText.color = colorManager.mycolor[0];
        // MinuteUpDownText.color = colorManager.mycolor[0];
        // MinuteDownUpText.color = colorManager.mycolor[0];
        // MinuteDownDownText.color = colorManager.mycolor[0];
        // SecondUpUpText.color = colorManager.mycolor[0];
        // SecondUpDownText.color = colorManager.mycolor[0];
        // SecondDownUpText.color = colorManager.mycolor[0];
        // SecondDownDownText.color = colorManager.mycolor[0];
        colorManager = GameObject.Find("ColorManager").GetComponent<ColorManager>();

        HourUpUpText.color = colorManager.mycolor[modelManager.FontColorId];
        HourUpDownText.color = colorManager.mycolor[modelManager.FontColorId];
        HourDownUpText.color = colorManager.mycolor[modelManager.FontColorId];
        HourDownDownText.color = colorManager.mycolor[modelManager.FontColorId];
        MinuteUpUpText.color = colorManager.mycolor[modelManager.FontColorId];
        MinuteUpDownText.color = colorManager.mycolor[modelManager.FontColorId];
        MinuteDownUpText.color = colorManager.mycolor[modelManager.FontColorId];
        MinuteDownDownText.color = colorManager.mycolor[modelManager.FontColorId];
        SecondUpUpText.color = colorManager.mycolor[modelManager.FontColorId];
        SecondUpDownText.color = colorManager.mycolor[modelManager.FontColorId];
        SecondDownUpText.color = colorManager.mycolor[modelManager.FontColorId];
        SecondDownDownText.color = colorManager.mycolor[modelManager.FontColorId];

        // SecondDownDownText.color = colorManager.mycolor[modelManager.FontColorId];
    }


    void Awake()
    {
        print("timeManager Awake");
        modelManager = GameObject.Find("ModelManager").GetComponent<ModelManager>();
        fontManager = GameObject.Find("FontManager").GetComponent<FontManager>();
        colorManager = GameObject.Find("ColorManager").GetComponent<ColorManager>();
        // Screen.sleepTimeout = SleepTimeout.SystemSetting;  //关闭手机屏幕常亮(按照手机设置)

    }


    void Start()
    {
        print("timeManager start");
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        IntTime();

        // print("timeManager Awake modelManager.Time24Mode   " + modelManager.Time24Mode);
        // MinuteChangeAnim.enabled = false;
        SetFonts();
        SetFontsColor();
    }

    void Update()
    {
        LogText.text = hour.ToString("00") + ":" + minute.ToString("00") + ":" + second.ToString("00");

        secondControl();
        minuteControl();

        // hourControl();

        hourModeControl();
    }
}

