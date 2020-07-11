using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandScroll : MonoBehaviour
{

    public float speed = 0.5f;
    Vector2 offset;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.position = new Vector2(0, 0);
        offset = new Vector2(0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 offset = new Vector2(Time.timeSinceLevelLoad * -speed, 0);

        gameObject.transform.position = offset;
    }
}
