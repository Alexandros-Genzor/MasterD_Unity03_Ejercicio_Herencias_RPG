using UnityEngine;

public class Enemies : BaseCharacters
{
    // Start is called before the first frame update
    internal new void Start()
    {
        base.Start();
        
        Debug.Log("Enemies");

    }

    internal new void Update()
    {
        base.Update();
        
        if (base.tgt != null && base.isAttacking)
        {
            base.Attack();
            base.isAttacking = false;

        }
        
    }
    
}
