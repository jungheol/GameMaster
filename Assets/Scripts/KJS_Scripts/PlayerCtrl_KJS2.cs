using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerCtrl_KJS2 : MonoBehaviour
{
    Sound sound;
    Rigidbody rb;
    Transform tr;
    public GameObject Cube;
    public GameObject RED;
    public float LimitTime;
    public Text timetext;
    public Text finishtext;
    private AudioSource audioss;

    public GameObject Unsumon;
    //void Awake()
    //{
    //    InvokeRepeating("Summon", 1, 1);
    //    InvokeRepeating("UnSummon", 1, 1);

    //}
    void Start()
    {
        sound = GetComponent<Sound>();
        rb = GetComponent<Rigidbody>();
        tr = GetComponent<Transform>();
        audioss = GetComponent<AudioSource>();
        //++timer_result;
        LimitTime = Random.Range(10, 15);
        //InvokeRepeating("Summon", 1, 1);
        InvokeRepeating("Timer", 1, 1);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) && Cube.transform.position.x > -2f)
        {
            Left();
        }
        if (Input.GetKeyDown(KeyCode.D) && Cube.transform.position.x < 1f)
        {
            Right();
        }
        if (LimitTime == 0)
        {
            SceneManager.LoadScene("LoadingScene");
        }

        timetext.text = UIManager.guiTime.ToString("N2");
        finishtext.text = UIManager.guiTime.ToString("N2") + "초를 버텼습니다.";
    }
    void Left()
    {
        transform.position += new Vector3(-1, 0, 0);
        sound.SoundPlay(0);
    }
    void Right()
    {
        transform.position += new Vector3(1, 0, 0);
        sound.SoundPlay(0);
    }
   // void Summon()
   // {
   //     this.audio.clip = this.attaksound;
   //     this.audio.Play();
   //     float random = Random.Range(-2f, 2f);
   //     //transform.position += new Vector3(random, 0 , 13);
   //     Instantiate(RED, new Vector3(random, 0, 13), transform.rotation);
   //     UnSummon();
   // }
   //void UnSummon()
   // {
   //     Destroy(Unsumon);
   // }
    void Timer()
    {
        LimitTime--;
    }
}
