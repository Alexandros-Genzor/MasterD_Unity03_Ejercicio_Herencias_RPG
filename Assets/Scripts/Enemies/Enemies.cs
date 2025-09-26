using UnityEngine;

public class Enemies : BaseCharacters
{
    // Start is called before the first frame update
    internal new void Start()
    {
        base.Start();
        
        base.attribs.isFriendly = false;
        
        Debug.Log("Enemies");

    }

    internal new void Update()
    {
        base.Update();
        
    }
    
}
