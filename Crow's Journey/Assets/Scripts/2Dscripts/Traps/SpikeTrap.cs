using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrap : Interact
{
    [SerializeField] SpriteRenderer sprite;
    [SerializeField] Sprite[] spikeSprites;
    private bool canKill;

    public override void CollidingConsequence()
    {
        if (!canKill)
        {
            sprite.sprite = spikeSprites[0];
            StartCoroutine(PopSpike());
        }
    }

    IEnumerator PopSpike()
    {
        yield return new WaitForSeconds(GameManager.spikeWaitTime);
        sprite.sprite = spikeSprites[1];
        canKill = true;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (canKill && collision.CompareTag("Player"))
        {
            GameManager.Instance.KillPlayer();
        }
    }

}
