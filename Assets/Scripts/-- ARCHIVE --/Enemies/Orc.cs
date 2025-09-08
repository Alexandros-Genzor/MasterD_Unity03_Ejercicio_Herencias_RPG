using UnityEngine;

public class Orc : Enemies
{
    // Start is called before the first frame update
    void Start()
    {
        base.Start();

        if (!base.overrideDefaults)
        {
            base.attribs.InitStats(50, 1, 2);
            base.attribs.InitHealth(0, 200);
            base.attribs.isFriendly = false;
            
        }

    }

    // Update is called once per frame
    void Update()
    {
        base.Update();

        if (base.tgt != null && base.isAttacking)
        {
            base.Attack();
            base.isAttacking = false;

        }
        
    }

    protected override void ApplyDefaultAttribs()
    {
        Attribs orcDefaults = new Attribs();
        
        
        
    }
    
}
