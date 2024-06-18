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

    //所有拖动的零件一共有十个，十个集齐则打开另外一个完整的机器
    void Update()
    {
        if (itemNum==10)
        {
            openObj.SetActive(true);
            closeObj.SetActive(false);
        }
    }
}
