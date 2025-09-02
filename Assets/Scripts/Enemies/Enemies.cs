using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : BaseCharacters
{
    // Start is called before the first frame update
    protected void Start()
    {
        base.attribs.isFriendly = false;
        
        Debug.Log("Enemies");

    }

    protected void Update()
    {
        
        
    }
    
}
