using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BackgroundGame : MonoBehaviour
{
    public float speed = 1f;
    private void Start()
    {
        transform.Rotate(0, 1, Random.Range(0,365));
    }
    void Update()
    {
        transform.Rotate(0, 0, speed * Time.deltaTime);
    }
}
