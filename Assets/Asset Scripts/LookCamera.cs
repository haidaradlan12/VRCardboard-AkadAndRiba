using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookCamera : MonoBehaviour
{
    GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 objectHide = new Vector3(Player.transform.position.x, this.transform.position.y, Player.transform.position.z);

        this.transform.LookAt(objectHide);
    }
}
