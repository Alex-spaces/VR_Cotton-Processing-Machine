using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

//这个脚本是控制外描边的，主要作用是比如齿轮有三个，对准其中一个就可以让同类别的外描边都打开
public class itemController : MonoBehaviour
{
    public bool outlineStatus;
    public Outline[] outLines;

    public itemController[] itemControllers;
    public int textIndex;
    public TextController textController;
    // Start is called before the first frame update
    void Start()
    {
        outLines=this.GetComponentsInChildren<Outline>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void closeOutline()
    {
        for(int i=0;i< outLines.Length; i++)
        {
            outLines[i].enabled = false;
        }
    }
    public void openOutline()
    {
        for(int c=0;c< itemControllers.Length; c++)
        {
            itemControllers[c].closeOutline();
        }
        for (int i = 0; i < outLines.Length; i++)
        {
            outLines[i].enabled =true;
        }

    }
}
