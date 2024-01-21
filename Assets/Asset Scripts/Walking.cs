using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walking : MonoBehaviour
{
    public Transform Cameranya;
    public float sudut;
    public float sudutbawah = 37;
    public float speed;
    bool moveforward;

    private CharacterController cha;
    // Start is called before the first frame update
    void Start()
    {
        cha = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Cameranya.eulerAngles.x >= sudut && Cameranya.eulerAngles.x < sudutbawah)
        {
            moveforward = true;
        }
        else
        {
            moveforward = false;
        }

        if (moveforward)
        {
            Vector3 forward = Cameranya.TransformDirection(Vector3.forward);

            cha.SimpleMove(forward*speed);
        }
    }

}
