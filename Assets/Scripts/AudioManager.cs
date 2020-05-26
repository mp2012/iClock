using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioClip[] almClip;
    public AudioClip[] bgmClip;
    public AudioSource bgmAudio;//
    private ModelManager modelManager;

    public void PlayAlamAudio()
    {
        print("modelManager.AlmClipId  : " + modelManager.AlmClipId);
        if (modelManager.AlmClipId != -1)
        {
            AudioSource.PlayClipAtPoint(almClip[modelManager.AlmClipId], transform.position);
        }
    }
    public void PlayBgm()
    {
        // print("modelManager.BgmClipId  : " + modelManager.BgmClipId);
        if (modelManager.BgmClipId != -1)
        {
            // AudioSource.PlayClipAtPoint(bgmClip[modelManager.BgmClipId], transform.position);
            bgmAudio.clip = bgmClip[modelManager.BgmClipId];
            bgmAudio.Play();
        }
    }
    public void StopBgm()
    {
        // print("modelManager.BgmClipId  : " + modelManager.BgmClipId);
        bgmAudio.clip = bgmClip[0];
        bgmAudio.Stop();
    }
    void Awake()
    {
        modelManager = GameObject.Find("ModelManager").GetComponent<ModelManager>();
    }
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {

    }
}
