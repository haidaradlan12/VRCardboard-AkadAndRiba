using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LayarLaptopTriggerScript : MonoBehaviour
{
    public GameObject canvasnya;
    public TMP_Text textAwal;
    public TMP_Text textAkhir;
    public bool Mulai = false;
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
        if(other.gameObject.tag == "viewLaptop")
        {
            if (Mulai == true)
            {
                textAkhir.text = textAwal.text;
                canvasnya.GetComponent<Animator>().Play("Layar Laptop");
            }
            
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "viewLaptop")
        {
            if (Mulai == true)
            {
                textAkhir.text = textAwal.text;
                canvasnya.GetComponent<Animator>().Play("Layar Laptop Off");
            }
            
        }
    }
}
