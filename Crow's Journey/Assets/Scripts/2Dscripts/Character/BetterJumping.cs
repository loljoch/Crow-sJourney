using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BetterJumping : MonoBehaviour
{
    private new Rigidbody2D rigidbody2D;
    [SerializeField] private float fallMultiplier;
    [SerializeField] private float lowJumpMultiplier;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        ImprovedJump();
    }


    private void ImprovedJump()
    {
        if (rigidbody2D.velocity.y < 0)
        {
            rigidbody2D.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        } else if (rigidbody2D.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            rigidbody2D.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }
}
