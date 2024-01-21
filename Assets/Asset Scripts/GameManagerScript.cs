using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Video;
using UnityEngine.Audio;

public class GameManagerScript : MonoBehaviour
{
    public VideoClip[] videoclip;
    public AudioClip[] audioclip;
    public GameObject karakter;
    public GameObject lamp;
    public GameObject videoparent;
    public ArrowStabilizer arrow;
    public Walking walk;
    public TMP_Text information;
    public AudioSource audioparent;
    public float kecepatan=1;
    public string Tujuan;
    public int step = 0;
    public bool one = false;
    bool time = false, time2 = false, time3 = false, time4 = false, time5 = false, time6=false, time7=false, time8=false;
    bool aud = false;
    bool meet = false;
    bool onee = true;
    bool onee2 = true;
    bool onee3 = true;
    int rib;
    [Header("lobby")]
    public GameObject jam;
    public GameObject pintu;
    public GameObject melihat;
    [Header("meetroom")]
    public AudioMechineScript scriptMesinjahit;
    public AudioSource suaramesinjahit;
    public GameObject pintumeet;
    public TMP_Text meetingtext;
    public GameObject charModerator, charAisyah, charFatimah, charAli, PC;
    public GameObject moderator, aisyah, fatimah, ali;
    public GameObject img1, img2, img3, img4, imgdef;
    public GameObject img1L, img2L, img3L, img4L;
    [Header("Production")]
    public GameObject pintu3;
    [Header("Pimpinan")]
    public GameObject pintu4;
    public GameObject folder, busyira;
    public GameObject viewLaptopTrigger;
    public LayarLaptopTriggerScript scriptViewLaptop;
    public GameObject canvaslaporan;
    public AudioClip masuk200;
    public GameObject audioOneClipPlay;
    public GameObject triggerlaptop;
    [Header("Laba")]
    public GameObject truck;
    public AudioClip keuntungantruck;
    public GameObject UIkeuntungan;
    [Header("Menuju Pak Bima")]
    public AudioSource mobil;
    public GameObject mobilnya;
    public GameObject yes, no;
    public int pilihan;
    public AudioSource riba1;
    [Header("kantor pimpinan")]
    public Transform postplayer, postplayer2;
    public TMP_Text layarlaptop;
    public AudioSource riba2;
    public AudioSource kenaparugi;
    public GameObject pilihanlagi, pilihanlagi2;
    public GameObject penting;
    Vector3 savepenting;
    // Start is called before the first frame update
    void Start()
    {
        savepenting = penting.transform.localPosition;
        busyira.SetActive(false);
        triggerlaptop.SetActive(false);
        postplayer.gameObject.SetActive(true);
        postplayer2.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (step == 0)
        {
            videoOn(0);
            step = 1;
        }
        else if (step == 1)
        {
            cekvideo();
        }
        else if (step == 2)
        {
            walk.speed = 0;
            audioparent.PlayOneShot(audioclip[0]);
            one = true;
            step = 3;
        }
        else if (step == 3)
        {
            cekaudio(0);
        }
        else if (step == 4)
        {
            informationOn("Menuju Lobby Kantor");
            PanahON("S1_Menuju Kantor");
            walk.speed = 2;
        }
        else if (step == 5)
        {
            pintu.GetComponent<Animator>().Play("Buka");
            walk.speed = 0;
        }
        else if (step==6)
        {
            informationOn("Masuk Lobby");
            PanahON("S1_Menuju Kantor (1)");
            walk.speed = 2;
        }
        else if (step == 7)
        {
            informationOn("Duduk di sofa");
            PanahON("S1_Menuju Kantor (2)");
            walk.speed = 2;
            time = true;
        }
        else if (step == 8)
        {
            informationOn("");
            PanahOFF();
            walk.speed = 0;
            StartCoroutine(delaynya(3));
        }
        else if (step == 9)
        {
            melihat.SetActive(true);
            informationOn("Melihat Jam");
        }
        else if (step == 10)
        {
            melihat.SetActive(false);
            if (onee == true)
            {
                suaramesinjahit.Play();
                onee = false;            
            }            
            scriptMesinjahit.Mulai = true;
            PanahON("Menuju Meet Room");
            informationOn("Menuju Meeting Room");
            walk.speed = 2;
        }
        else if (step == 11)
        {
            pintumeet.GetComponent<Animator>().Play("Buka");
            walk.speed = 0;
        }
        else if (step == 11)
        {
            PanahON("Menuju Meet Room (1)");
            informationOn("Masuki Ruang Meeting");
            walk.speed = 2;
        }
        else if (step == 12)
        {
            PanahON("Menuju Meet Room (2)");
            informationOn("Ikuti Meeting");
            walk.speed = 2;
        }
        //meeting
        else if (step == 13)
        {
            scriptMesinjahit.Mulai = false;
            pintumeet.GetComponent<Animator>().Play("Tutup");
            imgdef.SetActive(false);
            img1.SetActive(true);
            img1L.SetActive(true);
            walk.speed = 0;
            PanahOFF();
            informationOn("");
            audioparent.PlayOneShot(audioclip[1]);
            one = true;
            step = 14;
        }
        else if (step == 14)
        {
            cekaudio(1);
        }
        else if (step == 15)
        {
            if (one == false)
            {
                CancelInvoke();
                step = 16;
            }
        }
        
        else if (step == 16)
        {
            audioparent.PlayOneShot(audioclip[2]);
            one = true;
            step = 17;
        }
        else if (step == 17)
        {
            cekaudio(2);
        }
        else if (step == 18)
        {
            if (one == false)
            {
                CancelInvoke();
                step = 19;
            }
        }
        
        else if (step == 19)
        {
            moderator.SetActive(true);
            audioparent.PlayOneShot(audioclip[3]);
            one = true;
            step = 20;
        }
        else if (step == 20)
        {
            cekaudio(3);
        }
        else if (step == 21)
        {
            if (one == false)
            {
                CancelInvoke();
                step = 22;
            }
        }
        
        else if (step == 22)
        {
            moderator.SetActive(true);
            audioparent.PlayOneShot(audioclip[4]);
            one = true;
            step = 23;
        }
        else if (step == 23)
        {
            cekaudio(4);
        }
        else if (step == 24)
        {
            if (one == false)
            {
                CancelInvoke();
                step = 25;
            }
        }
        
        else if (step == 25)
        {
            moderator.SetActive(false);
            aisyah.SetActive(true);
            audioparent.PlayOneShot(audioclip[5]);
            one = true;
            step = 26;
            img1.SetActive(false);
            img2.SetActive(true);
            img1L.SetActive(false);
            img2L.SetActive(true);
        }
        else if (step == 26)
        {
            cekaudio(5);
        }
        else if (step == 27)
        {
            if (one == false)
            {
                CancelInvoke();
                step = 28;
            }
        }
        
        else if (step == 28)
        {
            aisyah.SetActive(true);
            audioparent.PlayOneShot(audioclip[6]);
            one = true;
            step = 29;
        }
        else if (step == 29)
        {
            cekaudio(6);
        }
        else if (step == 30)
        {
            if (one == false)
            {
                CancelInvoke();
                step = 31;
            }
        }
        
        else if (step == 31)
        {
            aisyah.SetActive(false);
            ali.SetActive(true);
            audioparent.PlayOneShot(audioclip[7]);
            one = true;
            step = 32;
            img2.SetActive(false);
            img3.SetActive(true);
            img2L.SetActive(false);
            img3L.SetActive(true);
        }
        else if (step == 32)
        {
            cekaudio(7);
        }
        else if (step == 33)
        {
            if (one == false)
            {
                CancelInvoke();
                step = 34;
            }
        }
        
        
        else if (step == 34)
        {
            ali.SetActive(false);
            fatimah.SetActive(true);
            audioparent.PlayOneShot(audioclip[8]);
            one = true;
            step = 35;
            img3.SetActive(false);
            img4.SetActive(true);
            img3L.SetActive(false);
            img4L.SetActive(true);
        }
        else if (step == 35)
        {
            cekaudio(8);
        }
        else if (step == 36)
        {
            if (one == false)
            {
                CancelInvoke();
                step = 37;
            }
        }
        
        else if (step == 37)
        {
            fatimah.SetActive(true);
            audioparent.PlayOneShot(audioclip[9]);
            one = true;
            step = 38;
        }
        else if (step == 38)
        {
            cekaudio(9);
        }
        else if (step == 39)
        {
            if (one == false)
            {
                CancelInvoke();
                step = 40;
            }
        }
        
        else if (step == 40)
        {
            fatimah.SetActive(false);
            moderator.SetActive(true);
            audioparent.PlayOneShot(audioclip[10]);
            one = true;
            step = 41;
            img4.SetActive(false);
            img1.SetActive(true);
            img4L.SetActive(false);
            img1L.SetActive(true);
        }
        else if (step == 41)
        {
            cekaudio(10);
        }
        else if (step == 42)
        {
            if (one == false)
            {
                CancelInvoke();
                step = 43;
            }
        }
        
        else if (step == 43)
        {

            moderator.SetActive(false);
            audioparent.PlayOneShot(audioclip[11]);
            one = true;
            step = 44;
        }
        else if (step == 44)
        {
            cekaudio(11);
        }
        else if (step == 45)
        {
            if (one == false)
            {
                CancelInvoke();
                step = 46;
            }
        }
        
        else if (step == 46)
        {
            audioparent.PlayOneShot(audioclip[12]);
            one = true;
            step = 47;
        }
        else if (step == 47)
        {
            cekaudio(12);
        }
        else if (step == 48)
        {
            if (one == false)
            {
                CancelInvoke();
                step = 49;
            }
        }
        
        else if (step == 49)
        {
            moderator.SetActive(true);
            audioparent.PlayOneShot(audioclip[13]);
            one = true;
            step = 50;
        }
        else if (step == 50)
        {
            cekaudio(13);
        }
        else if (step == 51)
        {
            if (one == false)
            {
                CancelInvoke();
                step = 52;
            }
        }
        
        else if (step == 52)
        {
            moderator.SetActive(false);
            aisyah.SetActive(false);
            fatimah.SetActive(false);
            audioparent.PlayOneShot(audioclip[14]);
            one = true;
            step = 53;
        }
        else if (step == 53)
        {
            cekaudio(14);
        }
        else if (step == 54)
        {
            if (one == false)
            {
                CancelInvoke();
                step = 55;
            }
        }
        
        else if (step == 55)
        {
            ali.SetActive(true);
            audioparent.PlayOneShot(audioclip[15]);
            one = true;
            step = 56;
        }
        else if (step == 56)
        {
            cekaudio(15);
        }
        else if (step == 57)
        {
            if (one == false)
            {
                CancelInvoke();
                step = 58;
            }
        }
        //
        else if (step == 58)
        {
            scriptMesinjahit.Mulai = true;
            ali.SetActive(false);
            PanahON("Menuju Production");
            informationOn("Menuju Production Room");
            walk.speed = 2;
        }
        else if (step == 59)
        {
            pintu3.GetComponent<Animator>().Play("Buka");
            walk.speed = 0;
        }
        else if (step == 60)
        {
            informationOn("Menuju Production Room");
            PanahON("Menuju Production (1)");
            walk.speed = 2;
        }
        else if (step == 61)
        {
            pintu3.GetComponent<Animator>().Play("Tutup");
            informationOn("Menuju Production Room");
            PanahON("Menuju Production (2)");
            walk.speed = 2;
        }
        else if (step == 62)
        {
            informationOn("Menuju Production Room");
            PanahON("Menuju Production (3)");
            imgdef.SetActive(true);
            img1.SetActive(false);
            img2.SetActive(false);
            img3.SetActive(false);
            img4.SetActive(false);
            charModerator.SetActive(false);
            charAisyah.SetActive(false);
            charFatimah.SetActive(false);
            charAli.SetActive(false);
            PC.SetActive(false);
            meetingtext.text = "Hidup Berkah" + System.Environment.NewLine + "Hindari Riba";
            walk.speed = 2;
        }
        else if (step == 63)
        {
            informationOn("Menuju Production Room");
            PanahON("Menuju Production (4)");
            walk.speed = 2;
        }
        else if (step == 64)
        {
            informationOn("Masuk Production Room");
            PanahON("Menuju Production (5)");
            walk.speed = 2;
            one = true;
        }
        else if (step == 65)
        {
            videoOn(1);
            informationOn("");
            PanahOFF();
            walk.speed = 0;
            step = 66;
        }
        else if (step == 66)
        {
            cekvideo();
        }
        else if (step == 67)
        {
            step = 68;
        }
        else if (step == 68)
        {
            videoOn(2);
            informationOn("");
            PanahOFF();
            walk.speed = 0;
            step = 69;
        }
        else if (step == 69)
        {
            cekvideo();
        }
        else if (step == 70)
        {
            step = 71;
        }
        else if (step == 71)
        {
            informationOn("Menuju Ruang Pimpinan");
            PanahON("Menuju Pimpinan");
            walk.speed = 2;
        }
        else if (step == 72)
        {
            informationOn("Menuju Ruang Pimpinan");
            PanahON("Menuju Pimpinan (1)");
            walk.speed = 2;
        }
        else if (step == 73)
        {
            informationOn("Menuju Ruang Pimpinan");
            PanahON("Menuju Pimpinan (2)");
            walk.speed = 2;
        }
        else if (step == 74)
        {
            folder.SetActive(false);
            busyira.SetActive(true);
            canvaslaporan.SetActive(false);
            informationOn("Menuju Ruang Pimpinan");
            PanahON("Menuju Pimpinan (3)");
            walk.speed = 2;
        }
        else if (step == 75)
        {
            pintu4.GetComponent<Animator>().Play("Buka");
            informationOn("Masuk Ruang Pimpinan");
            walk.speed = 0;
        }
        else if (step == 76)
        {
            informationOn("Masuk Ruang Pimpinan");
            PanahON("Menuju Pimpinan (4)");
            walk.speed = 2;
        }
        else if (step == 77)
        {
            scriptMesinjahit.Mulai = false;
            pintu4.GetComponent<Animator>().Play("Tutup");
            informationOn("Duduk di sofa");
            PanahON("Menuju Pimpinan (5)");
            walk.speed = 2;
        }
        else if (step == 78)
        {
            videoOn(3);
            informationOn("");
            PanahOFF();
            walk.speed = 0;
            step = 79;
        }
        else if (step == 79)
        {
            cekvideo();
        }
        else if (step == 80)
        {
            penting.transform.localPosition = new Vector3(savepenting.x, savepenting.y, 0.2f);
            walk.speed = 0;
            folder.SetActive(true);
            informationOn("Setujui perjanjian, pusatkan pandangan ke dokumen perjanjian");
            PanahON("folder (1)");
        }
        else if (step == 81)
        {
            videoOn(4);
            informationOn("");
            PanahOFF();
            walk.speed = 0;
            step = 82;
        }
        else if (step == 82)
        {
            walk.speed = 0;
            cekvideo();
        }
        else if (step == 83)
        {
            busyira.SetActive(false);
            step = 84;
        }
        else if (step == 84)
        {
            scriptMesinjahit.Mulai = true;
            informationOn("Menuju ke meja kerja");
            PanahON("Menuju Pimpinan (6)");
            walk.speed = 2;
        }
        else if (step == 85)
        {
            GameObject.Find("Menuju Pimpinan (6)").SetActive(false);
            audioOneClipPlay.GetComponent<AudioSource>().PlayOneShot(masuk200);
            informationOn("Kredit rekening masuk senilai Rp200.000.000,00 dari rekening Syira Shahibul Maal");
            PanahOFF();
            walk.speed = 0;
            time2 = false; 
            step = 86;

        }
        else if (step == 86)
        {
            time2 = true;
            StartCoroutine(delaynya2(5));
        }
        else if (step == 87)
        {
            penting.transform.localPosition = savepenting;
            step = 88;
        }
        else if (step == 88)
        {
            informationOn("6 bulan kemudian");
            time3 = true;
            step = 89;
        }
        else if (step == 89)
        {
            StartCoroutine(delaynya3(6));
        }
        else if (step == 90)
        {
            step = 92;
        }
        else if (step == 92)
        {
            melihat.SetActive(true);
            informationOn("lihat laptop");
        }
        else if (step == 93)
        {
            melihat.SetActive(false);
            viewLaptopTrigger.SetActive(true);
            scriptViewLaptop.Mulai = true;
            canvaslaporan.SetActive(true);
            step = 94;
            time5 = true;
        }
        else if (step == 94)
        {
            StartCoroutine(delaynya5(5));
        }
        else if (step == 95)
        {
            viewLaptopTrigger.SetActive(false);
            scriptViewLaptop.Mulai = false;
            scriptViewLaptop.canvasnya.GetComponent<Animator>().Play("Layar Laptop Off");
            informationOn("Keluar gedung, ada truck muatan datang");
            PanahON("Menuju Truck");
            walk.speed = 0.5f;
        }
        else if (step == 96)
        {
            pintu4.GetComponent<Animator>().Play("Buka");
            informationOn("Keluar gedung, ada truck muatan datang");
            walk.speed = 0;
        }
        else if (step == 97)
        {
            truck.SetActive(true);
            informationOn("Keluar gedung, ada truck muatan datang");
            PanahON("Menuju Truck (1)");
            walk.speed = 1;
        }
        else if (step == 98)
        {
            informationOn("Keluar gedung, ada truck muatan datang");
            PanahON("Menuju Truck (2)");
            walk.speed = 2;
        }
        else if (step == 99)
        {
            informationOn("Keluar gedung, ada truck muatan datang");
            PanahON("Menuju Truck (3)");
            walk.speed = 2;
        }
        else if (step == 100)
        {
            informationOn("Keluar gedung, ada truck muatan datang");
            PanahON("Menuju Truck (4)");
            walk.speed = 2;
        }
        else if (step == 101)
        {
            informationOn("Keluar gedung, ada truck muatan datang");
            PanahON("Menuju Truck (5)");
            walk.speed = 2;
            time4 = true;
        }
        else if (step == 102)
        {
            if (onee2 == true)
            {
                audioOneClipPlay.GetComponent<AudioSource>().PlayOneShot(keuntungantruck);
                onee2 = false;
            }            
            UIkeuntungan.SetActive(true);
            informationOn("Income Thoyib Ahmad bertambah Rp75.000.000,00");
            PanahOFF();
            walk.speed = 0;
            StartCoroutine(delaynya4(10));
        }
        //menuju mobil
        else if (step == 103)
        {
            PanahON("Mobil");
            informationOn("Ke Mobil, menuju kantor Ryan Corp");
            walk.speed = 1;
        }
        else if (step == 104)
        {
            PanahOFF();
            UIkeuntungan.SetActive(false);
            informationOn("Perjalanan ke Kantor Ryan Corp");
            walk.speed = 0;
            step = 105;
        }
        else if (step == 105)
        {
            melihat.SetActive(false);
            suaramesinjahit.Stop();
            if (onee3 == true)
            {
                mobil.Play();
                onee3 = false;
            }            
            karakter.transform.position = Vector3.MoveTowards(karakter.transform.position, GameObject.Find("Kantor Pak Bima").transform.position, kecepatan * Time.deltaTime);
            //PanahON("Kantor Pak Bima");
            GameObject.Find("Mobil").SetActive(false);
        }
        else if (step == 106)
        {
            karakter.transform.position = Vector3.MoveTowards(karakter.transform.position, GameObject.Find("Kantor Pak Bima (1)").transform.position, kecepatan * Time.deltaTime);
            //PanahON("Kantor Pak Bima (1)");

        }
        else if (step == 107)
        {
            karakter.transform.position = Vector3.MoveTowards(karakter.transform.position, GameObject.Find("Kantor Pak Bima (2)").transform.position, kecepatan * Time.deltaTime);
            //PanahON("Kantor Pak Bima (2)");

        }
        else if (step == 108)
        {
            karakter.transform.position = Vector3.MoveTowards(karakter.transform.position, GameObject.Find("Kantor Pak Bima (3)").transform.position, kecepatan * Time.deltaTime);
            //PanahON("Kantor Pak Bima (3)");
            
        }
        else if (step == 109)
        {
            informationOn("Ke kantor Ryan Corp");
            PanahON("Kantor Pak Bima (4)");
            mobil.Stop();
            mobilnya.SetActive(true);
            walk.speed = 2;
        }
        else if (step == 110)
        {
            informationOn("Naik Tangga");
            PanahON("Kantor Pak Bima (5)");
            walk.speed = 1f;
        }
        else if (step == 111)
        {
            informationOn("Masuk Ruangan");
            PanahON("Kantor Pak Bima (6)");
            walk.speed = 1f;
        }
        else if (step == 112)
        {
            informationOn("Duduk di sofa");
            PanahON("Kantor Pak Bima (7)");
            walk.speed = 1f;
        }
        else if (step == 113)
        {
            videoOn(5);
            informationOn("");
            PanahOFF();
            walk.speed = 0;
            step = 114;
        }
        else if (step == 114)
        {
            walk.speed = 0;
            cekvideo();
        }
        else if (step == 115)
        {
            aud = true;
            step = 116;
        }
        else if (step == 116)
        {
            if (aud == true)
            {
                riba1.PlayOneShot(riba1.clip);
                aud =false;
            }
            informationOn("pilih setuju atau tidak pada perjanjian");
            yes.SetActive(true);
            no.SetActive(true);
            walk.speed = 0;
        }
        //pilihan
        else if (step == 117)
        {
            postplayer.gameObject.SetActive(true);
            postplayer2.gameObject.SetActive(true);
            if (pilihan == 1) // yes
            {
                aud = true;
                rib += 1;
                step = 122;
                viewLaptopTrigger.SetActive(true);
                scriptViewLaptop.Mulai = true;
            }
            else if (pilihan == 2) // no
            {
                step = 118;
                viewLaptopTrigger.SetActive(false);
                scriptViewLaptop.Mulai = false;
            }
        }
        //No
        else if (step == 118)
        {
            scriptViewLaptop.canvasnya.GetComponent<Animator>().Play("Layar Laptop Off");
            postplayer.gameObject.SetActive(false);
            postplayer2.gameObject.SetActive(false);
            karakter.transform.position = postplayer.position;
            videoOn(6);
            informationOn("");
            PanahOFF();
            walk.speed = 0;
            step = 119;
        }
        else if (step == 119)
        {
            walk.speed = 0;
            cekvideo();
        }
        else if (step == 120)
        {
            walk.speed = 0;
            step = 121;
        }
        else if (step == 121)
        {
            pintu4.GetComponent<Animator>().Play("Tutup");
            walk.speed = 0;
            aud = true;
            step = 125;
        }
        //Yes
        else if (step == 122)
        {
            karakter.transform.position = postplayer2.position;
            walk.speed = 0;
            
            informationOn("Perhatikan Laporan Keuangan di Laptop");
            canvaslaporan.gameObject.SetActive(true);
            layarlaptop.text = "Anda Mendapatkan Laba Rp.50.000.000,00";
            if (aud == true)
            {
                riba2.PlayOneShot(riba2.clip);
                aud = false;
            }
            time6 = true;
            step = 123;
        }
        else if (step == 123)
        {
            informationOn("Perhatikan Laporan Keuangan di Laptop");
            canvaslaporan.gameObject.SetActive(true);
            layarlaptop.text = "Anda Mendapatkan Laba Rp.50.000.000,00";
            StartCoroutine(delaynya6(7));
        }
        else if (step == 124)
        {
            karakter.transform.position = postplayer.position;
            step = 118;
        }
        //lanjutan
        else if (step == 125)
        {
            viewLaptopTrigger.SetActive(false);
            scriptViewLaptop.Mulai = false;
            scriptViewLaptop.canvasnya.GetComponent<Animator>().Play("Layar Laptop Off");
            postplayer.gameObject.SetActive(false);
            postplayer2.gameObject.SetActive(false);
            informationOn("Keluar Ruangan");
            PanahON("Ending (0)");
            walk.speed = 1f;
        }
        else if (step == 126)
        {
            pintu4.GetComponent<Animator>().Play("Buka");
            walk.speed = 0;
        }
        else if (step == 127)
        {
            informationOn("Keluar Ruangan");
            PanahON("Ending (1)");
            walk.speed = 1f;
        }
        else if (step == 128)
        {
            walk.speed = 0;
            PanahOFF();
            informationOn("Ekspor produk telah dilakukan");
            time7 = true;
            step = 129;
        }
        else if (step == 129)
        {
            walk.speed = 0;
            StartCoroutine(delaynya7(3));
        }
        else if (step == 130)
        {
            viewLaptopTrigger.SetActive(true);
            scriptViewLaptop.Mulai = true;
            informationOn("Lihat laporan keuangan di laptop");
            canvaslaporan.gameObject.SetActive(true);
            layarlaptop.text = "Kerugian sebesar Rp60.0000.000,00";
            PanahON("Ending (2)");
            aud = true;
            walk.speed = 1f;
        }
        else if (step == 131)
        {
            walk.speed = 0;
            if (aud == true)
            {
                kenaparugi.PlayOneShot(kenaparugi.clip);
                aud = false;
            }
            time8 = true;
            step = 132;
        }
        else if (step == 132)
        {
            walk.speed = 0;
            StartCoroutine(delaynya8(10));
        }
        else if (step == 133)
        {
            step = 134;
        }
        //pilihan
        else if (step == 134)
        {
            viewLaptopTrigger.SetActive(false);
            scriptViewLaptop.Mulai = false;
            scriptViewLaptop.canvasnya.GetComponent<Animator>().Play("Layar Laptop Off");
            walk.speed = 0;
            informationOn("");
            layarlaptop.text = "";
            pilihanlagi.SetActive(true);
            pilihanlagi2.SetActive(true);
        }
        else if (step == 135)
        {
            walk.speed = 0;
            if (pilihan == 1) // 1
            {
                rib += 1;
                step = 136;
            }
            else if (pilihan == 2) // 2
            {
                step = 139;
            }
        }
        else if (step == 136) // 1
        {
            videoOn(7);
            informationOn("");
            PanahOFF();
            walk.speed = 0;
            step = 137;
        }
        else if (step == 137)
        {
            walk.speed = 0;
            cekvideo();
        }
        else if (step == 138)
        {
            walk.speed = 0;
            //step = 121;
            step = 150;
        }
        else if (step == 139) // 2
        {
            videoOn(8);
            informationOn("");
            PanahOFF();
            walk.speed = 0;
            step = 140;
        }
        else if (step == 140)
        {
            walk.speed = 0;
            cekvideo();
        }
        else if (step == 141)
        {
            walk.speed = 0;
            //step = 121;
            step = 150;
        }
        //ending
        else if (step == 150)
        {
            walk.speed = 1;
            if (rib == 0)
            {
                informationOn("Ahmad terselamatkan dari Riba" + System.Environment.NewLine + "Permainan Selesai");
            }
            else
            {
                informationOn("Ahmad melakukan Riba sebanyak : "+ rib + System.Environment.NewLine + "Permainan Selesai");
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == Tujuan)
        {
            step += 1;
        }
    }
    public void informationOn(string info)
    {
        information.gameObject.SetActive(true);
        information.text = info;
    }
    public void PanahON(string tujuan)
    {
        arrow.gameObject.SetActive(true);
        Tujuan = tujuan;
        arrow.objectnamelook = Tujuan;
        arrow.aktif = true;
    }
    public void PanahOFF()
    {
        arrow.gameObject.SetActive(false);
        Tujuan = "";
        arrow.objectnamelook = Tujuan;
        arrow.aktif = false;

    }
    public void videoOn(int num)
    {
        videoparent.transform.GetChild(1).GetComponent<VideoPlayer>().clip = videoclip[num];
        videoparent.transform.GetChild(1).GetComponent<VideoPlayer>().Play();
        arrow.gameObject.SetActive(false);
        videoparent.gameObject.SetActive(true);
        walk.speed = 0;
        lamp.SetActive(false);
        information.gameObject.SetActive(false);
        one = true;
    }
    public void videoOff()
    {
        videoparent.transform.GetChild(1).GetComponent<VideoPlayer>().Stop();
        videoparent.gameObject.SetActive(false);
        walk.speed = 5;
        lamp.SetActive(true);
        if (one == true)
        {
            step += 1;
            one = false;
        }
    }
    public void cekvideo()
    {
        videoparent.transform.GetChild(1).GetComponent<VideoPlayer>().loopPointReached += isVideoOver; 
    }
    void isVideoOver(VideoPlayer vp)
    {
        videoOff();
    }
    public void cekaudio(int num)
    {
        Invoke("isAudioOver", audioclip[num].length);
    }
    public void cekaudiospesific(AudioClip audio)
    {
        Invoke("isAudioOver", audio.length);
    }
    void isAudioOver()
    {
        if (one == true)
        {
            step += 1;
            one = false;
        }
    }
    IEnumerator delaynya(int num)
    {
        yield return new WaitForSeconds(num);
        if (time == true)
        {
            step += 1;
            time = false;
        }
    }
    IEnumerator delaynya2(int num)
    {
        yield return new WaitForSeconds(num);
        if (time2 == true)
        {
            step += 1;
            time2 = false;
        }
    }
    IEnumerator delaynya3(int num)
    {
        yield return new WaitForSeconds(num);
        if (time3 == true)
        {
            step += 1;
            time3 = false;
        }
    }
    IEnumerator delaynya4(int num)
    {
        yield return new WaitForSeconds(num);
        if (time4 == true)
        {
            step += 1;
            time4 = false;
        }
    }
    IEnumerator delaynya5(int num)
    {
        yield return new WaitForSeconds(num);
        if (time5 == true)
        {
            step += 1;
            time5 = false;
        }
    }
    IEnumerator delaynya6(int num)
    {
        yield return new WaitForSeconds(num);
        if (time6 == true)
        {
            step += 1;
            time6 = false;
        }
    }
    IEnumerator delaynya7(int num)
    {
        yield return new WaitForSeconds(num);
        if (time7 == true)
        {
            step += 1;
            time7 = false;
        }
    }
    IEnumerator delaynya8(int num)
    {
        yield return new WaitForSeconds(num);
        if (time8 == true)
        {
            step += 1;
            time8 = false;
        }
    }
}
