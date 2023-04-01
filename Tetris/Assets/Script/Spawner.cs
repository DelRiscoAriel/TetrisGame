using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
    public GameObject[] groups;
    public int i;

    public void spawnNext()
    {      
        Instantiate(groups[i],
            transform.position,
            Quaternion.identity);
    }

    public void NextBlock()
    {
        i = Random.Range(0, groups.Length);
    }

    void Start()
    {
        NextBlock();
        spawnNext();
    }
}
