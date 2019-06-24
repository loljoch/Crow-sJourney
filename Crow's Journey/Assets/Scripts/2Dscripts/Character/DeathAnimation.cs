using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathAnimation : MonoBehaviour
{
    private void OnEnable()
    {
        GetComponentInChildren<Rigidbody2D>().velocity = Vector2.up * 10;
    }
}
