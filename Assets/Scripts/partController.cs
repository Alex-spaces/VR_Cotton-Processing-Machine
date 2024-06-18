using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


//����ű�����������Ϸ��ͷ����װʱ���߼���
public class partController : MonoBehaviour
{
    public GameObject desObject;
    private bool allFinish;
    // Start is called before the first frame update
    void Start()
    {
        //�ڽű���ʼʱ����Ŀ������(Ŀ���������ƴװʱ�ı��壬���ֱ��϶����Ǹ�)������������뵱�ֱ��϶�ʱ���ѵ�ǰ����(Ҳ����������壬�������ֱ��϶������Ŀ��λ�õ���ɫ����)�򿪣����ֵ�ʱ��ر�

        desObject.GetComponent<XRGrabInteractable>().selectEntered.AddListener(delegate
        {
            this.transform.gameObject.SetActive(true);
        });
        desObject.GetComponent<XRGrabInteractable>().selectExited.AddListener(closeObj);
        //�������֮��Ͱ��Լ��ر�,֮���϶�Ŀ�������򿪵�
        this.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //��λ�÷Ŷ���֮�󣬽�Ŀ�������λ�ú���ת�Ƕ��������ɫ����ȷλ�ö���
        if (allFinish)
        {
            desObject.transform.position = this.transform.position;
            desObject.transform.eulerAngles = this.transform.eulerAngles;
        }
        
    }
    
    private void OnTriggerEnter(Collider other)
    {
        //���϶������������ȷ����λ�ô����߼�
        if (other.transform.gameObject == desObject)
        {
            //��ItemPickController�ű���itemNum����+1
            this.transform.parent.parent.parent.GetComponent<ItemPickController>().itemNum++;
            allFinish = true;
            //�ر��϶��������ײ�壬�϶���������ر��Լ��Ĳ�����ʾ����ײ��
            desObject.GetComponent<BoxCollider>().enabled = false;
            desObject.GetComponent<XRGrabInteractable>().enabled = false;
            this.GetComponent<MeshRenderer>().enabled = false;
            this.GetComponent<BoxCollider>().enabled = false;
        }
    }
   
    public void closeObj(SelectExitEventArgs args)
    {
        StartCoroutine(closeDes());
    }

    //�Ϸ��ļ��������������ֱ��ɿ����������ͱ��رգ����������ᵼ��һ�����������͹ر��ˣ���û�취�����Ϸ����ж���
    IEnumerator closeDes()
    {
        yield return new WaitForSeconds(0.1f);
        this.gameObject.SetActive(false);
    }
}
