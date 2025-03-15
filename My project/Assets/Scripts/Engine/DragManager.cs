using UnityEngine;

public class DragManager : MonoBehaviour
{
    private GameObject draggedObject;
    private Vector3 offset;
    private Vector3 lastMousePosition;
    private Vector3 velocity = Vector3.zero;
    public float maxThrowSpeed = 10f; // Максимальная скорость броска

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Получаем объект под курсором мыши
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

            if (hit.collider != null && hit.collider.CompareTag("Draggable"))
            {
                draggedObject = hit.collider.gameObject;
                // Вычисляем смещение между центром объекта и позицией мыши
                offset = draggedObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane));
                lastMousePosition = Input.mousePosition;
            }
        }

        if (Input.GetMouseButton(0) && draggedObject != null)
        {
            // Перемещаем объект вместе с мышью
            Vector3 newPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane));
            Vector3 newPosition = new Vector3(newPos.x + offset.x, newPos.y + offset.y, draggedObject.transform.position.z);
            velocity = (newPosition - draggedObject.transform.position) / Time.deltaTime;
            draggedObject.transform.position = newPosition;
            lastMousePosition = Input.mousePosition;
        }

        if (Input.GetMouseButtonUp(0) && draggedObject != null)
        {
            // Отпускаем объект и применяем скорость с ограничением
            Rigidbody2D rb = draggedObject.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                // Вычисляем скорость как разницу между текущей и предыдущей позицией мыши
                Vector3 throwVelocity = (Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane)) - Camera.main.ScreenToWorldPoint(new Vector3(lastMousePosition.x, lastMousePosition.y, Camera.main.nearClipPlane))) / Time.deltaTime;

                // Ограничиваем скорость
                if (throwVelocity.magnitude > maxThrowSpeed)
                {
                    throwVelocity = throwVelocity.normalized * maxThrowSpeed;
                }

                rb.velocity = throwVelocity;
            }
            draggedObject = null;
        }
    }
}
