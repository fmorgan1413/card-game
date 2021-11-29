using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager GM;

    public PlayerControl player;
    public EnemyControl enemy;

    public int plyerHealth = 10;
    public int enemyHealth = 10;

    public int playerEnergy = 0;
    public int enemyEnergy = 0;

    public DealCards dealCards;
    public movingCard movingCards;

    public bool isPlayerturn;

    private void Awake()
    {
        GM = this;
        isPlayerturn = true;
    }
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("isPlayerturn: " + isPlayerturn);
    }

    public void EndTurn() 
    {
        if (isPlayerturn == true)
        {
            isPlayerturn = false;
            Debug.Log("isPlayerturn: " + isPlayerturn);
        }

        if (isPlayerturn == false)
        {
            enemy.AI();
            StartCoroutine(Resolve());
            isPlayerturn = true;
            Debug.Log("isPlayerturn: " + GM.isPlayerturn);
        }
    }

    public IEnumerator Resolve() 
    {
        //resolve cards, health, and energy in here

        yield return null;
    }

    public void checkZone1() 
    {

        
    }

    public void checkZone2()
    {

    }

    public void checkZone3()
    {

    }
}
