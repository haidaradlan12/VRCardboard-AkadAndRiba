using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowStabilizer : MonoBehaviour
{
    public GameObject cameranya;
    public GameObject parentArrow;
    public GameObject arrow;
    public string objectnamelook;
    public GameObject objectlook;
    public bool aktif = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (aktif == true)
        {
            arrow.GetComponentInChildren<MeshRenderer>().enabled = true;
            objectlook = GameObject.Find(objectnamelook);
            parentArrow.transform.LookAt(objectlook.transform);
            this.transform.eulerAngles = new Vector3(this.transform.eulerAngles.x, cameranya.transform.eulerAngles.y, this.transform.eulerAngles.z);
        }
        else
        {
            arrow.GetComponentInChildren<MeshRenderer>().enabled = false;
        }
    }
}
