using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioMechineScript : MonoBehaviour
{
    AudioSource AudioMesin;
    public GameObject Avatar;
    public float Distance;
    public float MaxDistanceAudio =25f;
    public float VolumeNow;
    public float MaxVolumeAudio=0.3f;
    public bool Meeting = false;
    public bool Mulai = false;
    // Start is called before the first frame update
    void Start()
    {
        AudioMesin = this.GetComponent<AudioSource>();
        Avatar = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Meeting==false && Mulai == true) //Hidup
        {
            Distance = Vector3.Distance(AudioMesin.gameObject.transform.position, Avatar.transform.position);
            if (Distance > MaxDistanceAudio)
            {
                AudioMesin.volume = 0;
            }
            else
            {
                VolumeNow = (MaxVolumeAudio / MaxDistanceAudio) * Distance;
                AudioMesin.volume = MaxVolumeAudio - VolumeNow;
            }
        }
        else
        {
            AudioMesin.volume = 0;
        }
    }
}
