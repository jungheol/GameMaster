using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mateor_JMY : MonoBehaviour
{
    Animator mateorAnim;
    GameObject mateor1, mateor2;
    public GameObject[] rocks;
    public float mateorSpeed = 50f;

    float startWait;
    float spawnWait;

    void Start()
    {
        mateorAnim = GetComponent<Animator>();
        StartCoroutine(RandomMateor());
        startWait = 1.0f;
        spawnWait = 3.0f;
    }
    IEnumerator RandomMateor()
    {
        yield return new WaitForSeconds(startWait);

        while (UIManager.guiTime < 300)
        {
            int index = Random.Range(0, rocks.Length);
            mateor1 = Instantiate(rocks[index], new Vector3(-5f, 149f, Random.Range(250, 350)), transform.rotation);
            mateor2 = Instantiate(rocks[index], new Vector3(5f, 150f, Random.Range(250, 350)), transform.rotation);
            yield return new WaitForSeconds(spawnWait);
        }
    }

    void Update()
    {

        //if(rocks[0].transform.position.z < 0)
        //{
        //    Destroy(this);
        //    // mateor1 = mateor2;           
        //    // RandomMateor();
        //}
        //if (rocks[1].transform.position.z < 0)
        //{
        //    Destroy(rocks[1]);
        //    // mateor1 = mateor2;           
        //    // RandomMateor();
        //}

        //if (rocks[1].transform.position.z < 260)
        //{
        //    RandomMateor();
        //}

    }

    //void RandomMateor()
    //{
    //    int index = Random.Range(0, rocks.Length);
    //    mateor1 = Instantiate(rocks[index], new Vector3(-5f, 149f, Random.Range(300,330)), transform.rotation);
    //    mateor2 = Instantiate(rocks[index], new Vector3(5f, 150f, Random.Range(330,350)), transform.rotation);
        
    //}

    
}
