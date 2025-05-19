using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMove : MonoBehaviour
{
    public GameObject pointA;
    public GameObject pointB;
    public GameObject pointC;
    public GameObject pointD;

    public float speed = 2f;
    public float radius = 0.5f;

    private Rigidbody2D rb;
    private Animator anim;
    private Transform currentPoint;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        currentPoint = pointB.transform;
        anim.SetBool("isRunning", true);
    }

    void FixedUpdate()
    {
        if (currentPoint == pointB.transform)
        {
            rb.velocity = new Vector2(speed, 0);
        }

        if (currentPoint == pointC.transform)
        {
            rb.velocity = new Vector2(0, -speed);
        } 
        if (currentPoint == pointD.transform)
        {
            rb.velocity = new Vector2(-speed, 0);
        }

        if (currentPoint == pointA.transform)
        {
            rb.velocity = new Vector2(0, speed);
        }

        if (Vector2.Distance(transform.position, currentPoint.position) < radius && currentPoint == pointB.transform)
        {
            currentPoint = pointC.transform;
        }
        if (Vector2.Distance(transform.position, currentPoint.position) < radius && currentPoint == pointC.transform)
        {
            currentPoint = pointD.transform;
        }
        if (Vector2.Distance(transform.position, currentPoint.position) < radius && currentPoint == pointD.transform)
        {
            currentPoint = pointA.transform;
        }
        if (Vector2.Distance(transform.position, currentPoint.position) < radius && currentPoint == pointA.transform)
        {
            currentPoint = pointB.transform;
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(pointA.transform.position, 0.5f);
        Gizmos.DrawWireSphere(pointB.transform.position, 0.5f);
        Gizmos.DrawWireSphere(pointC.transform.position, 0.5f);
        Gizmos.DrawWireSphere(pointD.transform.position, 0.5f);
        Gizmos.DrawLine(pointA.transform.position, pointB.transform.position);
        Gizmos.DrawLine(pointB.transform.position, pointC.transform.position);
        Gizmos.DrawLine(pointC.transform.position, pointD.transform.position);
        Gizmos.DrawLine(pointD.transform.position, pointA.transform.position);
    }
}
