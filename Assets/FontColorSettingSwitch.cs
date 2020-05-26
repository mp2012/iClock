using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FontColorSettingSwitch : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject SwitchOnBtn;
    public GameObject SwitchOffBtn;
    private bool SwitchState;//true显示此闹钟开启，false为设定此时间。
    public int FontColorId;
    private UIManager uiManager;
    private ModelManager modelManager;
    // private AlarmAudioSetting alarmAudioSetting;
    private FontColorSetting fontColorSetting;

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
            modelManager.FontColorId = FontColorId;
        }
        else
        {
            SwitchState = false;
            modelManager.FontColorId = 0;
        }
        SwitchBtnDisplay();
        fontColorSetting.intUI();

        print("modelManager.FontColorId:" + modelManager.FontColorId);
        uiManager.SetFontsColor();
        
    }
    public void intUI()
    {
        // print("intUI modelManager.AlmitemId" + modelManager.AlmitemId);
        if (FontColorId == modelManager.FontColorId)
        {
            SwitchState = true;
        }
        else
        {
            SwitchState = false;
        }
        SwitchBtnDisplay();
        // print("modelManager.FontColorId:  " + modelManager.FontColorId);
    }
    void Awake()
    {
        uiManager = GameObject.Find("UIManager").GetComponent<UIManager>();
        modelManager = GameObject.Find("ModelManager").GetComponent<ModelManager>();
        fontColorSetting = GameObject.Find("FontColorSettingWin").GetComponent<FontColorSetting>();
        intUI();
    }
    void Start()
    {
    }
    void Update()
    {
    }
}
