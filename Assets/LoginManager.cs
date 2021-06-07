using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using Newtonsoft.Json.Linq;

public class LoginManager : MonoBehaviour
{
    public InputField id;
    public InputField pw;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoginButton() {
        // ID
        string id = id.text;
        if(id.Equals("")) {
            // Error
            return;
        }

        // PW
        string pw = pw.text;
        if(pw.Length < 8) {
            // Error
            return;
        }

        // Show Progress bar(circle)
        StartCoroutine(LoginButtonRoutine());
    }

    IEnumerator LoginButtonRoutine() {
        // Server Post Request
        WWWForm form = new WWWForm();
		form.AddField("id", id);
		form.AddField("password", pw);
		UnityWebRequest www = UnityWebRequest.Post("http://localhost:3000/login", form);

        yield return www.SendWebRequest();

        if(www.error) {
            // Error
            // 인터넷 연결을 확인해주세요. 
            // 서버 오류가 발생했습니다.
        } else {
            // Response
            string serverResponseString = www.downloadHandler.text;
            JObject serverResponse = JObject.Parse(serverResponseString);

            int serverCode = serverResponse["code"].ToObject<int>();
            if(serverCode == 0) {
                // Login Success 화면전환
            } else if (serverCode == 1) {
                // 존재하지 않는 아이디입니다. 다시 입력해주세요.
            } else if (serverCode == 2) {
                // DB 오류
            } else if (serverCode == 3) {
                // 서버 연결 오류
            } 

        }

        // End Progress bar
    }
}
