using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingMGR : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Physics.gravity = new Vector3(0, -9.0F, 0);
        Invoke("NextScene", 1f);
        Time.timeScale = 1;
    }

    void NextScene()
    {
        // SceneManager.LoadScene("Game"+ Random.Range(1, 8));
        SceneManager.LoadScene("Game6");
    }
}
