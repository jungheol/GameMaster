using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameMGR_JHE2 : MonoBehaviour
{
    Sound sound;
    public GameObject[] enemy;
    public GameObject player;
    Vector3 playertr;

    public Text timetext;
    public Text finishtext;

    float spawnWait;
    float timer = 8f;
    float startWait;

    private void Awake()
    {
        sound = GetComponent<Sound>();
    }
    void Start()
    {
        playertr = player.transform.position;
        StartCoroutine(EnemyRespawn());
        startWait = 3.0f;
        spawnWait = 2.0f;
    }

    void Update()
    {
        
        timetext.text = UIManager.guiTime.ToString("N2");
        finishtext.text = UIManager.guiTime.ToString("N2") + "초를 버텼습니다.";

    }

    IEnumerator EnemyRespawn()
    {
        yield return new WaitForSeconds(startWait);
        
        while (timer > 0)
        {
            // yield return new WaitForSeconds(spawnWait);
            timer--;
            playertr = player.transform.position;
            Instantiate(enemy[0], new Vector3(playertr.x + Random.Range(3,7), playertr.y + Random.Range(3, 7), 9.5f), transform.rotation);
            Instantiate(enemy[1], new Vector3(playertr.x + Random.Range(0, 4), playertr.y + Random.Range(3, 7), 9.5f), transform.rotation);
            Instantiate(enemy[2], new Vector3(playertr.x + Random.Range(-3, -7) , playertr.y + Random.Range(3, 7), 9.5f), transform.rotation);
            Instantiate(enemy[3], new Vector3(playertr.x + Random.Range(-3,-7), playertr.y + Random.Range(-3, -7), 9.5f), transform.rotation);
            Instantiate(enemy[4], new Vector3(playertr.x + Random.Range(3, 7), playertr.y + Random.Range(-3, -7), 9.5f), transform.rotation);
            sound.SoundPlay(0);
            yield return new WaitForSeconds(spawnWait);
            if (timer == 0)
                SceneManager.LoadScene("LoadingScene");
        }
    }    
}
