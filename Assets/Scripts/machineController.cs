//����ű�����װ���޻�����ָ��λ�ó���������




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
        //��ȡ��Чaudiosource���
        m_AudioSource=this.GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        //��������������Ͽڵ�λ��ʱ���ж�����ı�ǩ��������޻��Ż�ִ�в���
        if (other.transform.tag == "Item")
        {
            //�������󣬽��޻����٣�����ʼ������Ƶ������ʼ����
            Destroy(other.transform.gameObject);
            m_AudioSource.Play();
            m_Animator.enabled = true;
            //��ʼЯ�̣��˴��������ǻ��������Ķ������Ϊ10s������10s�󽫻���������ȡ��
            StartCoroutine(machineBegin());
        }
    }
    IEnumerator machineBegin()
    {
        //�ȴ�10s
        yield return new WaitForSeconds(10F);
        //��ͣ����������
        m_AudioSource.Stop();
        yield break;
    }
}
