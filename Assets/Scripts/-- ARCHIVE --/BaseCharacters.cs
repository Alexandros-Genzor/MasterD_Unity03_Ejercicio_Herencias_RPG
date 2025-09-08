using UnityEngine;

public class BaseCharacters : MonoBehaviour
{
    public string charName;
    
    public Attribs attribs;

    public bool isAttacking;

    public Transform tgt;

    [SerializeField] protected bool overrideDefaults;
    
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

    public virtual void Attack()
    {
        if (tgt.TryGetComponent<BaseCharacters>(out var validTgt))
        {
            if (Vector3.Distance(transform.position, tgt.position) <= attribs.atkRange)
                tgt.GetComponent<BaseCharacters>().AlterHealth(-attribs.dmg);
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

    protected void AlterHealth(float healthChange)
    {
        attribs.health = Mathf.Clamp(attribs.health + healthChange, attribs.minHealth, attribs.maxHealth);
        
    }

    public virtual void GetDmg(float dmg)
    {
        
        
    }

    protected virtual void ApplyDefaultAttribs() {}

}
