using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using ChrisTutorials.Persistent;

public class CheckGround2d : MonoBehaviour
{
    private CharacterController2d characterController2D;
    [SerializeField] private AudioClip landingSound;

    private void Start()
    {
        characterController2D = FindObjectOfType<CharacterController2d>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        try
        {
            if (collision.GetComponent<TilemapCollider2D>() != null)
            {
                AudioManager.Instance.Play(landingSound, transform, 0.1f);
                characterController2D.onGround = true;
            }
        } catch (System.NullReferenceException)
        {
        }

    }

    private void OnTriggerExit(Collider other)
    {
        try
        {
            if (other.GetComponent<TilemapCollider2D>() != null)
            {
                characterController2D.onGround = false;
            }
        } catch (System.NullReferenceException)
        {
        }
    }
}
