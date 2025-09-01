using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Esqueleto : Enemigos
{  
    // Start is called before the first frame update
    void Start()
    {
        vida = 30f;
        armadura = 10f;
        attackRange = 3f;
        dmg = 10f;
        canTalk = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        myPosition= transform.position;
        
    }
    
}
