using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GMNG_KJS3 : MonoBehaviour
{
    public GameObject sensor, block, Player;
    public int Speed;
    void Update()
    {
        block.transform.Translate(Vector3.left * Speed * Time.deltaTime);
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "sensor")
        {
            Destroy(block);
        }
    }
}
