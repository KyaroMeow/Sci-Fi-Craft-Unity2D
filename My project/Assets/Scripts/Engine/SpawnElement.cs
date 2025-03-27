
using UnityEngine;
using UnityEngine.UI;

public class SpawnElement : MonoBehaviour
{
   public GameObject[] ElementPrefab;
   public bool isClicked = false;

   public void SetCliked(Button bttn)
   {
        if (bttn.interactable)
        {
            isClicked = true;
        }
   }

    public void SpawnElOnMouse(int elementId)
    {
        if(isClicked){
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPosition.z = 0;
        DragManager.Instance.draggedObject = Instantiate(ElementPrefab[elementId], mouseWorldPosition, Quaternion.identity);
        isClicked = false;
        }
    }
    
}
