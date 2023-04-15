using UnityEngine;

public class DrunkCursor : MonoBehaviour
{
    public float maxOffset = 20f; // máximo desplazamiento del cursor
    public float speed = 2f; // velocidad de movimiento del cursor

    private Vector3 targetPosition; // posición a la que se moverá el cursor
    private Vector3 currentPosition; // posición actual del cursor

    private void Start()
    {
        // establece la posición inicial del cursor como la posición actual
        currentPosition = transform.position;
        targetPosition = currentPosition;
    }

    private void Update()
    {
        // añade un desplazamiento aleatorio a la posición objetivo del cursor
        targetPosition += new Vector3(Random.Range(-maxOffset, maxOffset), Random.Range(-maxOffset, maxOffset), 0f);

        // suaviza el movimiento del cursor hacia la posición objetivo
        currentPosition = Vector3.Lerp(currentPosition, targetPosition, Time.deltaTime * speed);

        // actualiza la posición del objeto que representa al cursor
        transform.position = currentPosition;
    }
}
