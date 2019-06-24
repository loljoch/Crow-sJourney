using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAndPlayerSpeedUp : MonoBehaviour
{
    private CharacterController2d characterController2D;
    private CameraMovement2d camera;
    private float distance;
    private float maxDistance;

    private void Start()
    {
        characterController2D = FindObjectOfType<CharacterController2d>();
        camera = FindObjectOfType<CameraMovement2d>();
        maxDistance = CalculateDistance();
    }


    private void FixedUpdate()
    {
        distance = CalculateDistance();
        camera.movementSpeed = 10 - distance * 0.35f;
        characterController2D.movementSpeed = 10 - distance * 0.3f;
    }

    private float CalculateDistance()
    {
        return Vector3.Distance(transform.position, characterController2D.transform.position);
    }
}
