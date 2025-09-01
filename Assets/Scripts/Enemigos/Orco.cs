using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orco : Enemigos
{
    // Start is called before the first frame update
    void Start()
    {
        vida = 50f;
        armadura = 20f;
        attackRange = 0.5f;
        dmg = 15f;
        canTalk = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        myPosition = transform.position;
        
    }
    
}
