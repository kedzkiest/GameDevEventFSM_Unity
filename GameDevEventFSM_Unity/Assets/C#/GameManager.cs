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
    private string msgText;

    public GameObject home_morning;
    public GameObject home_night;
    public GameObject mine;
    public GameObject bank;
    private GameObject currentBG;

    // Start is called before the first frame update
    void Start()
    {
        miner = new Miner(0);
        SMI = SingletonMessage.Instance();
        dialogManager.SetText("( Press Space Key to Continue )");
        currentBG = home_morning;
    }

    private bool isCalledOnce = false;
    // Update is called once per frame
    void Update()
    {
        frames_counter++;

        if(Input.GetKeyDown(KeyCode.Space) && enabled_to_skip)
        {
            frames_counter = 0;
            enabled_to_skip = false;
            isCalledOnce = false;

            // if message buffer is empty, then allow to update
            if (SMI.CheckEmpty())
            {
                miner.Update();
            }

            msgText = SMI.GetVal();
            if(msgText.Contains("What a fantastic nap! Time to find more gold!"))
            {
                currentBG.SetActive(false);
                currentBG = home_morning;
                currentBG.SetActive(true);
            }
            if(msgText.Contains("( Walking to the goldmine )"))
            {
                currentBG.SetActive(false);
                currentBG = mine;
                currentBG.SetActive(true);
            }
            if(msgText.Contains("( Going to the bank )"))
            {
                currentBG.SetActive(false);
                currentBG = bank;
                currentBG.SetActive(true);
            }
            if(msgText.Contains("( Walking home )"))
            {
                currentBG.SetActive(false);
                currentBG = home_night;
                currentBG.SetActive(true);
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
