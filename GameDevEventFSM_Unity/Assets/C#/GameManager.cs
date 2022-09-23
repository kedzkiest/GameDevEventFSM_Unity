using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditorInternal;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Miner miner;
    private SingletonMessage SMI;

    int len = 0;
    int frames_counter = 0;
    private bool enabled_to_skip = false;

    public DialogManager dialogManager;

    // Start is called before the first frame update
    void Start()
    {
        miner = new Miner(0);
        SMI = SingletonMessage.Instance();
        dialogManager.SetText("( Press Space Key to Continue )");
    }

    private bool isCalledOnce = false;
    // Update is called once per frame
    void Update()
    {
        frames_counter++;

        if(Input.GetKeyDown(KeyCode.Space) && enabled_to_skip)
        {
            frames_counter = 0;
            //enabled_to_skip = false;
            isCalledOnce = false;

            // if message buffer is empty, then allow to update
            if (SMI.CheckEmpty())
            {
                miner.Update();
            }

            dialogManager.SetText(SMI.GetVal());
            SMI.DelFirstVal();
        }

        
        len = SMI.GetVal().Length;
        if(frames_counter >= len * 3.5)
        {
            enabled_to_skip = true;
        }
        

        if (!isCalledOnce)
        {
            dialogManager.ClearDialogText();
            isCalledOnce = true;
            dialogManager.StartType();
        }
    }
}
