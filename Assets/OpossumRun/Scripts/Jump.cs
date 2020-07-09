
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Jump : MonoBehaviour
{

    public float jumpSpeed = 8f;
    private bool grounded;
    private Rigidbody2D rigidBody;
    private Animator anim;
    public AudioClip die;
    public AudioClip jump;
    public AudioClip pickup;
    public int trash;

    private new AudioSource audio;
    public GameObject trashDisplay;
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
      
        if (Input.anyKey&&grounded)
        {
            grounded = false;
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpSpeed);
            if (Time.timeScale == 1)
            {
                audio.clip = jump;
                audio.Play();
            }

        }

        
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
        else if (collision.gameObject.tag == "Win")
        {
            //stop scrolling
            //count trash
        }

    }

    IEnumerator death()
    {
        anim.SetBool("Dead", true);
        audio.clip = die;
        audio.Play();

        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene("Level4");

    }
}
