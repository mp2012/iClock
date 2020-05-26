using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TomatoClockSwitch : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject SwitchOnBtn;
    public GameObject SwitchOffBtn;
    private bool SwitchState;//true显示此闹钟开启，false为设定此时间。
    public int Time;
    private UIManager uiManager;
    private ModelManager modelManager;
    private AlarmTimeSetting alarmTimeSetting;

    public void SwitchBtnDisplay()
    {
        if (SwitchState == false)
        {
            SwitchOffBtn.SetActive(true);
            SwitchOnBtn.SetActive(false);
        }
        else
        {
            SwitchOffBtn.SetActive(false);
            SwitchOnBtn.SetActive(true);
        }
    }
    public void SwitchBtnClick()
    {
        if (SwitchState == false)
        {
            SwitchState = true;
            modelManager.TomatoClockAlamTime = Time;
            modelManager.TomatoClockAlamStartTime = DateTime.Now;
            print(DateTime.Now);
            print(modelManager.TomatoClockAlamStartTime);
        }
        else
        {
            SwitchState = false;
            modelManager.TomatoClockAlamTime = -1;
        }
        SwitchBtnDisplay();

        uiManager.intUI();
        alarmTimeSetting.intUI();
        print("TomatoClockSwitch: modelManager.TomatoClockAlamTime:" + modelManager.TomatoClockAlamTime + "   SwitchState:" + SwitchState);
    }
    public void intUI()
    {
        // print("intUI modelManager.ShowSecondMode" + modelManager.ShowSecondMode);
        if (Time == modelManager.TomatoClockAlamTime)
        {
            SwitchState = true;
        }
        else
        {
            SwitchState = false;
        }
        SwitchBtnDisplay();
    }
    void Awake()
    {
        uiManager = GameObject.Find("UIManager").GetComponent<UIManager>();
        modelManager = GameObject.Find("ModelManager").GetComponent<ModelManager>();
        alarmTimeSetting = GameObject.Find("AlarmTimeSettingWin").GetComponent<AlarmTimeSetting>();
        intUI();
    }
    void Start()
    {
        // SwitchState = false;

    }
    // Update is called once per frame
    void Update()
    {
        // intUI();
    }
}
