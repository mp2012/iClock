using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Time24ModeSwitchBtn : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject SwitchOnBtn;
    public GameObject SwitchOffBtn;
    public bool SwitchState;
    // public int Time;
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
        Hour24or12Mode();
        uiManager.intUI();
        // print("modelManager.Time24Mode:" + modelManager.Time24Mode);
    }
    public void Hour24or12Mode()
    {
        modelManager.Time24Mode = SwitchState;
    }
    void intUI()
    {
        uiManager = GameObject.Find("UIManager").GetComponent<UIManager>();
        modelManager = GameObject.Find("ModelManager").GetComponent<ModelManager>();
        SwitchState = modelManager.Time24Mode;
        SwitchBtnDisplay();
    }

    void Start()
    {
        // print("Time24ModeSwitchBtn Start");
        intUI();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
