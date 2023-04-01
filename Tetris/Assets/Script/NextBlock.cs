using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextBlock : MonoBehaviour
{
    public Spawner script;
    //public Text show;
    GameObject a;

    public GameObject[] groups;

    // Start is called before the first frame update
    public void Next()
    {
        //show.text = ("Next Block: ");
        GameObject a = Instantiate(groups[script.i], transform.position, Quaternion.identity);
        Destroy(a, 1.5f);
    }
}
