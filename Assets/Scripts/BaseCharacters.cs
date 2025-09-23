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
        public float atkRange;
        public float armor;
        
        public int equipmentLvl; //might not be necessary
        public int lvl;
        
        public bool isIncapacitated;
        public bool isDead;
        public bool isFriendly;
        
        public SceneManager scene;
        public Vector3 pausePos;

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
            
            if (this.health == -1)
                this.health = this.maxHealth;
            
        }

        public void InitStats(float dmg, float armor, float atkRange, int lvl = 1)
        {
            this.dmg = dmg;
            this.armor = armor;
            this.atkRange = atkRange;
            this.lvl = lvl;
            
        }

    }

    internal void Start()
    {
        attribs.scene = GameObject.Find("SceneManager").GetComponent<SceneManager>();
        
    }

    internal void Update()
    {
        UpdatePositions();
        
    }

    private void UpdatePositions()
    {
        if (attribs.scene.pauseScene)
            transform.position = attribs.pausePos;
        else
            attribs.pausePos = transform.position;
        
    }

    public virtual void Attack()
    {
        if (!attribs.scene.pauseScene)
        {
            if (tgt.TryGetComponent<BaseCharacters>(out var validTgt))
            {
                if (Vector3.Distance(transform.position, tgt.position) <= attribs.atkRange && 
                    attribs.isFriendly != tgt.GetComponent<BaseCharacters>().attribs.isFriendly)
                    tgt.GetComponent<BaseCharacters>().GetDmg(attribs.dmg, attribs.lvl);
                else
                    Debug.Log($"{validTgt.charName} is out of range or {this.charName} is about to attack a friendly unit.");

            }
            else
            {
                Debug.LogWarning($"{tgt.GetComponent<BaseCharacters>().ToString()} lacks script component or " +
                                 $"does not inherit from BaseCharacters.");
            
                return;

            }
            
        }
        else
            Debug.Log("Game is paused.");
        
    }

    protected void AlterHealth(float hpChange, bool isHealing = false)
    {
        // attribs.health = Mathf.Clamp(attribs.health + healthChange, attribs.minHealth, attribs.maxHealth);
        attribs.health = Mathf.Clamp(attribs.health + (hpChange * (isHealing ? 1 : -1)), attribs.minHealth, 
            attribs.maxHealth);

        if (attribs.health <= 0)
            attribs.isDead = true;

    }

    // need to tweak algorithm. lower level than opponent should have a damage penalty and higher lever, a boost.
    public virtual void GetDmg(float dmg, float attackerLvl)
    {
        // float calculatedDmg = Mathf.Clamp(dmg - ((attribs.armor / 2f) + (attribs.lvl / 3f)) /
        //     (dmg / 2), 0f, 9999);
        
        float calculatedDmg = Mathf.Clamp((dmg - (attribs.armor / 2f) / (dmg / 2)) * (attackerLvl / attribs.lvl), 
            0f, 9999);

        if (attribs.isIncapacitated)
            calculatedDmg *= 1.5f;
        
        Debug.Log(calculatedDmg);
        AlterHealth(calculatedDmg);
        
    }

    protected virtual void ApplyDefaultAttribs() {}

}
