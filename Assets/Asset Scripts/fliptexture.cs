using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fliptexture : MonoBehaviour
{
    Texture2D character;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GUI.DrawTexture(new Rect(Screen.width, 0, -character.width, character.height), character);
    }
    
}
