using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    private TrapPositon[] trapPositons;

    private void Start()
    {
        trapPositons = GetComponentsInChildren<TrapPositon>();
        SetTraps();
    }

    public void SetTraps()
    {
        Debug.Log(trapPositons.Length);
        for (int i = 0; i < trapPositons.Length; i++)
        {
            if(Random.value < GameManager.trapSpawnChance)
            {
                trapPositons[i].SetTrap();
            }
        }
    }
}
