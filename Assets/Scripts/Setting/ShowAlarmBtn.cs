using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowAlarmBtn : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject SwitchOnBtn;
    public GameObject SwitchOffBtn;
    private bool SwitchState;//true显示秒，false只显示分时。
    private UIManager uiManager;
    private ModelManager modelManager;
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
        // print("ShowSecondBtn: modelManager.ShowSecondMode:" + modelManager.ShowSecondMode + "   SwitchState:" + SwitchState);
    }
    public void SwitchBtnClick()
    {
        if (SwitchState == false)
        {
            SwitchState = true;
        }
        else
        {
            SwitchState = false;
        }
        SwitchBtnDisplay();
        setShowAlarmMode();
        uiManager.intUI();
    }
    void setShowAlarmMode()
    {
        modelManager.ShowAlarm = SwitchState;
    }

    void intUI()
    {
        print("intUI modelManager.ShowAlarm" + modelManager.ShowAlarm);
        SwitchState = modelManager.ShowAlarm;
        SwitchBtnDisplay();
    }
    void Awake()
    {
        uiManager = GameObject.Find("UIManager").GetComponent<UIManager>();
        modelManager = GameObject.Find("ModelManager").GetComponent<ModelManager>();
    }
    void Start()
    {
        // SwitchState = false;
        intUI();
    }

    // Update is called once per frame
    void Update()
    {
        // intUI();
    }
}
