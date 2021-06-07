using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Blocks_KJS : MonoBehaviour
{
    Sound sound;
    private AudioSource audioss;
    public GameObject RED;
    Transform tr;
    Rigidbody rb;
    void Start()
    {
        sound = GetComponent<Sound>();
        rb = GetComponent<Rigidbody>();
        tr = GetComponent<Transform>();
        InvokeRepeating("Summon", 1, 1);
        audioss = GetComponent<AudioSource>();
    }

    void Summon()
    {
        sound.SoundPlay(0);
        float random = Random.Range(-2f, 2f);
        transform.position = new Vector3(random, 0, 13);
        //Instantiate(RED, new Vector3(random, 0, 13), transform.rotation);
        //UnSummon();
    }
    //void UnSummon()
    //{
    //    Destroy(GameObject.FindGameObjectWithTag("Blocks"));
    //}
        void OnTriggerStay(Collider other)
    {
        if (other.transform.name == "Cube" && RED.transform.lossyScale.x >= 0.48f)
        {
            audioss.Stop();
            sound.SoundPlay(1);
            Time.timeScale = 0;
            GameObject.Find("Canvas").transform.Find("GameoverUI").gameObject.SetActive(true);
        }
    }
    
}
