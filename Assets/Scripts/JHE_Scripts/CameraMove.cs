using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    // Start is called before the first frame update
    public float mouse_speedX = 3.0f;
    public float mouse_speedY = 3.0f;
    float rotationY = 0f;
    
    void Start()
    {
        if (GetComponent<Rigidbody>())
            GetComponent<Rigidbody>().freezeRotation = true;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * mouse_speedX;

        rotationY -= Input.GetAxis("Mouse Y") * mouse_speedY;
        rotationY = Mathf.Clamp(rotationY, -40.0f, 40.0f);

        transform.localEulerAngles = new Vector3(rotationY, rotationX, 0);
    }
}
