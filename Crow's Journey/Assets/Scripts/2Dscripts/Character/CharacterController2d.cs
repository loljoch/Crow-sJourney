using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using ChrisTutorials.Persistent;

public class CharacterController2d : MonoBehaviour
{
    public float movementSpeed;
    public float jumpHeight;
    public float dashVelocity;
    [HideInInspector]public bool onGround;

    private bool jumpRequest;
    private bool dashRequest;
    private bool isDashing;
    private float horizontalInput;
    private float baseGravityScale;
    private float antiGravityDashTime = 0.002f;

    private new Rigidbody2D rigidbody2D;
    private Animator animator;
    public ParticleSystem dashParticle;
    [SerializeField] private DeathAnimation death;

    [Header("Sounds")]
    bool canPlaySound = true;
    [SerializeField] AudioClip dashSound;
    [SerializeField] AudioClip jumpSound;
    [SerializeField] AudioClip deathSound;
    [SerializeField] AudioClip explosionSound;
    [SerializeField] AudioClip[] footSteps;

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
        baseGravityScale = rigidbody2D.gravityScale;
    }

    private void Update()
    {
        Move();
        InputMovement();
    }

    private void FixedUpdate()
    {
        if (jumpRequest)
        {
            AudioManager.Instance.Play(jumpSound, transform, 0.1f);
            Jump();
        }

        if (dashRequest)
        {
            AudioManager.Instance.Play(dashSound, transform, 0.1f);
            Dash();
        }
    }

    private void InputMovement()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        animator.SetFloat("HorizontalMovement", Mathf.Abs(horizontalInput));
        if((horizontalInput < 0 && transform.localScale.x > 0 || horizontalInput > 0 && transform.localScale.x < 0))
        {
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        }


        if (Input.GetButtonDown("Jump") && onGround == true)
        {
            jumpRequest = true;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && horizontalInput != 0)
        {
            dashRequest = true;
            StartCoroutine(DashGravity());
        }

    }

    private void RigidBodyDrag(float x)
    {
        rigidbody2D.drag = x;
    }

    IEnumerator PlayFootStepSound()
    {
        if (onGround && canPlaySound)
        {
            int n = UnityEngine.Random.Range(1, footSteps.Length);
            AudioManager.Instance.Play(footSteps[n], transform, 0.05f);
            AudioClip tempFootstep = footSteps[0];
            footSteps[0] = footSteps[n];
            footSteps[n] = tempFootstep;
            canPlaySound = false;
            yield return new WaitForSeconds(0.1f);
            canPlaySound = true;
        }

    }

    private void Dash()
    {
        GameManager.Instance.dashesDone++;
        dashRequest = false;
        isDashing = true;
        rigidbody2D.velocity = Vector2.zero;
        rigidbody2D.velocity += (Vector2.right*horizontalInput).normalized * dashVelocity;
    }

    IEnumerator DashGravity()
    {
        DOVirtual.Float(14, 0, 0.8f, RigidBodyDrag);

        dashParticle.Play();
        rigidbody2D.gravityScale = 0;
        GetComponent<BetterJumping>().enabled = false;
        float secondsToWait = dashVelocity * antiGravityDashTime;
        yield return new WaitForSeconds(secondsToWait);
        rigidbody2D.gravityScale = baseGravityScale;
        GetComponent<BetterJumping>().enabled = true;
        dashParticle.Stop();
        isDashing = false;
    }

    private void Move()
    {
        rigidbody2D.velocity = new Vector2(horizontalInput * movementSpeed, rigidbody2D.velocity.y);
        if(horizontalInput != 0)
        {
            StartCoroutine(PlayFootStepSound());
        }
    }

    private void Jump()
    {
        GameManager.Instance.jumpsDone++;
        jumpRequest = false;
        onGround = false;
        rigidbody2D.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
    }

    public void Die()
    {
        AudioManager.Instance.Play(explosionSound, transform, 0.4f);
        AudioManager.Instance.Play(deathSound, transform, 0.5f);
        death.gameObject.SetActive(true);
        animator.GetComponent<SpriteRenderer>().enabled = false;
    }


}
