using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickController : MonoBehaviour
{
    public int itemNum;
    public GameObject closeObj;
    public GameObject openObj;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    //�����϶������һ����ʮ����ʮ�������������һ�������Ļ���
    void Update()
    {
        if (itemNum==10)
        {
            openObj.SetActive(true);
            closeObj.SetActive(false);
        }
    }
}
