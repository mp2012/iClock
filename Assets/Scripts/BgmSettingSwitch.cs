using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BgmSettingSwitch : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject SwitchOnBtn;
    public GameObject SwitchOffBtn;
    private bool SwitchState;//true显示此闹钟开启，false为设定此时间。
    public int clipId;
    private UIManager uiManager;
    private ModelManager modelManager;
    // private AlarmAudioSetting alarmAudioSetting;
    private BgmSetting bgmSetting;
    private AudioManager audioManager;


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
            modelManager.BgmClipId = clipId;
            audioManager.PlayBgm();
        }
        else
        {
            SwitchState = false;
            modelManager.BgmClipId = -1;
            audioManager.StopBgm();
        }
        SwitchBtnDisplay();
        // alarmAudioSetting.intUI();
        bgmSetting.intUI();
    }
    public void intUI()
    {
        // print("intUI modelManager.AlmClipId" + modelManager.AlmClipId);
        if (clipId == modelManager.BgmClipId)
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
        // alarmAudioSetting = GameObject.Find("AlarmAudioSettingWin").GetComponent<AlarmAudioSetting>();
        bgmSetting = GameObject.Find("BgmSettingWin").GetComponent<BgmSetting>();
        audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();


        intUI();
    }
    void Start()
    {
    }
    void Update()
    {
    }
}
