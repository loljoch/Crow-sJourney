using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator2d : MonoBehaviour
{
    public GameObject emptyMaps;
    public GameObject[] mapPrefab;
    public int mapSize;

    private List<Transform> emptyMapList;
    private Grid grid;

    private void Start()
    {
        grid = FindObjectOfType<Grid>();
        emptyMapList = new List<Transform>();
        foreach (var child in emptyMaps.GetComponentsInChildren<Transform>())
        {
            if(child != emptyMaps.transform)
            {
                emptyMapList.Add(child);
            }
        }
    }

    public void SetMap(Collision2D collision)
    {
        int randomNumber = Random.Range(0, mapPrefab.Length);
        Instantiate(mapPrefab[randomNumber], collision.transform.position, Quaternion.identity, grid.transform);
    }

    private void PushEmptyMap(Transform emptyMap)
    {
        emptyMap.position = new Vector3(emptyMap.position.x + mapSize, emptyMap.position.y, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        SetMap(collision);
        PushEmptyMap(collision.transform);
    }

}
