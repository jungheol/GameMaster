using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    bool isFire;
    Vector3 direction;
    [SerializeField]
    float speed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        if(isFire)
        {
            transform.Translate(direction * Time.deltaTime * speed);
        }

    }
    
    public void Fire(Vector3 dir)
    {
        direction = dir;
        isFire = true;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Target")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
            GameMGR.targetCount--;
            GameMGR.score--;
        }
    }

    
}
