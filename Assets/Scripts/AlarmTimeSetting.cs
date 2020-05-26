using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlarmTimeSetting : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Min5;//闹钟时间
    public GameObject Min10;
    public GameObject Min15;
    public GameObject Min20;
    public GameObject Min25;
    public GameObject Min30;
    public GameObject Min35;
    public GameObject Min40;
    public GameObject Min45;
    public GameObject Min50;
    public GameObject Min55;
    public GameObject Min60;

    private int AlamTime;
    private UIManager uiManager;
    private ModelManager modelManager;


    public void intUI()
    {
        Min5.GetComponent<TomatoClockSwitch>().intUI();
        Min10.GetComponent<TomatoClockSwitch>().intUI();
        Min15.GetComponent<TomatoClockSwitch>().intUI();
        Min20.GetComponent<TomatoClockSwitch>().intUI();
        Min25.GetComponent<TomatoClockSwitch>().intUI();
        Min30.GetComponent<TomatoClockSwitch>().intUI();
        Min35.GetComponent<TomatoClockSwitch>().intUI();
        Min40.GetComponent<TomatoClockSwitch>().intUI();
        Min45.GetComponent<TomatoClockSwitch>().intUI();
        Min50.GetComponent<TomatoClockSwitch>().intUI();
        Min55.GetComponent<TomatoClockSwitch>().intUI();
        Min60.GetComponent<TomatoClockSwitch>().intUI();
    }

    void Start()
    {
        // SwitchState = false;
        uiManager = GameObject.Find("UIManager").GetComponent<UIManager>();
        modelManager = GameObject.Find("ModelManager").GetComponent<ModelManager>();
        intUI();
    }

    // Update is called once per frame
    void Update()
    {
        // intUI();
    }
}
