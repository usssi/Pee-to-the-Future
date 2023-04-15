using UnityEngine;

public class MoveCursor : MonoBehaviour
{
    public float speed = 1f; // velocidad de movimiento del cursor
    private Vector3 targetPosition; // posici�n a la que se mover� el cursor

    private void Start()
    {
        // establece la posici�n inicial del cursor
        targetPosition = Input.mousePosition;
        Cursor.lockState = CursorLockMode.None;
    }

    private void Update()
    {
        // calcula la distancia entre la posici�n actual del cursor y la posici�n objetivo
        float distance = Vector3.Distance(Input.mousePosition, targetPosition);

   

    }
}
