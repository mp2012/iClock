using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FontSettingSwitch : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject SwitchOnBtn;
    public GameObject SwitchOffBtn;
    private bool SwitchState;//true显示此闹钟开启，false为设定此时间。
    public int FontId;
    private UIManager uiManager;
    private ModelManager modelManager;
    // private AlarmAudioSetting alarmAudioSetting;
    private FontSetting fontSetting;


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
            modelManager.FontId = FontId;
        }
        else
        {
            SwitchState = false;
            modelManager.FontId = 0;
        }
        SwitchBtnDisplay();
        fontSetting.intUI();
        uiManager.SetFonts();
    }
    public void intUI()
    {
        // print("intUI modelManager.AlmitemId" + modelManager.AlmitemId);
        if (FontId == modelManager.FontId)
        {
            SwitchState = true;
        }
        else
        {
            SwitchState = false;
        }
        SwitchBtnDisplay();
        print("modelManager.FontId:  " + modelManager.FontId);
    }
    void Awake()
    {
        uiManager = GameObject.Find("UIManager").GetComponent<UIManager>();
        modelManager = GameObject.Find("ModelManager").GetComponent<ModelManager>();
        fontSetting = GameObject.Find("FontSettingWin").GetComponent<FontSetting>();
        intUI();
    }
    void Start()
    {
    }
    void Update()
    {
    }
}
