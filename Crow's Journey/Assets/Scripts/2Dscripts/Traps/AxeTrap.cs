using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeTrap : Interact
{
    [SerializeField] private Rigidbody2D rigidbody2D;

    public override void CollidingConsequence()
    {
        rigidbody2D.gravityScale = GameManager.axeGravityScale;
    }
}
