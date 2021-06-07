using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerCtrl_KJS3 : MonoBehaviour
{
    Sound sound;
    public float LimitTime;
    public GameObject  Player;
    public Text timetext;
    public Text finishtext;
    private AudioSource audioss;
    //public float timer_result;
    void Start()
    {
        //++timer_result;
        sound = GetComponent<Sound>();
        LimitTime = Random.Range(10, 15);
        InvokeRepeating("Timer", 1, 1);
        audioss = GetComponent<AudioSource>();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Physics.gravity.y < 0)
        {
            Physics.gravity = new Vector3(0, 50.0F, 0);
            sound.SoundPlay(0);
        }
        else if (Input.GetMouseButtonDown(0) && Physics.gravity.y > 0)
        {
            Physics.gravity = new Vector3(0, -50.0F, 0);
            sound.SoundPlay(0);
        }
        if (LimitTime == 0)
        {
            Physics.gravity = new Vector3(0, -9.0F, 0);
            SceneManager.LoadScene("LoadingScene");
        }

        timetext.text = UIManager.guiTime.ToString("N2");
        finishtext.text = UIManager.guiTime.ToString("N2") + "초를 버텼습니다.";
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Blocks")
        {
            audioss.Stop();
            sound.SoundPlay(1);
            Physics.gravity = new Vector3(0, -9.0F, 0);
            Time.timeScale = 0;
            GameObject.Find("Canvas").transform.Find("GameoverUI").gameObject.SetActive(true);
        }
        //if (other.gameObject.tag == "Bullet")
        //{
        //    Physics.gravity = new Vector3(0, -9.0F, 0);
        //    Time.timeScale = 0;
        //    GameObject.Find("Canvas").transform.Find("GameoverUI").gameObject.SetActive(true);
        //}
    }
    void Timer()
    {
        LimitTime--;
    }
}
