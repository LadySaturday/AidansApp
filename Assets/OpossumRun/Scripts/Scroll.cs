using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour
{

    public float speed = 0.5f;
    Vector2 offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = new Vector2(0,0);
    }

    // Update is called once per frame
    void Update()
    {
        offset = new Vector2(Time.time * speed, 0);

        gameObject.GetComponent<Renderer>().material.mainTextureOffset = offset;
    }
}
