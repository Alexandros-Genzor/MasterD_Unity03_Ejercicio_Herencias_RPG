using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enano : Aliados
{
    // Start is called before the first frame update
    void Start()
    {
        vida = 50f;
        armadura = 40f;
        attackRange = 0.5f;
        dmg = 20f;
        canTalk = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        myPosition = transform.position;
        
    }
    
}
