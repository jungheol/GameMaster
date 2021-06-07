using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box_KJS : MonoBehaviour
{
    public GameObject Azone, Bzone, Czone, Dzone;
    public GameObject[] blocks;

    public float scrollSpeed = 6f;


    void Update()
    {
        Azone.transform.Translate(Vector3.left * scrollSpeed * Time.deltaTime);
        Bzone.transform.Translate(Vector3.left * scrollSpeed * Time.deltaTime);
        Czone.transform.Translate(Vector3.right * scrollSpeed * Time.deltaTime);
        Dzone.transform.Translate(Vector3.right * scrollSpeed * Time.deltaTime);
        if (Bzone.transform.position.x < -8f)
        {
            Destroy(Azone);
            Azone = Bzone;
            RandomPlatform(); //Bzone에 플랫폼을 대입하는 함수 호출 --> 새로운 플랫폼 생성한다는 말과 같음
        }
        if (Czone.transform.position.x > 8f)
        {
            Destroy(Dzone);
            Dzone = Czone;
            RandomPlatformL(); //Bzone에 플랫폼을 대입하는 함수 호출 --> 새로운 플랫폼 생성한다는 말과 같음
        }
    }
    void RandomPlatform()
    {
        int index = Random.Range(0, blocks.Length);
        Bzone = Instantiate(blocks[index], new Vector3(40, 3, 0), transform.rotation);

    }
    void RandomPlatformL()
    {
        int index = Random.Range(0, blocks.Length);
        Czone = Instantiate(blocks[index], new Vector3(-40, 3, 0), transform.rotation);

    }
}
