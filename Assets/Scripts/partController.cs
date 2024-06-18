using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


//这个脚本用来控制游戏开头的组装时的逻辑，
public class partController : MonoBehaviour
{
    public GameObject desObject;
    private bool allFinish;
    // Start is called before the first frame update
    void Start()
    {
        //在脚本开始时，给目标物体(目标物体就是拼装时的本体，你手柄拖动的那个)加入监听，加入当手柄拖动时，把当前物体(也就是这个物体，就是你手柄拖动后出现目标位置的绿色物体)打开，松手的时候关闭

        desObject.GetComponent<XRGrabInteractable>().selectEntered.AddListener(delegate
        {
            this.transform.gameObject.SetActive(true);
        });
        desObject.GetComponent<XRGrabInteractable>().selectExited.AddListener(closeObj);
        //加完监听之后就把自己关闭,之后拖动目标物体会打开的
        this.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //当位置放对了之后，将目标物体的位置和旋转角度与这个绿色的正确位置对齐
        if (allFinish)
        {
            desObject.transform.position = this.transform.position;
            desObject.transform.eulerAngles = this.transform.eulerAngles;
        }
        
    }
    
    private void OnTriggerEnter(Collider other)
    {
        //当拖动物体进入了正确物体位置触发逻辑
        if (other.transform.gameObject == desObject)
        {
            //将ItemPickController脚本的itemNum数量+1
            this.transform.parent.parent.parent.GetComponent<ItemPickController>().itemNum++;
            allFinish = true;
            //关闭拖动物体的碰撞体，拖动组件，并关闭自己的材质显示和碰撞体
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

    //上方的监听，理论上是手柄松开手这个物体就被关闭，但是这样会导致一松手这个物体就关闭了，就没办法进行上方的判定了
    IEnumerator closeDes()
    {
        yield return new WaitForSeconds(0.1f);
        this.gameObject.SetActive(false);
    }
}
