using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Templar : Allies
{
    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        
        base.attribs.InitStats(10, 5, 4);
        base.attribs.InitHealth(0, 100);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (base.tgt != null && base.isAttacking)
        {
            base.Attack();
            base.isAttacking = false;

        }
        
    }
    
}
