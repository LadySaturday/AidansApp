using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoading : MonoBehaviour
{
    public static void SceneManageStatic(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void SceneManage(string scene)
    {
            SceneManager.LoadScene(scene);
    }
}
