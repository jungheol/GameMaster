using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_KJS : MonoBehaviour
{
    Sound sound;
    public GameObject Bullet2;
    public GameObject Sensor;
    public float Speed;
    void Start()
    {
        sound = GetComponent<Sound>();
        Physics.gravity = new Vector3(0,0, 0);
    }
    void Update()
    {
        if (Bullet2.transform.position.x > 0)
        {
            Bullet2.transform.Translate(Vector3.left * Speed * Time.deltaTime);
        }
        else if (Bullet2.transform.position.x < 0)
        {
            Bullet2.transform.Translate(Vector3.right * Speed * Time.deltaTime);
        }
        else if (Bullet2.transform.position.y > 0)
        {
            Bullet2.transform.Translate(Vector3.down * Speed * Time.deltaTime);
        }
        else if (Bullet2.transform.position.y < 0)
        {
            Bullet2.transform.Translate(Vector3.up *Speed * Time.deltaTime);
        }
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "sensor")
        {
            transform.position = (new Vector3(-3, 0, 0));
        }
        if (other.gameObject.name == "sensor (1)")
        {
            transform.position = (new Vector3(3, 0, 0));
        }
        if (other.gameObject.name == "sensor (2)")
        {
            transform.position = (new Vector3(0, -3, 0));
        }
        if (other.gameObject.name == "sensor (3)")
        {
            transform.position = (new Vector3(0, 3, 0));
        }
        if (other.gameObject.name == "guard")
        {
            sound.SoundPlay(0);
            Destroy(Bullet2);
        }
    }

}
