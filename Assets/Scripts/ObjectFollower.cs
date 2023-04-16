using UnityEngine;

public class ObjectFollower : MonoBehaviour
{
    public Transform stationaryObject;
    public Transform movingObject;
    public Vector3 offset;
    public float rotationSpeed = 5.0f;
    public float lookAtSpeed = 1.0f;

    void Update()
    {
        Vector3 offsetPosition = movingObject.position + offset;
        Quaternion targetRotation = Quaternion.LookRotation(offsetPosition - stationaryObject.position);

        stationaryObject.rotation = Quaternion.Slerp(stationaryObject.rotation, targetRotation, Time.deltaTime * rotationSpeed * lookAtSpeed);
    }
}
