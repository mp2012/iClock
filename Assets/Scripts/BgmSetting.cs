using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BgmSetting : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] sound;//闹钟时间

    private UIManager uiManager;
    private ModelManager modelManager;


    public void intUI()
    {
        for (int i = 0; i < sound.Length; i++)
        {
            sound[i].GetComponent<BgmSettingSwitch>().intUI();
        }
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
