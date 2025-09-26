using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Druid : Allies
{
    [SerializeField] private float healingPower;
    [SerializeField] private bool isHealing;

    [SerializeField] private Transform healTgt;
    
    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
        
        base.attribs.InitHealth(0, 120);
        base.attribs.InitStats(8, 12, 5, 20);

        healingPower = 20;

    }

    // Update is called once per frame
    new void Update()
    {
        if (!base.attribs.isDead)
        {
            base.Update();
            
            PerformAttack();
            PerformHeal();
            
        }
        
    }
    
    private void PerformAttack()
    {
        if (base.tgt != null && base.isAttacking)
        {
            if (!base.attribs.scene.PauseEnv())
                base.Attack();
            else
                Debug.Log("Game is paused.");
                
            base.isAttacking = false;

        }
        
    }

    private void PerformHeal()
    {
        if (healTgt != null && this.isHealing)
        {
            if (!base.attribs.scene.PauseEnv())
                HealTgt();
            else
                Debug.Log("Game is paused.");
            
            this.isHealing = false;

        }
        
    }

    private void HealTgt()
    {
        if (healTgt.TryGetComponent<BaseCharacters>(out var validHealTgt))
        {
            if (Vector3.Distance(transform.position, validHealTgt.transform.position) <= base.attribs.atkRange &&
                validHealTgt.attribs.isFriendly == base.attribs.isFriendly)
            {
                validHealTgt.GetHealed(healingPower, base.attribs.lvl);
                
            }
            
        }
        else
        {
            Debug.LogWarning($"{tgt.GetComponent<BaseCharacters>().ToString()} lacks script component or " +
                             $"does not inherit from BaseCharacters.");
            
            return;

        }
        
    }
    
}
