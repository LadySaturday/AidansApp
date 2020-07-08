using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoading : MonoBehaviour
{
    public static void SceneManage(int stressLevel)
    {
        if (stressLevel == 0)
            SceneManager.LoadScene("MainMenu");
        else if (stressLevel == 1)
            SceneManager.LoadScene("Level1");
        else if (stressLevel == 2)
            SceneManager.LoadScene("Level2");
        else if (stressLevel == 3)
            SceneManager.LoadScene("Level3");
        else if (stressLevel == 4)
            SceneManager.LoadScene("Level4");
        else if (stressLevel == 5)
            SceneManager.LoadScene("Level5");
    }
}
