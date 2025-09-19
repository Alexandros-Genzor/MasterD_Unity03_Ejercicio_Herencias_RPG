using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigos : BasePersonajes
{
    // public float vida, armadura, attackRange, dmg, dmgReceived;
    // public bool canTalk, dead, incapacitado, missionObjetive;
    // public int nivel;
    // public GameObject target;
    // public Vector3 myPosition;

    /*void TakeDamage(float vida, float armadura, float dmgReceived)
    {
        vida = vida + armadura + (attribs.nivel / 3f) - dmgReceived;
        
    }*/
    
    void MakeDmg(GameObject target, Vector3 myPosition, float dmg, bool incapacitado)
    {
        if (Vector3.Distance(target.transform.position, myPosition) <= attribs.attackRange)
        {
            if (!incapacitado)
            {
                dmg = dmg + (attribs.nivel / 3f);
                
            }
            
        }
        
    }
    
    // Start is called before the first frame update
    internal new void Start()
    {
        base.Start();
        
    }

    // Update is called once per frame
    internal void Update()
    {
        if (base.attribs.target != null && base.isAttacking)
        {
            Attack();
            base.isAttacking = false;
            
        }
        
    }
    
}
