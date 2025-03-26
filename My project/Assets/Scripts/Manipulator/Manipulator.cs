using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manipulator : MonoBehaviour
{
   public Animator manipulatorAnimator;
   public Animator textAnimator;
   public Transform resultElement;
   public Collider2D Table;
   private Dictionary<string, GameObject> reactionResults;
   private List<GameObject> ElementsOnTable = new List<GameObject>();

   private bool isReact = false;
    
    public void Cook()
    {
        isReact = false;
        ElementsOnTable.Clear();
        Bounds bounds = Table.bounds;
        // Определяем две точки, которые задают область
        Vector2 pointA = new Vector2(bounds.min.x, bounds.min.y);
        Vector2 pointB = new Vector2(bounds.max.x, bounds.max.y);

        // Получаем все коллайдеры внутри области
        Collider2D[] colliders = Physics2D.OverlapAreaAll(pointA, pointB);
        if (colliders.Length == 4)
        {
            SFXSource.Instance.PlayCoock();
            foreach (Collider2D collider in colliders) 
            {
               if(collider.CompareTag("Draggable"))
               {
                if(collider.gameObject.GetComponent<ElementBehaviour>()!=null)
                {
                ElementsOnTable.Add(collider.gameObject);
                }
                else{
                    Debug.Log("script not found");
                }
               }
            }
            manipulatorAnimator.SetTrigger("Button");
            Debug.Log("good");
        }
        else
        {
            SFXSource.Instance.PlayError();
            Debug.Log("null or many");
        }
    }
    public void Start()
    {
        int reactCount = 0;
        reactionResults = new Dictionary<string, GameObject>();

        // Заполнение реакций из элементов
        foreach (Element element in Resources.LoadAll<Element>("Elements"))
        {
            foreach (ElementReaction reaction in element.reactions)
            {
                string key = $"{element.elementName}+{reaction.elementName}";
                if (!reactionResults.ContainsKey(key))
                {
                    reactionResults.Add(key, reaction.resultPrefab);
                    reactCount++;
                }
            }
        }
        Debug.Log("react add:"+ reactCount);
    }
    public void NewElements()
    {
        string key = $"{ElementsOnTable[0].GetComponent<ElementBehaviour>().element.elementName}+{ElementsOnTable[1].GetComponent<ElementBehaviour>().element.elementName}";
        Destroy(ElementsOnTable[0]);
        Destroy(ElementsOnTable[1]);
        if (reactionResults.ContainsKey(key))
        {
            isReact = true;
            GameObject resultPrefab = reactionResults[key];
            Instantiate(resultPrefab, resultElement.position, Quaternion.identity);
            CheckNewElement(resultPrefab);
        }
        else
        {
            Debug.Log("Реакция не определена.");
        }

    }
    public void ShowNoReactions()
    {
        if (!isReact)
        {
            textAnimator.SetTrigger("NoReact");
            SFXSource.Instance.PlayError();
        }

    }
    
    
    public void CheckNewElement(GameObject element)
    {

        ElementBehaviour elementBehaviour = element.GetComponent<ElementBehaviour>();
        if (elementBehaviour != null)
        {
            if (GameManager.Instance.elementState[elementBehaviour.Id] == false)//if new
            {
            GameManager.Instance.elementState[elementBehaviour.Id] = true;
            string key = $"Element_{elementBehaviour.Id}_is_open";
            PlayerPrefs.SetFloat(key,1f);
            UIManager.Instance.SetInteractElButton(elementBehaviour.Id,true);
            UIManager.Instance.reactionCount++;
            PlayerPrefs.SetInt("ReactCount",UIManager.Instance.reactionCount);
            }
        }
    }
}
