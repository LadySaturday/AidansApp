using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroTexts : MonoBehaviour
{
    DialogManager dialog;
    private Animator anim;
    private bool run=false;
    // Start is called before the first frame update
    void Start()
    {
        dialog = gameObject.GetComponent<DialogManager>();
        anim = GetComponent<Animator>();
        StartCoroutine(introSequence());
    }
    private void Update()
    {
        if (run)
        {
            
            float step = 3 * Time.deltaTime;

            // move sprite towards the target location

            transform.position = Vector2.MoveTowards(transform.position, new Vector2(10, transform.position.y), step);

            if (transform.position.x == 10)
            {
                SceneLoading.SceneManageEnd(3);
            }
        }
        
    }

    IEnumerator introSequence()
    {
        yield return new WaitForSeconds(2);
        dialog.ShowDialog("Ah jeez, Aidan. It sure is nice to be a trash rat!", 0);
        yield return new WaitUntil(() => dialog.okToPass == true);//waits until sentence is over
        dialog.ShowDialog("It sure is!", 1);
        yield return new WaitUntil(() => dialog.okToPass == true);//waits until sentence is over

        dialog.ShowDialog("Tell ya' what: I'm gonna head to the 10th block over. On my way, I'll collect as much trash as I can.  Meet me there, and whoever collects more trash WINS!", 0);
        yield return new WaitUntil(() => dialog.okToPass == true);//waits until sentence is over
        dialog.ShowDialog("You're ON!!!!", 1);
        yield return new WaitUntil(() => dialog.okToPass == true);//waits until sentence is over

        anim.SetBool("finished", true);
        run = true;


    }
}
