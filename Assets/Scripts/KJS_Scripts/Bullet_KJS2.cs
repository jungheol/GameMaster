using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_KJS2 : MonoBehaviour
{
    Sound sound;
    public float Speed;
    public GameObject Bullet;
    void Start()
    {
        sound = GetComponent<Sound>();
        Physics.gravity = new Vector3(0, 0, 0);
        
    }
    void Update()
    {
        if (Bullet.transform.position.x > 0)
        {
            Bullet.transform.Translate(Vector3.left * Speed * Time.deltaTime);
        }
        else if (Bullet.transform.position.x < 0)
        {
            Bullet.transform.Translate(Vector3.right * Speed * Time.deltaTime);
        }
        else if (Bullet.transform.position.y > 0)
        {
            Bullet.transform.Translate(Vector3.down * Speed * Time.deltaTime);
        }
        else if (Bullet.transform.position.y < 0)
        {
            Bullet.transform.Translate(Vector3.up * Speed * Time.deltaTime);
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.name == "guard")
        {
            sound.SoundPlay(0);
            Destroy(Bullet);
        }
    }
}
