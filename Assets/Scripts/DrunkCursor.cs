using UnityEngine;

public class DrunkCursor : MonoBehaviour
{
    public float maxOffset = 20f; // m�ximo desplazamiento del cursor
    public float speed = 2f; // velocidad de movimiento del cursor

    private Vector3 targetPosition; // posici�n a la que se mover� el cursor
    private Vector3 currentPosition; // posici�n actual del cursor

    private void Start()
    {
        // establece la posici�n inicial del cursor como la posici�n actual
        currentPosition = transform.position;
        targetPosition = currentPosition;
    }

    private void Update()
    {
        // a�ade un desplazamiento aleatorio a la posici�n objetivo del cursor
        targetPosition += new Vector3(Random.Range(-maxOffset, maxOffset), Random.Range(-maxOffset, maxOffset), 0f);

        // suaviza el movimiento del cursor hacia la posici�n objetivo
        currentPosition = Vector3.Lerp(currentPosition, targetPosition, Time.deltaTime * speed);

        // actualiza la posici�n del objeto que representa al cursor
        transform.position = currentPosition;
    }
}
