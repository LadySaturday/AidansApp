using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ImageDisplay : MonoBehaviour
{
    public Sprite[] images;
    public Image display;
    private int position;


    void Start()
    {
        position = 0;
        if(SceneManager.GetActiveScene().name!="MainMenu")
        Next();
    }

    public void Next()
    {
        
            display.sprite = images[position];
            display.SetNativeSize();
            display.preserveAspect = true;
        

        if (position < images.Length - 1)
            position++;
        else
            position = 0;

    }

    public void Back()
    {
        if (position - 1 >= 0)
            position--;
        else
            position = images.Length - 1;

        display.sprite = images[position];
            display.SetNativeSize();
            display.preserveAspect = true;
                
    }

    public void SceneManage(int stressLevel)
    {
        if (stressLevel == 0)
            SceneManager.LoadScene("MainMenu");
        else if (stressLevel == 1)
            SceneManager.LoadScene("Level1");
        else if (stressLevel == 2)
            SceneManager.LoadScene("Level2");
        else if (stressLevel == 3)
            SceneManager.LoadScene("Level3");
    }

}
