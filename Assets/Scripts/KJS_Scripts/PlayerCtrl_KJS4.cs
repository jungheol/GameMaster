using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCtrl_KJS4 : MonoBehaviour
{
    Sound sound;
    Transform tr;
    int index;
    public GameObject[] block;
    public Text timetext;
    public Text finishtext;

    void Start()
    {
        sound = GetComponent<Sound>();
        tr = GetComponent<Transform>();
        InvokeRepeating("Summon", 1, 1);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            guardup();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            guarddown();
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            guardleft();
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            guardright();
        }
        index = Random.Range(0, 4);

        timetext.text = UIManager.guiTime.ToString("N2");
        finishtext.text = UIManager.guiTime.ToString("N2") + "초를 버텼습니다.";
    }
    void guardup()
    {
        tr.position = (new Vector3(0, 2, 0));//up
        sound.SoundPlay(0);
    }
    void guarddown()
    {
       tr.position = (new Vector3(0, -2, 0));//down
        sound.SoundPlay(0);
    }
    void guardleft()
    {
       tr.position = (new Vector3(-2, 0, 0));//right
        sound.SoundPlay(0);
    }
    void guardright()
    {
       tr.position = (new Vector3(2, 0, 0));//right
        sound.SoundPlay(0);
    }
    void Summon()
    {
       int i = Random.Range(0, 4);
        if (i == 0)
        {
            Summon0();
        }
        else if (i == 1)
        {
            Summon1();
        }
        else if (i == 2)
        {
            Summon2();
        }
        else if (i == 3)
        {
            Summon3();
        }
    }
    void Summon0()
    {
        Instantiate(block[Random.Range(0, 2)], new Vector3(12, 0, 0), transform.rotation);
    }
    void Summon1()
    {
        Instantiate(block[Random.Range(0, 2)], new Vector3(-12, 0, 0), transform.rotation);
    }
    void Summon2()
    {
        Instantiate(block[Random.Range(0, 2)], new Vector3(0, 12, 0), transform.rotation);
    }
    void Summon3()
    {
        Instantiate(block[Random.Range(0, 2)], new Vector3(0, -12, 0), transform.rotation);
    }
}
