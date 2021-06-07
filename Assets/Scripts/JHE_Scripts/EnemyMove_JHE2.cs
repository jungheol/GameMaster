using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove_JHE2 : MonoBehaviour
{    
    public float moveSpeed = 5f;
    Vector3 playertr;
    Rigidbody rb;


    
    void Start()
    {
        playertr = GameObject.Find("Player").transform.position;
        rb = GetComponent<Rigidbody>();
    }   

    // Update is called once per frame
    void Update()
    {
        Enemymove();
        //if (rb.velocity.magnitude < 1f)
        //{
        //    Destroy(this);
        //}
    }

    void Enemymove()
    {
        transform.position = Vector3.MoveTowards(transform.position, playertr, moveSpeed*Time.deltaTime);
    }

    

}
