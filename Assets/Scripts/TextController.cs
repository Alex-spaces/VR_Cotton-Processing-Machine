using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//这个脚本是更改介绍文本的文字和语音
public class TextController : MonoBehaviour
{
    public string[] textMe;
    public AudioClip[] textClip; 

    private Text tarText;
    private AudioSource tarAudioSource;
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //创建了更改文字的方法，使用方法需要提供一个整数数值来一一对应
    public void insText(int indexText)
    {
        //获取文本组件
        tarText = this.GetComponent<Text>();
        //获取语音组件
        tarAudioSource = this.GetComponent<AudioSource>();
        //更改文字和语音
        tarText.text= textMe[indexText];
        tarAudioSource.clip = textClip[indexText];
        //播放语音
        tarAudioSource.Play();
    }
}
