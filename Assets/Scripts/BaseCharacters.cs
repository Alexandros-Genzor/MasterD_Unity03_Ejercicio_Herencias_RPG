using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class BaseCharacters : MonoBehaviour
{
    public string charName;
    
    public Attribs attribs;

    public Transform tgt;
    
    [System.Serializable]
    public class Attribs
    {
        public float health;
        public float minHealth;
        public float maxHealth;

        public float dmg;
        public float armor;
        public float atkRange;
        
        public int equipmentLvl;
        public int lvl;
        
        public bool isIncapacitated;
        public bool isDead;
        public bool isFriendly;

        /*public void InitHealth(float health, float minHealth, float maxHealth)
        {
            this.health = health;
            this.minHealth = minHealth;
            this.maxHealth = maxHealth;

        }*/
        
        public void InitHealth(float minHealth, float maxHealth)
        {
            this.minHealth = minHealth;
            this.maxHealth = maxHealth;
            this.health = this.maxHealth;

        }

        public void InitStats(float dmg, float armor, float atkRange)
        {
            this.dmg = dmg;
            this.armor = armor;
            this.atkRange = atkRange;
            
        }

    }

    public virtual void Attack()
    {
        if (tgt.TryGetComponent<BaseCharacters>(out var validTgt))
        {
            if (Vector3.Distance(transform.position, tgt.position) >= attribs.atkRange)
                tgt.GetComponent<BaseCharacters>().AlterHealth(-attribs.dmg);
            else
                Debug.Log($"{this.charName} is out of range. ");
            
        }
        else
        {
            Debug.LogWarning($"{tgt.GetComponent<BaseCharacters>().ToString()} lacks script component or " +
                      $"does not inherit from BaseCharacters.");
            
            return;

        }
        
    }

    public void AlterHealth(float health)
    {
        attribs.health = Mathf.Clamp(attribs.health + health, attribs.minHealth, attribs.maxHealth);
        
    }
    
    /*// Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }*/
    
}
