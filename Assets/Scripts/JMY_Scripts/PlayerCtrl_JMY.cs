using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerCtrl_JMY : MonoBehaviour
{
    Sound sound;
    AudioSource audioss;
    public GameObject Player;
    Rigidbody rb;
    int life = 3;
    public float speed = 10;
    public Text lifetext;
    public Text timetext;
    public Text finishtext;

    void Awake()
    {
        sound = GetComponent<Sound>();
        rb = GetComponent<Rigidbody>();
        audioss = GetComponent<AudioSource>();
    }


    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        transform.Translate(new Vector3(h, 0, v) * Time.deltaTime * speed);      
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Mateor")
        {
            life--;
            Debug.Log("데미지를 입었습니다");
            sound.SoundPlay(0);
        }
    }

    private void Update()
    {
        lifetext.text = "LIFE : " + life.ToString();
        
        if (life == 0 || transform.position.y < -30)
        {
            audioss.Stop();
            sound.SoundPlay(1);
            Debug.Log("사망하였습니다");
            Time.timeScale = 0;
            GameObject.Find("Canvas").transform.Find("GameoverUI").gameObject.SetActive(true);
            transform.position = (new Vector3(-1, -5, -10));
            --life;
        }

        if (transform.position.z > 330)
        {
            SceneManager.LoadScene("LoadingScene");
        }

        timetext.text = UIManager.guiTime.ToString("N2");
        finishtext.text = UIManager.guiTime.ToString("N2") + "초를 버텼습니다.";
    }
}
