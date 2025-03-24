using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementHolders : MonoBehaviour
{
    public Element element;
    public SpriteRenderer ElementImage;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null && collision.CompareTag("Draggable")) 
        {
            element = collision.gameObject.GetComponent<ElementBehaviour>().element;
            ElementImage.sprite = element.elementSprite;
            collision.gameObject.SetActive(false);
        }
    }
}
