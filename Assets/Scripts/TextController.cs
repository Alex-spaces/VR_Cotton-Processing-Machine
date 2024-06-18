using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//����ű��Ǹ��Ľ����ı������ֺ�����
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
    //�����˸������ֵķ�����ʹ�÷�����Ҫ�ṩһ��������ֵ��һһ��Ӧ
    public void insText(int indexText)
    {
        //��ȡ�ı����
        tarText = this.GetComponent<Text>();
        //��ȡ�������
        tarAudioSource = this.GetComponent<AudioSource>();
        //�������ֺ�����
        tarText.text= textMe[indexText];
        tarAudioSource.clip = textClip[indexText];
        //��������
        tarAudioSource.Play();
    }
}
