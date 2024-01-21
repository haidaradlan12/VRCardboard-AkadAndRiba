using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerStep : MonoBehaviour
{
    public string nametag;
    bool mulai = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == nametag)
        {
            if (mulai == true)
            {
                FindObjectOfType<GameManagerScript>().step += 1;
                mulai = false;
            }
            
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == nametag)
        {
            if (mulai == true)
            {
                FindObjectOfType<GameManagerScript>().step += 1;
                mulai = false;
            }

        }
    }
}
