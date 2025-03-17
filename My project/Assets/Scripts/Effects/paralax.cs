using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paralax : MonoBehaviour
{
   public Vector2 targetPosition;
    public float speed = 1.0f;

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, targetPosition) < 0.001f)
        {
            transform.position = targetPosition;
        }
    }
}
