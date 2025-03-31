using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThwompMove : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject pointA;
    public GameObject pointB;
    public Rigidbody rb;
    public float speed;
    private Transform currentPoint;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentPoint = pointB.transform;
        speed = 40f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (currentPoint == pointB.transform)
        {
            speed = 20f;
            rb.velocity = new Vector2(0, -speed);
        }
        else
        {
            speed = 10f;
            rb.velocity = new Vector2(0, speed);
        }
        if (Vector2.Distance(transform.position, currentPoint.position) < 1f && currentPoint == pointB.transform)
        {
            currentPoint = pointA.transform;
        }
        if (Vector2.Distance(transform.position, currentPoint.position) < 1f && currentPoint == pointA.transform)
        {
            currentPoint = pointB.transform;
        }
    }
}

