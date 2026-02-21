using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed;
    public Transform pointA;
    public Transform pointB;

    private Vector2 targetPosition;
    private bool movingB;


    private void Start()
    {
        targetPosition = pointB.position;
    }

    private void Update()
    {

        transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, targetPosition) < 0.1f)
        {
            if (movingB)
            {
                targetPosition = pointA.position;
            }
            else
            {
                targetPosition = pointB.position;
            }

            movingB = !movingB;

            Flip();
        }
    }

    private void Flip()
    {
        Vector3 scaler = transform.localScale;
        scaler.x *= -1f;
        transform.localScale = scaler;
    }
}
