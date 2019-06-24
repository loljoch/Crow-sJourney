using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement2d : MonoBehaviour
{
    public float movementSpeed;
    public bool shouldMove;

    private void Update()
    {
        if (shouldMove)
        {
            Move();
        }
    }

    private void Move()
    {
        transform.Translate(Vector3.right * movementSpeed * Time.deltaTime);
    }
}
