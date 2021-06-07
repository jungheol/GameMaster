using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blocks_KJS2 : MonoBehaviour
{
  
    Transform tr;
    public GameObject[] block;
    public GameObject block1, block2, block3, block4, block5;
    void Start()
    {
        tr = GetComponent<Transform>();
        InvokeRepeating("Summon", 1, 2);
        InvokeRepeating("Summons", 2, 1);
    }
   
        void Summon()
    {
        int i = Random.Range(0, 2);
        if (i == 0)
        {
            Summon0();
        }
        else if (i == 1)
        {
            Summon1();
        }
    }
    void Summons()
    {
        int i = Random.Range(0, 3);
        if (i == 0)
        {
            Summon2();
        }
        else if (i == 1)
        {
            Summon3();
        }
        else if (i == 2)
        {
            Summon4();
        }
        
    }
    void Summon0()
    {
        Instantiate(block1, new Vector3(12, 2, 0), transform.rotation);
    }
    void Summon1()
    {
        Instantiate(block2, new Vector3(12, 10, 0), transform.rotation);
    }
    void Summon2()
    {
        Instantiate(block3, new Vector3(12, 1, 0), transform.rotation);
    }
    void Summon3()
    {
        Instantiate(block4, new Vector3(12, 5, 0), transform.rotation);
    }
    void Summon4()
    {
        Instantiate(block5, new Vector3(12, 9, 0), transform.rotation);
    }
}
