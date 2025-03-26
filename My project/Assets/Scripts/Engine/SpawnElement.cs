
using UnityEngine;

public class SpawnElement : MonoBehaviour
{
   public GameObject[] ElementPrefab;
   public bool isClicked = false;

   public void SetCliked()
   {
        isClicked = true;
   }

    public void SpawnElOnMouse(int elementId)
    {
        if(isClicked){
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPosition.z = 0;
        Instantiate(ElementPrefab[elementId],mouseWorldPosition,Quaternion.identity);
        DragManager.Instance.draggedObject = ElementPrefab[elementId];
        isClicked = false;
        }
    }
    
}
