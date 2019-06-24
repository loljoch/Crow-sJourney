using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowTrap : Interact
{
    [SerializeField] private Rigidbody2D rigidbody2D;


    public override void CollidingConsequence()
    {
        float AngleRad = Mathf.Atan2(GameManager.Instance.player.transform.position.y - transform.position.y, GameManager.Instance.player.transform.position.x - transform.position.x);
        float AngleDeg = (180 / Mathf.PI) * AngleRad;
        transform.rotation = Quaternion.Euler(0, 0, AngleDeg);
        rigidbody2D.AddForce(transform.right * GameManager.arrowSpeed);
    }


}
