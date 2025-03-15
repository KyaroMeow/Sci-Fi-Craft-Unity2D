using UnityEngine;

public class DragManager : MonoBehaviour
{
    private GameObject draggedObject;
    private Vector3 offset;
    private Vector3 lastMousePosition;
    private Vector3 velocity = Vector3.zero;
    public float maxThrowSpeed = 10f; // Максимальная скорость броска
    public float collisionRadius = 0.5f; // Радиус для проверки столкновений
    public float downwardForce = 5f; // Сила, тянущая объект вниз

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
                lastMousePosition = Input.mousePosition;
            }
        }

        if (Input.GetMouseButton(0) && draggedObject != null)
        {

            Vector3 newPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane));
            Vector3 newPosition = new Vector3(newPos.x + offset.x, newPos.y + offset.y, 0f);
            Collider2D[] colliders = Physics2D.OverlapCircleAll(newPosition, collisionRadius);
            bool canMove = true;
            foreach (Collider2D collider in colliders)
            {
                if (collider.gameObject != draggedObject && collider.CompareTag("Obstacle"))
                {
                    canMove = false;
                    draggedObject = null;
                    break;
                }
            }
            if (canMove)
            {
                draggedObject.transform.position = newPosition;
            }
            lastMousePosition = Input.mousePosition;
        }

        if (Input.GetMouseButtonUp(0) && draggedObject != null)
        {
            Rigidbody2D rb = draggedObject.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                Vector3 throwVelocity = (Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane)) - Camera.main.ScreenToWorldPoint(new Vector3(lastMousePosition.x, lastMousePosition.y, Camera.main.nearClipPlane))) / Time.deltaTime;
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
