using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI DialogText;

    [TextArea(5, 5)]
    [SerializeField] private string msgText;

    private float msgSpeed = 0.01f;

    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        DialogText.text = "";
        audioSource = GetComponent<AudioSource>();
    }

    IEnumerator TypeDisplay()
    {
        audioSource.Play();

        foreach(char item in msgText.ToCharArray())
        {
            DialogText.text += item;
            yield return new WaitForSeconds(msgSpeed);
        }
        
        audioSource.Stop();
    }

    public void SetText(string text)
    {
        msgText = text;
    } 

    public void StartType()
    {
        StartCoroutine(TypeDisplay());
    }

    public void ClearDialogText()
    {
        DialogText.text = "";
        StopAllCoroutines();
    }
}
