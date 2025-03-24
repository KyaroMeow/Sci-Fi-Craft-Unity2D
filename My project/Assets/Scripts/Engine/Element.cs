using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "NewElement", menuName = "Element", order = 1)]
public class Element : ScriptableObject
{
    [Header("Element Properties")]
    public string elementName; // Название элемента
    public Sprite elementSprite; // Спрайт элемента для отображения
    public GameObject elementPrefab; // Префаб элемента для инстанцирования

    [Header("Element Reactions")]
    [Tooltip("Key is a combination of two element names, e.g., 'Fire+Water'")]
    public List<ElementReaction> reactions; // Список реакций для этого элемента
}

[System.Serializable]
public class ElementReaction
{
    public string elementName; // Название второго элемента
    public GameObject resultPrefab; // Префаб результата реакции
}
