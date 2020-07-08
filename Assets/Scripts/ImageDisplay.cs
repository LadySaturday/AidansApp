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

  

}
