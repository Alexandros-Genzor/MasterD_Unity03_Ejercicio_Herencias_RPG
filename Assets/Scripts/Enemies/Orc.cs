using UnityEngine;

public class Orc : Enemies
{
    // Start is called before the first frame update
    new void Start()
    {
        base.Start();

        if (!base.overrideDefaults)
        {
            base.attribs.InitHealth(0, 200);
            base.attribs.InitStats(50, 1, 2, 4);
            
        }

    }

    // Update is called once per frame
    new void Update()
    {
        if (!base.attribs.isDead)
        {
            base.Update();
            
            PerformAttack();
            
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

    protected override void ApplyDefaultAttribs()
    {
        Attribs orcDefaults = new Attribs();
        
        
        
    }
    
}
