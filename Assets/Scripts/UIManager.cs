using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static float startTime;
    public static float guiTime;


    void ResetTime()
    {
        startTime = Time.time;
    }
    private void Update()
    {
        guiTime = Time.time - startTime;
    }
    public void StartBTN()
    {
        //Time.timeScale = 1;
        //Physics.gravity = new Vector3(0, -9.0F, 0);
        //SceneManager.LoadScene("Game" + Random.Range(1, 8));
        SceneManager.LoadScene("LoadingScene");

        ResetTime();
    }

    public void MainBTN()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainScene");
    }

    public void RuleUIActiveBTN()
    {
        GameObject.Find("Canvas").transform.Find("RuleUI").gameObject.SetActive(true);
        GameObject.Find("Canvas").transform.Find("title").gameObject.SetActive(false);
    }
    public void RuleUIActiveBTN1()
    {
        GameObject.Find("Canvas").transform.Find("RuleUI").gameObject.SetActive(false);
        GameObject.Find("Canvas").transform.Find("RuleUI1").gameObject.SetActive(true);
    }
    public void RuleUIActiveBTN2()
    {
        GameObject.Find("Canvas").transform.Find("RuleUI1").gameObject.SetActive(false);
        GameObject.Find("Canvas").transform.Find("RuleUI2").gameObject.SetActive(true);
    }
    public void RuleUIActiveBTN3()
    {
        GameObject.Find("Canvas").transform.Find("RuleUI2").gameObject.SetActive(false);
        GameObject.Find("Canvas").transform.Find("RuleUI3").gameObject.SetActive(true);
    }
    public void RuleUIActiveBTN4()
    {
        GameObject.Find("Canvas").transform.Find("RuleUI3").gameObject.SetActive(false);
        GameObject.Find("Canvas").transform.Find("RuleUI4").gameObject.SetActive(true);
    }
    public void RuleUIActiveBTN5()
    {
        GameObject.Find("Canvas").transform.Find("RuleUI4").gameObject.SetActive(false);
        GameObject.Find("Canvas").transform.Find("RuleUI5").gameObject.SetActive(true);
    }
    public void RuleUIActiveBTN6()
    {
        GameObject.Find("Canvas").transform.Find("RuleUI5").gameObject.SetActive(false);
        GameObject.Find("Canvas").transform.Find("RuleUI6").gameObject.SetActive(true);
    }
    public void RuleUIActiveBTN7()
    {
        GameObject.Find("Canvas").transform.Find("RuleUI6").gameObject.SetActive(false);
        GameObject.Find("Canvas").transform.Find("RuleUI7").gameObject.SetActive(true);
    }

    public void RuleUIUnActivBTN()
    {
        GameObject.Find("Canvas").transform.Find("RuleUI7").gameObject.SetActive(false);
        GameObject.Find("Canvas").transform.Find("title").gameObject.SetActive(true);
    }

    public void ProductUIActiveBTN()
    {
        GameObject.Find("Canvas").transform.Find("ProductUI").gameObject.SetActive(true);
        GameObject.Find("Canvas").transform.Find("title").gameObject.SetActive(false);
    }
    public void ProductUIUnActiveBTN()
    {
        GameObject.Find("Canvas").transform.Find("ProductUI").gameObject.SetActive(false);
    GameObject.Find("Canvas").transform.Find("title").gameObject.SetActive(true);
    }

    public void PauseBTN()
    {
        Time.timeScale = 0;
        GameObject.Find("Canvas").transform.Find("PauseUI").gameObject.SetActive(true);
    }
    public void UnPauseBTN()
    {
        Time.timeScale = 1;
        GameObject.Find("Canvas").transform.Find("PauseUI").gameObject.SetActive(false);
    }

    public void ExitBTN()
    {
        Application.Quit();
    }

}
