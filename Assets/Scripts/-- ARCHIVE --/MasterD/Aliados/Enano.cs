using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enano : Aliados
{

    // function is put way up here for visibility because it contains the class default attributes
    private void AssignDefaults()
    {
        attribs.vida = 50f;
        attribs.vidaMax = 50f;
        attribs.armadura = 40f;
        attribs.attackRange = 2f;
        attribs.dmg = 20f;
        attribs.canTalk = true;
        
    }
    
    // Start is called before the first frame update
    void Start()
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
