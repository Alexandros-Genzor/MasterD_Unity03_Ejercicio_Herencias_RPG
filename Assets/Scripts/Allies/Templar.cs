using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Templar : Allies
{
    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
        
        base.attribs.InitHealth(0, 100);
        base.attribs.InitStats(10, 5, 4, 8);
        
    }

    // Update is called once per frame
    new void Update()
    {
        if (!base.attribs.isDead)
        {
            base.Update();
            
        }
        
    }
    
}
