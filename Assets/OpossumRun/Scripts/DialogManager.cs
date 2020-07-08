using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    public Text [] textDisplay;
    private string sentences;
    private int index;
    public float typingSpeed;
    public GameObject [] dialogPanel;
    public bool okToPass;



    public void ShowDialog(string sentence, int nicOrAid)
    {
        
        Reset(nicOrAid);
        
        sentences = sentence;
        dialogPanel[nicOrAid].SetActive(true);
        StartCoroutine(Type(nicOrAid));
    }

    void Reset(int nicOrAid)
    {
        
        sentences = null;
        textDisplay[nicOrAid].text = "";
        index = 0;

        dialogPanel[nicOrAid].SetActive(false);
    }

    IEnumerator Type(int nicOrAid)
    {
        okToPass = false;
        foreach (char letter in sentences.ToCharArray())
        {
            textDisplay[nicOrAid].text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }

        yield return new WaitForSeconds(3);
        okToPass = true;
        Reset(nicOrAid);
    }

    
}
