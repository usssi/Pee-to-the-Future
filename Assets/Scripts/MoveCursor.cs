using UnityEngine;

public class MoveCursor : MonoBehaviour
{
    public float speed = 1f; // velocidad de movimiento del cursor
    private Vector3 targetPosition; // posición a la que se moverá el cursor

    private void Start()
    {
        // establece la posición inicial del cursor
        targetPosition = Input.mousePosition;
        Cursor.lockState = CursorLockMode.None;
    }

    private void Update()
    {
        // calcula la distancia entre la posición actual del cursor y la posición objetivo
        float distance = Vector3.Distance(Input.mousePosition, targetPosition);

   

    }
}
