using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapPositon : MonoBehaviour
{
    public int canHaveSpikeTrap;
    public int canHaveArrowTrap;
    public int canHaveAxeTrap;

    private List<int> availableTraps;

    private void SetList()
    {
        availableTraps = new List<int>();

        if (canHaveSpikeTrap > 0)
        {
            availableTraps.Add(canHaveSpikeTrap);
        }

        if (canHaveArrowTrap > 0)
        {
            availableTraps.Add(canHaveArrowTrap);
        }

        if (canHaveAxeTrap > 0)
        {
            availableTraps.Add(canHaveAxeTrap);
        }
    }

    public void SetTrap()
    {
        SetList();
        switch (availableTraps[Random.Range(0, availableTraps.Count)])
        {
            case 1:
                Instantiate(GameManager.Instance.spikeTrap, transform);
                break;
            case 2:
                Instantiate(GameManager.Instance.arrowTrap, transform);
                break;
            case 3:
                Instantiate(GameManager.Instance.axeTrap, transform);
                break;
            default:
                break;
        }
    }


}
