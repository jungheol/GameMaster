using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerCtrl_KJS4_2 : MonoBehaviour
{
    Sound sound;
    public float LimitTime;
    private AudioSource audioss;
    void Start()
    {
        sound = GetComponent<Sound>();
        LimitTime = Random.Range(10, 15);
        InvokeRepeating("Timer", 1, 1);
        audioss = GetComponent<AudioSource>();
    }
    void Update()
    {
        if (LimitTime == 0)
        {
            SceneManager.LoadScene("LoadingScene");
            //SceneManager.LoadScene("Game" + Random.Range(1, 7));
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            audioss.Stop();
            sound.SoundPlay(0);
            Physics.gravity = new Vector3(0, -9.0F, 0);
            Time.timeScale = 0;
            GameObject.Find("Canvas").transform.Find("GameoverUI").gameObject.SetActive(true);
        }
 
    }
    void Timer()
    {
        LimitTime--;
    }
}
