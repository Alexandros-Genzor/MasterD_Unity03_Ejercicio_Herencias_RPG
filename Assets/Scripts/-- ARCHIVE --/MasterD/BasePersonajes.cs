using UnityEngine;

public class BasePersonajes : MonoBehaviour
{
    public string charName;
    
    [Tooltip("Allows user to override class-specific attributes with custom ones for the specific unit.")]
    
    public Attribs attribs;

    public bool isAttacking;
    
    [System.Serializable]
    public class Attribs
    {
        public bool overrideDefaults;
        
        public float vida = -1;
        public float vidaMin;
        public float vidaMax;
        
        public float armadura;
        public float attackRange;
        public float dmg;
        public float dmgMult;
        public float dmgReceived;

        public bool canTalk;
        public bool dead;
        public bool incapacitado;
        public bool missionObjetive;
        
        public int nivel;
        
        public GameObject target;
        public Vector3 myPosition;
        
        [SerializeField] internal SceneManager scene;

        /// <summary>
        /// Initializes the character's default current, minimum and maximum health value.
        /// </summary>
        /// <param name="minHp">Sets the character minimum health state (normally 0, AKA: dead)</param>
        /// <param name="maxHp">Sets the character maximum health state.</param>
        /// <param name="hp">[OPTIONAL] Sets the character current health. Typing no value in this parameter will
        /// automatically set the character's current health to equal its maximum health</param>
        public void InitHealth(float minHp, float maxHp, float hp = -1)
        {
            this.vidaMin = minHp;
            this.vidaMax = maxHp;

            this.vida = (hp != -1 ? hp : this.vidaMax);
            
        }

        public void InitHealth()
        {
            if (this.vida == -1f)
                this.vida = this.vidaMax;

        }

        public void InitStats(float dmg, float armor, float atkRange)
        {
            this.dmg = dmg;
            this.armadura = armor;
            this.attackRange = atkRange;
            
        }
        
    }

    protected void Start()
    {
        attribs.scene = GameObject.Find("SceneManager").GetComponent<SceneManager>();
        
    }

    // public virtual void Attack()
    // {
    //     
    //     
    // }
    
    public virtual void Attack()
    {
        if (attribs.target.TryGetComponent<BasePersonajes>(out var validTgt))
        {
            if (Vector3.Distance(transform.position, validTgt.transform.position) <= attribs.attackRange)
                validTgt.GetComponent<BasePersonajes>().TakeDamage(attribs.dmg);
            else
                Debug.Log($"{validTgt.charName} is out of range. ");
            
        }
        else
        {
            Debug.LogWarning($"{attribs.target.GetComponent<BaseCharacters>().ToString()} lacks script component or " +
                             $"does not inherit from BaseCharacters.");

        }
        
    }

    protected void AlterHealth(float hpChange, bool isHealing = false)
    {
        attribs.vida = Mathf.Clamp(attribs.vida + (hpChange * (isHealing ? 1 : -1)), attribs.vidaMin, attribs.vidaMax);
        
    }
    
    /*public virtual void TakeDamage(float vida, float armadura, float dmgReceived)
    {
        // attribs.vida = vida + attribs.armadura + (attribs.nivel / 3f) - dmgReceived;
        AlterHealth(vida + attribs.armadura + (attribs.nivel / 3f) - dmgReceived);
        
        
    }*/
    
    /*armor reduces incoming damage.
     higher level also reduces incoming damage
     
     
     */
    public virtual void TakeDamage(float dmgReceived)
    {
        // attribs.vida = vida + attribs.armadura + (attribs.nivel / 3f) - dmgReceived;

        // float calculatedDmg = Mathf.Clamp((attribs.armadura / 2f) + (attribs.nivel / 3f) - dmgReceived, 
        //     0f, 9999);
        
        // modified damage formula so entity in receiving end's armor and level reduces incoming damage
        // (high armor and high level characters can completely negate incoming damage,
        // possible logic to discourage low level players to "interact" with high level enemies.)
        float calculatedDmg = Mathf.Clamp(dmgReceived - ((attribs.armadura / 2f) + (attribs.nivel / 3f)) /
            (dmgReceived / 2), 0f, 9999);
        
        Debug.Log(calculatedDmg);
        AlterHealth(calculatedDmg);
        
    }

}
