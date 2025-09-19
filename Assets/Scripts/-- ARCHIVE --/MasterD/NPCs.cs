using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCs : MonoBehaviour
{
    public List<GameObject> aliados;
    public List<GameObject> enemigos;
    public GameObject entities;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(aliados[0], entities.transform);
        Instantiate(enemigos[0], entities.transform);
        Instantiate(enemigos[1], entities.transform);
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
    
}
