using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class trash : MonoBehaviour
{
    public static int trashCount;
   
    // Update is called once per frame
    void Update()
    {
        if(GameObject.FindGameObjectWithTag("Player")!=null)
        trashCount = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().trash;

        if(SceneManager.GetActiveScene().name=="PossumRun_Win")
        {
            GameObject.FindGameObjectWithTag("FinalScore").GetComponent<Text>().text =trashCount.ToString();
        }
    }
}
