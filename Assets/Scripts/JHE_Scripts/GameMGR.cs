using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameMGR : MonoBehaviour
{
    Sound sound;
    AudioSource audioss;
    public GameObject[] targets;
    public GameObject targeta;
    public GameObject bulletPrefab;
    public Camera fpsCam;
    public Text scoretext;
    public Text timetext;
    public Text finishtext;

    public static int targetCount;
    public static int score = 15;
    public int targetMaxCount;
    public float timer = 10;
    private void Awake()
    {
        sound = GetComponent<Sound>();
        audioss = GetComponent<AudioSource>();
    }
    void Start()
    {
        float targetx = Random.Range(-10f, 10f);
        float targety = Random.Range(0.5f, 5f);
        float targetz = Random.Range(6.5f, 25f);
        int index = Random.Range(0, targets.Length);

        StartCoroutine(Timer());
        score = 15;
        targetCount = 4;
        targetMaxCount = 5;
        targeta = Instantiate(targets[index], new Vector3(targetx, targety, targetz), transform.rotation);
    }
    IEnumerator Timer()
    {
        for (int i = 0; i < 10; i++)
        {
            timer--;
            Debug.Log(timer);
            yield return new WaitForSeconds(1f);
            if (timer == 0)
            {
                audioss.Stop();
                sound.SoundPlay(1);
                Time.timeScale = 0;
                GameObject.Find("Canvas").transform.Find("GameoverUI").gameObject.SetActive(true); 
            }
        }
    }

    

    private void Update()
    {
        Fire();

        if (targetCount < targetMaxCount)
        {
            RandomTarget();
            targetCount++;
        }
        
        scoretext.text = "Target : " + score.ToString();
        finishtext.text = UIManager.guiTime.ToString("N2") + "초를 버텼습니다.";
        timetext.text = UIManager.guiTime.ToString("N2");


        //if(timer > 10)
        //GameObject.Find("Canvas").transform.Find("GameoverUI").gameObject.SetActive(true);


        if (score == 0)
        {
            //Time.timeScale = 0;
            //GameObject.Find("Canvas").transform.Find("ClearUI").gameObject.SetActive(true);
            SceneManager.LoadScene("LoadingScene");
        }
    }
  
    void Fire()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 firePos = transform.position + fpsCam.transform.forward + new Vector3(0f, 0.8f, 0f);
            var bullet = Instantiate(bulletPrefab, firePos, Quaternion.identity).GetComponent<Bullet>();
            bullet.Fire(fpsCam.transform.forward);
            sound.SoundPlay(0);
        }
    }

    void RandomTarget()
    {
        float targetx = Random.Range(-10f, 10f);
        float targety = Random.Range(0.5f, 5f);
        float targetz = Random.Range(6.5f, 25f);
        int index = Random.Range(0, targets.Length);
        targeta = Instantiate(targets[index], new Vector3(targetx, targety, targetz), transform.rotation);
        targeta.SetActive(true);
    }
}
