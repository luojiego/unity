using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MainObject : MonoBehaviour
{
    // Start is called before the first frame update
    Color[] colors = {Color.red, new Color(255,255,255), Color.yellow, Color.green, new Color(0,255,255), Color.blue, new Color(128,0,128)};

    KeyCode[] keyDown = {KeyCode.R, KeyCode.W, KeyCode.Y, KeyCode.G, KeyCode.C, KeyCode.B, KeyCode.P};

    int index = 0;

    public AudioClip success;
    public AudioClip failed;
    void Start()
    {
        // Debug.Log("Hello World");
        for (var i = 0; i < this.transform.childCount; i++)
        {
            var child = this.transform.GetChild(i);
            child.GameObject().SetActive(false);
            var m = child.GameObject().GetComponent<MeshRenderer>();
            m.materials[0].color = colors[i]; 
            Debug.Log(child.name + "color: " + m.materials[0].color);
        }

        this.transform.GetChild(index).GameObject().SetActive(true);
        
        // 启动定时器
        this.Invoke("inputTimeOut", 3);
    }

    private void inputTimeOut()
    {
        // 将当前显示的球隐藏
        var child = this.transform.GetChild(index);
        child.GameObject().SetActive(false);

        // 播放错误音效
        this.GetComponent<AudioSource>().clip = failed;
        this.GetComponent<AudioSource>().Play();

        // 随机显示一个球
        index = UnityEngine.Random.Range(0, this.transform.childCount);
        this.transform.GetChild(index).GameObject().SetActive(true);

        this.Invoke("inputTimeOut", 3);
        // index = (index + 1) % this.transform.childCount;
        // this.transform.GetChild(index).GameObject().SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        // 获取键盘按下事件
        if (Input.GetKeyDown(keyDown[index]))
        {
            // 按下的是正确的键
            Debug.Log("按下的是正确的键");
            this.transform.GetChild(index).GameObject().SetActive(false);
            this.GetComponent<AudioSource>().clip = success;
            this.GetComponent<AudioSource>().Play();

            // 随机显示一个球
            index = UnityEngine.Random.Range(0, this.transform.childCount);
            this.transform.GetChild(index).GameObject().SetActive(true);

            // 开启超时定时器
            this.CancelInvoke();
            this.Invoke("inputTimeOut", 3);
        }
        else if (Input.anyKeyDown)
        {
            // 按下的是错误的键
            Debug.Log("按下的是错误的键");
            this.GetComponent<AudioSource>().clip = failed;
            this.GetComponent<AudioSource>().Play();
        }
    }
}
