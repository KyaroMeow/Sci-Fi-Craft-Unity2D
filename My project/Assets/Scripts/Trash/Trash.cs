using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.CompareTag("Draggable"))
        {
            Destroy(collider.gameObject);
        }
    }
}
