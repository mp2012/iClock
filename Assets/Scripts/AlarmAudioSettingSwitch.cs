using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlarmAudioSettingSwitch : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject SwitchOnBtn;
    public GameObject SwitchOffBtn;
    private bool SwitchState;//true显示此闹钟开启，false为设定此时间。
    public int clipId;
    private UIManager uiManager;
    private ModelManager modelManager;
    private AlarmAudioSetting alarmAudioSetting;


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
            modelManager.AlmClipId = clipId;
        }
        else
        {
            SwitchState = false;
            modelManager.AlmClipId = -1;
        }
        SwitchBtnDisplay();
        alarmAudioSetting.intUI();
    }
    public void intUI()
    {
        modelManager = GameObject.Find("ModelManager").GetComponent<ModelManager>();

        print("AlarmAudioSettingSwitch intUI modelManager.AlmClipId" + modelManager.AlmClipId);

        if (clipId == modelManager.AlmClipId)
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

    }
    void Start()
    {
        uiManager = GameObject.Find("UIManager").GetComponent<UIManager>();
        modelManager = GameObject.Find("ModelManager").GetComponent<ModelManager>();
        alarmAudioSetting = GameObject.Find("AlarmAudioSettingWin").GetComponent<AlarmAudioSetting>();
        intUI();
    }
    void Update()
    {
    }
}
