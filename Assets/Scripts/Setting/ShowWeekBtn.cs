using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowWeekBtn : MonoBehaviour
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
        // print("ShowWeekBtn: modelManager.ShowWeek:" + modelManager.ShowWeek + "   SwitchState:" + SwitchState);
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
        setShowWeekMode();
        uiManager.intUI();
    }
    void setShowWeekMode()
    {
        modelManager.ShowWeek = SwitchState;
    }

    void intUI()
    {
        uiManager = GameObject.Find("UIManager").GetComponent<UIManager>();
        modelManager = GameObject.Find("ModelManager").GetComponent<ModelManager>();

        // print("intUI modelManager.ShowWeek" + modelManager.ShowWeek);
        SwitchState = modelManager.ShowWeek;
        // print("~~~~~~~ShowWeekBtn: modelManager.ShowWeek:" + modelManager.ShowWeek + "   SwitchState:" + SwitchState);
        SwitchBtnDisplay();
    }
    void Awake()
    {

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
