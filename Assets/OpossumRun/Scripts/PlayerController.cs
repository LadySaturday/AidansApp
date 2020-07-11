
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    //jump variables
    public float jumpSpeed = 8f;
    private bool grounded;


    private Rigidbody2D rigidBody;
    private Animator anim;


    public GameObject trashDisplay;//should move this to canvas script
    public int trash;

    //speed variations
    private float playerSpeed;
    private float playerNormalSpeed = 2;
    private float playerSlowSpeed = 0.5f;
    private float playerMaxSpeed = 4;

    //audio
    private new AudioSource audio;
    public AudioClip die;
    public AudioClip jump;
    public AudioClip pickup;

    //touch variables
    private float TouchDuration = 0.01f;
    bool touching = false;
    float totalDownTime = 0;
    private int touchCount;
    private float maxDoubleTapTime = 0.3f;
    private float currentDoubleTapTime;


    // Use this for initialization
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        move();
        touchCheck();
  
    }

    private void touchCheck()
    {
        if (!Input.anyKey&&playerSpeed!=playerMaxSpeed)//nothing is touched. Player speed is normal
        {
            playerSpeed = playerNormalSpeed;
            anim.speed = 1;
        }
            
        if (Input.anyKeyDown)//the first time a button is pressed
        {
            totalDownTime = Time.deltaTime;//capture the time
            touching = true;
            totalDownTime = 0;//reset time
            
            

            touchCount++;
            if(touchCount==1)
            {
                currentDoubleTapTime = Time.fixedTime;
            }

            else if (touchCount == 2)
            {
                touchCount = 0;
                if ((Time.fixedTime- currentDoubleTapTime) < maxDoubleTapTime)
                {
                    StartCoroutine(doubleTap());
                }
                   
                //call double tap
            }

            
        }
        if (touching && Input.anyKey)
        {
            totalDownTime += Time.deltaTime;//accumulate time when button held

            if (totalDownTime >= TouchDuration &&grounded)// if button held for long time, long press
            {
                longPress();//slow time
            }
            else if (grounded )//jump
            {
                onePress();
            }



        }
        
    }

    private void longPress()
    {
        touching = false;//long press activated
                         //slow down possum speed
        playerSpeed = playerSlowSpeed;
        totalDownTime = 0;//reset time
        anim.speed = playerSlowSpeed;
        return;
    }

    private void onePress()
    {
        grounded = false;
        rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpSpeed);
        if (Time.timeScale == 1)
        {
            audio.clip = jump;
            audio.Play();
        }
    }

    IEnumerator doubleTap()
    {

        playerSpeed = playerMaxSpeed;
        anim.speed = playerMaxSpeed;
       yield return new WaitForSeconds (2);
        playerSpeed = playerNormalSpeed;
        anim.speed = 1;
    }

    private void move()
    {
        transform.position += Vector3.right * playerSpeed * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground") grounded = true;
        else if (collision.gameObject.tag == "Obstacle")
            StartCoroutine(death());
        else if (collision.gameObject.tag == "Coon")
        {
            grounded = false;
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpSpeed);
        }
            
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Trash"){
            trash++;
            audio.clip = pickup;
            audio.Play();
            Destroy(collision.gameObject);
            trashDisplay.GetComponent<Text>().text = trash.ToString();
        }
        else if (collision.gameObject.tag=="Coon")
            StartCoroutine(death());


    }

    IEnumerator death()
    {
        anim.SetBool("Dead", true);
        audio.clip = die;
        audio.Play();

        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("PossumRun");

    }
}
