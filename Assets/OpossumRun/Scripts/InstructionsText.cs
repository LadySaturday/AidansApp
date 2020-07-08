using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstructionsText : MonoBehaviour
{
    public GameObject instruction;
    private Text instructionText;
    private float textTime=3*0.01f;//the time for which text is displayed on screen

    private void Start()
    {
        instructionText = instruction.GetComponent<Text>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            switch (gameObject.tag)
            {
                case ("jump"):
                    textOn("Tap anywhere to jump over obstacles and holes!");


                    break;
                case ("collect"):

                   textOn( "Walk over yummy trash to collect it!");

                    break;
                case ("stomp"):
                    textOn( "Stomp on greedy coons to get more points!");

                    break;
            }

        }
        
    }

    void textOn(string instructions)
    {
        Time.timeScale = 0.01f;
        instruction.SetActive(true);
        instructionText.GetComponent<Text>().text = instructions;
        Invoke("textOff", textTime);
    }

    void textOff()
    {
        Time.timeScale = 1;
        instruction.SetActive(false);
        Destroy(gameObject);
    }
}
