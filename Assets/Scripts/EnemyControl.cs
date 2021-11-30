using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
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
        if (GameManager.GM.enemyHealth < 5)
        {
            DefensiveMode();
            cards.OnClick();
        }
        else if (GameManager.GM.enemyHealth < 10 & GameManager.GM.enemyHealth >= 5)
        {
            SafeMode();
            cards.OnClick();
        }
    }

    public void DefensiveMode() 
    {

    }

    public void SafeMode()
    {

    }
}
