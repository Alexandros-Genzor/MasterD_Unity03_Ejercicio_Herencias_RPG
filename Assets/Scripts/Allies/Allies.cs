using UnityEngine;

public class Allies : BaseCharacters
{
    [SerializeField] protected bool isPlayer;
    [SerializeField] protected bool doPause;
    
    // Start is called before the first frame update
    internal new void Start()
    {
        base.Start();
        
        base.attribs.isFriendly = true;

    }

    // Update is called once per frame
    internal new void Update()
    {
        base.Update();
        
        if (isPlayer)
            base.attribs.scene.pauseScene = doPause;

    }
    
}
