using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ImageDisplay : MonoBehaviour
{
    public Sprite[] images;
    public Image display;

    private int count;
    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        if(SceneManager.GetActiveScene().name!="MainMenu")
        Next();
    }

    public void Next()
    {
        
            display.sprite = images[count];
            display.SetNativeSize();
            display.preserveAspect = true;
        

        if (count < images.Length - 1)
            count++;
        else
            count = 0;

    }

    public void Back()
    {
        if (count - 1 >= 0)
            count--;
        else
            count = images.Length - 1;

        display.sprite = images[count];
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
