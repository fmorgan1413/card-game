using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    public GameManager GM;
    public DealCards cards;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AI() 
    {
        if (GM.enemyHealth < 5)
        {
            DefensiveMode();
        }
        else if (GM.enemyHealth <= 10 & GM.enemyHealth >= 5)
        {
            MixedMode();
        }
        else 
        {
            OffensiveMode();
        }
    }

    public void DefensiveMode() 
    {

    }

    public void MixedMode()
    {

    }

    public void OffensiveMode()
    {

    }
}
