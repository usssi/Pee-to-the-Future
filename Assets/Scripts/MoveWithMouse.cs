using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWithMouse : MonoBehaviour
{
    public float speedCursorMove;
    public Camera cam;
    public Collider Collider;
    RaycastHit hit;
    Ray ray;

    void Start()
    {
        Physics.IgnoreLayerCollision(5,6);
    }

    void Update()
    {
        ray = cam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            transform.position = Vector3.MoveTowards(transform.position, hit.point, Time.deltaTime * speedCursorMove);
        }
    }
}
