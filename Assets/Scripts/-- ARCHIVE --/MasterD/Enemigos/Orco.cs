using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orco : Enemigos
{

    // function is put way up here for visibility because it contains the class default attributes
    private void AssignDefaults()
    {
        attribs.vida = 50f;
        attribs.armadura = 20f;
        attribs.attackRange = 0.5f;
        attribs.dmg = 15f;
        attribs.canTalk = false;
        
    }
    
    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
        
        if (!base.attribs.overrideDefaults)
            AssignDefaults();
        else
            base.attribs.InitHealth();
        
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
        
        attribs.myPosition = transform.position;
        
    }
    
}
