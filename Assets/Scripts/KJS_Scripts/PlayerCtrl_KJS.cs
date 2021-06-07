using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerCtrl_KJS : MonoBehaviour
{
    Sound sound;
    public float jumpforce = 6f;
    private Rigidbody rigidBody;
    public int JumpChance;
    public GameObject Player;
    public float LimitTime;
    public Text timetext;
    public Text finishtext;
    private AudioSource audioss;
    //public float timer_result;
    void Awake()
    {
        sound = GetComponent<Sound>();
        rigidBody = GetComponent<Rigidbody>();
        audioss = GetComponent<AudioSource>();
    }
    void Start()
    {
        Physics.gravity = new Vector3(0, -30.0F, 0);
        //++timer_result;
        LimitTime = Random.Range(10, 15);
        InvokeRepeating("Timer", 1, 1);
    }
    void Update()
    {
       // Physics.gravity = new Vector3(0, -30.0F, 0);
        if (Input.GetKey(KeyCode.Space) && JumpChance > 0)
        {
            Jump();

        }
        if (Input.GetKeyDown(KeyCode.Space) && JumpChance > 0)
        {
            sound.SoundPlay(0);

        }
        if (Input.GetKeyUp(KeyCode.Space) && JumpChance > 0)
        {
            JumpChance--;
            rigidBody.velocity = new Vector3(0, 0, 0);

        }
        if (LimitTime == 0)
        {
            SceneManager.LoadScene("LoadingScene");
        }

        timetext.text = UIManager.guiTime.ToString("N2");
        finishtext.text = UIManager.guiTime.ToString("N2") + "초를 버텼습니다.";
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Floor")
        {
            JumpChance = 1;
        }
        if (collision.gameObject.tag == "Blocks")
        {
            audioss.Stop();
            sound.SoundPlay(1);
            Time.timeScale = 0;
            GameObject.Find("Canvas").transform.Find("GameoverUI").gameObject.SetActive(true);
        }
    }
    void Jump()
    {
        rigidBody.AddForce(Vector3.up * jumpforce, ForceMode.Impulse);
    }
    void Timer()
    {
        LimitTime--;
    }
}
