using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coon : MonoBehaviour
{
    //The purpose of this script is to control the behaviour of the raccoons
    private Animator anim;
    public AudioClip die;
    public GameObject trash;
    public GameObject [] waypoint;

    private GameObject target;
    private float speed=1;
    private float minDist = 0.1f;
    private float maxDist = -0.1f;
    private new AudioSource audio;
    private int waypointCount;
    private Vector2 direction = new Vector2(1, 1);

    float originalX; // Original float value

    private void Update()
    {
        float step = speed * Time.deltaTime;

        if ((transform.position-target.transform.position).x<minDist&& (transform.position - target.transform.position).x>maxDist)
        {
            waypointCount++;

            direction.x *= -1;
            transform.localScale = direction;


            if (waypointCount > waypoint.Length-1)
                waypointCount = 0;

            
            target = waypoint[waypointCount];
        }
        // move sprite towards the target location
        
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, step);
    }


    private void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
        target = waypoint[0];
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //collision means this sprite dies
        if (collision.gameObject.tag == "Player")
        {
            anim.SetBool("Dead", true);
            audio.clip = die;
            audio.Play();
            disableColliders();
            Invoke("makeTrash", 0.5f);
         //   Destroy(gameObject.transform.parent.gameObject);
        }
    }

    private void makeTrash()
    {
        Instantiate(trash, (gameObject.transform.parent.transform));

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        disableColliders();
    }

    private void disableColliders()
    {
        Collider2D[] colliders = GetComponents<Collider2D>();
        foreach (Collider2D c in colliders)
            c.enabled = false;
    }
}
