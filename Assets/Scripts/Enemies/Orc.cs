using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orc : Enemies
{
    // Start is called before the first frame update
    void Start()
    {
        base.Start();

        base.attribs.InitStats(50, 1, 2);
        base.attribs.InitHealth(0, 100);
        
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
        
    }
    
}
