using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnElement : MonoBehaviour
{
   public GameObject[] ElementPrefab;

    public void SpawnElOnMouse(int elementId)
    {
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPosition.z = 0;
        Instantiate(ElementPrefab[elementId],mouseWorldPosition,Quaternion.identity);
    }
    
}
