using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager GM;

    public PlayerControl player;
    public EnemyControl enemy;

    public int playerHealth = 10;
    public int enemyHealth = 10;

    public int playerEnergy = 0;
    public int enemyEnergy = 0;

    public DealCards dealCards;
    public movingCard movingCards;

    public movingCard[] playerCards = new movingCard[3];
    public movingCard[] enemyCards = new movingCard[3];

    public bool isPlayerturn;

    public TextMeshProUGUI enemyHealthUI;
    public TextMeshProUGUI enemyEnergyUI;
    public TextMeshProUGUI playerHealthUI;
    public TextMeshProUGUI playerEnergyUI;


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
            Debug.Log("isplayerturn: " + isPlayerturn);
        }

        if (isPlayerturn == false)
        {
            enemy.AI();
            //StartCoroutine(Resolve());
            checkZone2();
            isPlayerturn = true;
            Debug.Log("isPlayerturn: " + GM.isPlayerturn);
        }
        Debug.Log("CARDS: " + playerCards[2].cards + " / " + enemyCards[2].cards);
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
        movingCard pcard = playerCards[2];
        movingCard ecard = enemyCards[2];
        if (pcard.cards == Cards.attack) 
        {
            playerEnergy--;

            if (ecard.cards == Cards.attack)
            {
                enemyEnergy--;

                playerHealth--;
                enemyHealth--;
            }
            else if (ecard.cards == Cards.defense) 
            {
                Debug.Log("player energy/health: " + playerEnergy + "/ " + playerHealth + " enemy energy/health: " + enemyEnergy + "/ " + enemyHealth);
            }
            else if (ecard.cards == Cards.charge)
            {
                enemyEnergy++;
                enemyHealth--;
                Debug.Log("player energy/health: " + playerEnergy + "/ " + playerHealth + " enemy energy/health: " + enemyEnergy + "/ " + enemyHealth);
            }
            else if (ecard.cards == Cards.superAttack)
            {
                enemyEnergy -= 3;
                enemyHealth--;

                playerHealth -= 2;
                Debug.Log("player energy/health: " + playerEnergy + "/ " + playerHealth + " enemy energy/health: " + enemyEnergy + "/ " + enemyHealth);
            }
        }
        if (pcard.cards == Cards.charge)
        {
            playerEnergy++;

            if (ecard.cards == Cards.attack)
            {
                enemyEnergy--;

                playerHealth--;
                Debug.Log("player energy/health: " + playerEnergy + "/ " + playerHealth + " enemy energy/health: " + enemyEnergy + "/ " + enemyHealth);
            }
            else if (ecard.cards == Cards.defense)
            {
                Debug.Log("player energy/health: " + playerEnergy + "/ " + playerHealth + " enemy energy/health: " + enemyEnergy + "/ " + enemyHealth);
            }
            else if (ecard.cards == Cards.charge)
            {
                enemyEnergy++;
                Debug.Log("player energy/health: " + playerEnergy + "/ " + playerHealth + " enemy energy/health: " + enemyEnergy + "/ " + enemyHealth);
            }
            else if (ecard.cards == Cards.superAttack)
            {
                enemyEnergy -= 3;

                playerHealth -= 2;
                Debug.Log("player energy/health: " + playerEnergy + "/ " + playerHealth + " enemy energy/health: " + enemyEnergy + "/ " + enemyHealth);
            }
        }
        if (pcard.cards == Cards.defense)
        {
            if (ecard.cards == Cards.attack)
            {
                enemyEnergy--;
                Debug.Log("player energy/health: " + playerEnergy + "/ " + playerHealth + " enemy energy/health: " + enemyEnergy + "/ " + enemyHealth);
            }
            else if (ecard.cards == Cards.defense)
            {
                Debug.Log("player energy/health: " + playerEnergy + "/ " + playerHealth + " enemy energy/health: " + enemyEnergy + "/ " + enemyHealth);
            }
            else if (ecard.cards == Cards.charge)
            {
                enemyEnergy++;
                Debug.Log("player energy/health: " + playerEnergy + "/ " + playerHealth + " enemy energy/health: " + enemyEnergy + "/ " + enemyHealth);
            }
            else if (ecard.cards == Cards.superAttack)
            {
                enemyEnergy -= 3;

                playerHealth --;
                Debug.Log("player energy/health: " + playerEnergy + "/ " + playerHealth + " enemy energy/health: " + enemyEnergy + "/ " + enemyHealth);
            }
        }
        if (pcard.cards == Cards.superAttack)
        {
            playerEnergy -= 3;
            if (ecard.cards == Cards.attack)
            {
                enemyEnergy--;

                playerHealth--;
                enemyHealth -= 2;
                Debug.Log("player energy/health: " + playerEnergy + "/ " + playerHealth + " enemy energy/health: " + enemyEnergy + "/ " + enemyHealth);
            }
            else if (ecard.cards == Cards.defense)
            {
                enemyHealth--;
                Debug.Log("player energy/health: " + playerEnergy + "/ " + playerHealth + " enemy energy/health: " + enemyEnergy + "/ " + enemyHealth);
            }
            else if (ecard.cards == Cards.charge)
            {
                enemyEnergy++;
                enemyHealth -= 2;
                Debug.Log("player energy/health: " + playerEnergy + "/ " + playerHealth + " enemy energy/health: " + enemyEnergy + "/ " + enemyHealth);
            }
            else if (ecard.cards == Cards.superAttack)
            {
                enemyEnergy -= 3;
                enemyHealth -= 2;

                playerHealth -= 2;
                Debug.Log("player energy/health: " + playerEnergy + "/ " + playerHealth + " enemy energy/health: " + enemyEnergy + "/ " + enemyHealth);
            }
        }

        enemyHealthUI.text = "Health: " + enemyHealth;
        enemyEnergyUI.text = "Energy: " + enemyEnergy;
        playerHealthUI.text = "Health: " + playerHealth;
        playerEnergyUI.text = "Energy: " + playerEnergy;
    }

    public void checkZone3()
    {

    }
}
