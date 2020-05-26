using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FontSetting : MonoBehaviour
{
    // Start is called before the first frame update
    private ModelManager modelManager;
    public GameObject[] font;//字体开关选项们

    public void intUI()//初始化本界面开关
    {
        for (int i = 0; i < font.Length; i++)
        {
            font[i].GetComponent<FontSettingSwitch>().intUI();
        }
    }

    void Awake()
    {
        
    }

    void Start()
    {
        modelManager = GameObject.Find("ModelManager").GetComponent<ModelManager>();
        intUI();
        print("modelManager.FontId:  " + modelManager.FontId);

    }

    // Update is called once per frame
    void Update()
    {

    }
}
