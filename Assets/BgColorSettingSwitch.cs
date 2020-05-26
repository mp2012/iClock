using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BgColorSettingSwitch : MonoBehaviour
{
     // Start is called before the first frame update
    public GameObject SwitchOnBtn;
    public GameObject SwitchOffBtn;
    private bool SwitchState;//true显示此闹钟开启，false为设定此时间。
    public int BgColorId;
    private UIManager uiManager;
    private ModelManager modelManager;
    // private AlarmAudioSetting alarmAudioSetting;
    private BgColorSetting bgColorSetting;

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
            modelManager.BgColorId = BgColorId;
        }
        else
        {
            SwitchState = false;
            modelManager.BgColorId = 0;
        }
        SwitchBtnDisplay();
        bgColorSetting.intUI();

        print("modelManager.BgColorId:" + modelManager.BgColorId);
        uiManager.SetBgColor();
        
    }
    public void intUI()
    {
        // print("intUI modelManager.AlmitemId" + modelManager.AlmitemId);
        if (BgColorId == modelManager.BgColorId)
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
        bgColorSetting = GameObject.Find("BgColorSettingWin").GetComponent<BgColorSetting>();
        intUI();
    }
    void Start()
    {
    }
    void Update()
    {
    }
}
