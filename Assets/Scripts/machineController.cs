//这个脚本是组装后棉花放入指定位置出发动画的




using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class machineController : MonoBehaviour
{
    private AudioSource m_AudioSource;
    public Animator m_Animator;
    // Start is called before the first frame update
    void Start()
    {
        //获取音效audiosource组件
        m_AudioSource=this.GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        //当有物体进入入料口的位置时，判断物体的标签，如果是棉花才会执行操作
        if (other.transform.tag == "Item")
        {
            //物体进入后，将棉花销毁，并开始播放音频，并开始动画
            Destroy(other.transform.gameObject);
            m_AudioSource.Play();
            m_Animator.enabled = true;
            //开始携程，此处的作用是机器出布的动画大概为10s，就在10s后将机器的声音取消
            StartCoroutine(machineBegin());
        }
    }
    IEnumerator machineBegin()
    {
        //等待10s
        yield return new WaitForSeconds(10F);
        //暂停机器的声音
        m_AudioSource.Stop();
        yield break;
    }
}
