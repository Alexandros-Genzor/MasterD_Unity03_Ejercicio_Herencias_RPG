using UnityEngine;

public class Allies : BaseCharacters
{
    // Start is called before the first frame update
    internal new void Start()
    {
        base.Start();
        
        base.attribs.isFriendly = true;

    }

    // Update is called once per frame
    internal void Update()
    {
        if (base.tgt != null && base.isAttacking)
        {
            base.Attack();
            base.isAttacking = false;

        }
        
    }
    
}
