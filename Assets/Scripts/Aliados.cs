using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aliados : MonoBehaviour
{
    public float vida, armadura, attackRange, dmg, dmgReceived;
    public bool canTalk, dead, incapacitado, missionObjetive;
    public int nivel;
    public GameObject target;
    public Vector3 myPosition;
   
    void TakeDamage(float vida,float armadura,float dmgReceived)
    {
        vida = vida + armadura+(nivel/3f) - dmgReceived;
        
    }
    
    void MakeDmg(GameObject target, Vector3 myPosition, float dmg, bool incapacitado )
    {
        if (Vector3.Distance(target.transform.position,myPosition)<=attackRange) {
            if (!incapacitado) 
            {
                dmg = dmg + (nivel / 3f);
                
            }
            
        }
        
    }

    // Start is called before the first frame update
    void Start()
    {
        

    }
    // Update is called once per frame
    void Update()
    {
        
        
    }
    
}
