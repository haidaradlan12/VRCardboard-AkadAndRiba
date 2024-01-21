using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControlMouse : MonoBehaviour
{
    float rotationX = 0f;
    float rotationY = 0f;
    public bool Mulai=false;
    public float sensitivity = 15f;
    public GameObject cameranya;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Mulai == true)
        {
            rotationX += Input.GetAxis("Mouse X") * sensitivity;
            rotationY += Input.GetAxis("Mouse Y") * -1 * sensitivity;
            cameranya.transform.localEulerAngles = new Vector3(rotationY, rotationX, 0);
        }        
    }
}
