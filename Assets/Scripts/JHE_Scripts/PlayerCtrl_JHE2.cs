using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl_JHE2 : MonoBehaviour
{
    Sound sound;
    Transform tr;
    AudioSource audioss;
    public GameObject player;
    public float moveSpeed = 10;


    private void Awake()
    {
        sound = GetComponent<Sound>();
        audioss = GetComponent<AudioSource>();
    }
    void Start()
    {
        tr = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal"), v = Input.GetAxisRaw("Vertical");
        tr.Translate(new Vector3(h, 0, 0) * moveSpeed * Time.deltaTime);
        tr.Translate(new Vector3(0, v, 0) * moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Sensor")
        {
            audioss.Stop();
            sound.SoundPlay(0);
            Time.timeScale = 0;
            GameObject.Find("Canvas").transform.Find("GameoverUI").gameObject.SetActive(true);
        }
        
        if (other.gameObject.tag == "Enemy")
        {
            audioss.Stop();
            sound.SoundPlay(0);
            Time.timeScale = 0;
            GameObject.Find("Canvas").transform.Find("GameoverUI").gameObject.SetActive(true);
        }
    }
}
