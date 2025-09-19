using System;
using UnityEngine;

public class BaseCharacters : MonoBehaviour
{
    public string charName;
    [SerializeField] protected bool overrideDefaults;
    public Attribs attribs;

    public bool isAttacking;
    public Transform tgt;

    
    [System.Serializable]
    public class Attribs
    {
        public float health = -1;
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
        
        // replaced health param with assigning max health as entity's initial health
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

    internal void Start()
    {
        
        
    }

    public virtual void Attack()
    {
        if (tgt.TryGetComponent<BaseCharacters>(out var validTgt))
        {
            if (Vector3.Distance(transform.position, tgt.position) <= attribs.atkRange)
                tgt.GetComponent<BaseCharacters>().GetDmg(attribs.dmg);
            else
                Debug.Log($"{validTgt.charName} is out of range. ");

        }
        else
        {
            Debug.LogWarning($"{tgt.GetComponent<BaseCharacters>().ToString()} lacks script component or " +
                      $"does not inherit from BaseCharacters.");
            
            return;

        }
        
    }

    protected void AlterHealth(float hpChange, bool isHealing = false)
    {
        // attribs.health = Mathf.Clamp(attribs.health + healthChange, attribs.minHealth, attribs.maxHealth);
        attribs.health = Mathf.Clamp(attribs.health + (hpChange * (isHealing ? 1 : -1)), 0, attribs.maxHealth);
        
    }

    // need to tweak algorithm. lower level than opponent should have a damage penalty and higher lever, a boost.
    public virtual void GetDmg(float dmg)
    {
        float calculatedDmg = Mathf.Clamp(dmg - ((attribs.armor / 2f) + (attribs.lvl / 3f)) /
            (dmg / 2), 0f, 9999);
        
        Debug.Log(calculatedDmg);
        AlterHealth(calculatedDmg);
        
    }

    protected virtual void ApplyDefaultAttribs() {}

}
