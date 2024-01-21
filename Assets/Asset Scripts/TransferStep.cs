using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransferStep : MonoBehaviour
{
    public int num; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void kirimstep()
    {
        FindObjectOfType<GameManagerScript>().step +=1;
    }
    public void kirimpilihanakhmad()
    {
        FindObjectOfType<GameManagerScript>().step += 1;
        FindObjectOfType<GameManagerScript>().pilihan=num;
    }
}
