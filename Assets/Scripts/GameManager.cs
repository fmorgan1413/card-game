using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

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

    public movingCard[] playerCards = new movingCard[4];
    public movingCard[] enemyCards = new movingCard[4];

    public bool isPlayerturn;

    public TextMeshProUGUI enemyHealthUI;
    public TextMeshProUGUI enemyEnergyUI;
    public TextMeshProUGUI playerHealthUI;
    public TextMeshProUGUI playerEnergyUI;
    public TextMeshProUGUI playerRead;
    public TextMeshProUGUI enemyRead;
    public TextMeshProUGUI enemyEnergyRead;
    public TextMeshProUGUI enemyHealthRead;
    public TextMeshProUGUI playerEnergyRead;
    public TextMeshProUGUI playerHealthRead;

    public GameObject enemyzone;
    public GameObject playerzone;

    private void Awake()
    {
        GM = this;
        isPlayerturn = true;
    }

    void Start()
    {
        Debug.Log("isPlayerturn: " + isPlayerturn);
    }

    public void EndTurn() 
    {
            enemy.AI();
            StartCoroutine(Resolve());

        if (enemyHealth == 0 || playerHealth == 0)
        {
            SceneManager.LoadScene("End");
        }
    }


    public IEnumerator Resolve() 
    {
        checkZone(playerCards[2], enemyCards[2]);
        yield return new WaitForSeconds(1.25f);

        Destroy(playerzone.transform.GetChild(0).gameObject); ;
        Destroy(enemyzone.transform.GetChild(0).gameObject);

        enemy.trashRead.text = "";

        playerRead.text = "";
        enemyRead.text = "";

        playerEnergyRead.text = "";
        enemyEnergyRead.text = "";

        playerHealthRead.text = "";
        enemyHealthRead.text = "";

        yield return null;
    }

    public void checkZone(movingCard pcard, movingCard ecard)
    {
        if (pcard.cards == Cards.attack) 
        {
            if (playerEnergy < 1)
            {
                Debug.Log("you wasted a card");
            }
            else
            {
                playerEnergy--;
                playerEnergyRead.text = "-1";

                if (ecard.cards == Cards.attack)
                {
                    if (enemyEnergy < 1)
                    {
                        Debug.Log("wasted card");
                    }
                    else
                    {
                        enemyEnergy--;
                        enemyEnergyRead.text = "-1";
                    }
                }
                else if (ecard.cards == Cards.defense)
                {
                    Debug.Log("player energy/health: " + playerEnergy + "/ " + playerHealth + " enemy energy/health: " + enemyEnergy + "/ " + enemyHealth);
                }
                else if (ecard.cards == Cards.charge)
                {
                    enemyEnergy++;
                    enemyHealth--;

                    enemyEnergyRead.text = "+1";
                    enemyHealthRead.text = "-1";
                    Debug.Log("player energy/health: " + playerEnergy + "/ " + playerHealth + " enemy energy/health: " + enemyEnergy + "/ " + enemyHealth);
                }
                else if (ecard.cards == Cards.superAttack)
                {
                    if (enemyEnergy < 3)
                    {
                        Debug.Log("wasted card");
                    }
                    else
                    {
                        enemyEnergy -= 3;
                        enemyHealth--;

                        enemyEnergyRead.text = "-3";
                        enemyHealthRead.text = "-1";

                        playerHealth -= 2;

                        playerHealthRead.text = "-2";
                        Debug.Log("player energy/health: " + playerEnergy + "/ " + playerHealth + " enemy energy/health: " + enemyEnergy + "/ " + enemyHealth);
                    }
                }
            }
        }
        if (pcard.cards == Cards.charge)
        {
            playerEnergy++;
            playerEnergyRead.text = "+1";

            if (ecard.cards == Cards.attack)
            {
                if (enemyEnergy < 1)
                {
                    Debug.Log("wasted card");
                }
                else
                {
                    enemyEnergy--;

                    enemyEnergyRead.text = "-1";

                    playerHealth--;

                    playerHealthRead.text = "-1";
                    Debug.Log("player energy/health: " + playerEnergy + "/ " + playerHealth + " enemy energy/health: " + enemyEnergy + "/ " + enemyHealth);
                }
            }

            else if (ecard.cards == Cards.defense)
            {
                Debug.Log("player energy/health: " + playerEnergy + "/ " + playerHealth + " enemy energy/health: " + enemyEnergy + "/ " + enemyHealth);
            }
            else if (ecard.cards == Cards.charge)
            {
                enemyEnergy++;

                enemyEnergyRead.text = "+1";
                Debug.Log("player energy/health: " + playerEnergy + "/ " + playerHealth + " enemy energy/health: " + enemyEnergy + "/ " + enemyHealth);
            }
            else if (ecard.cards == Cards.superAttack)
            {
                if (enemyEnergy < 3)
                {
                    Debug.Log("wasted card");
                }
                else
                {
                    enemyEnergy -= 3;

                    enemyEnergyRead.text = "-3";

                    playerHealth -= 2;

                    playerHealthRead.text = "-2";
                    Debug.Log("player energy/health: " + playerEnergy + "/ " + playerHealth + " enemy energy/health: " + enemyEnergy + "/ " + enemyHealth);
                }
            }
        }
        if (pcard.cards == Cards.defense)
        {
            if (ecard.cards == Cards.attack)
            {
                if (enemyEnergy < 1)
                {
                    Debug.Log("wasted card");
                }
                else
                {
                    enemyEnergy--;

                    enemyEnergyRead.text = "-1";
                    Debug.Log("player energy/health: " + playerEnergy + "/ " + playerHealth + " enemy energy/health: " + enemyEnergy + "/ " + enemyHealth);
                }
            }
            else if (ecard.cards == Cards.defense)
            {
                Debug.Log("player energy/health: " + playerEnergy + "/ " + playerHealth + " enemy energy/health: " + enemyEnergy + "/ " + enemyHealth);
            }
            else if (ecard.cards == Cards.charge)
            {
                enemyEnergy++;

                enemyEnergyRead.text = "+1";
                Debug.Log("player energy/health: " + playerEnergy + "/ " + playerHealth + " enemy energy/health: " + enemyEnergy + "/ " + enemyHealth);
            }
            else if (ecard.cards == Cards.superAttack)
            {
                if (enemyEnergy < 3)
                {
                    Debug.Log("waste card");
                }
                else
                {
                    enemyEnergy -= 3;

                    enemyEnergyRead.text = "-3";

                    playerHealth--;

                    playerHealthRead.text = "-1";
                    Debug.Log("player energy/health: " + playerEnergy + "/ " + playerHealth + " enemy energy/health: " + enemyEnergy + "/ " + enemyHealth);
                }
            }
        }
        if (pcard.cards == Cards.superAttack)
        {
            if (playerEnergy < 3)
            {
                Debug.Log("wasted card");
            }
            else
            {
                playerEnergy -= 3;

                playerEnergyRead.text = "-3";
                if (ecard.cards == Cards.attack)
                {
                    if (enemyEnergy < 1)
                    {
                        Debug.Log("wasted card");
                    }
                    else
                    {
                        enemyEnergy--;

                        enemyEnergyRead.text = "-1";

                        playerHealth--;
                        enemyHealth -= 2;

                        playerHealthRead.text = "-1";
                        enemyHealthRead.text = "-2";
                        Debug.Log("player energy/health: " + playerEnergy + "/ " + playerHealth + " enemy energy/health: " + enemyEnergy + "/ " + enemyHealth);
                    }
                }
                else if (ecard.cards == Cards.defense)
                {
                    enemyHealth--;

                    enemyHealthRead.text = "-1";
                    Debug.Log("player energy/health: " + playerEnergy + "/ " + playerHealth + " enemy energy/health: " + enemyEnergy + "/ " + enemyHealth);
                }
                else if (ecard.cards == Cards.charge)
                {
                    enemyEnergy++;
                    enemyHealth -= 2;

                    enemyEnergyRead.text = "+1";
                    enemyHealthRead.text = "-2";
                    Debug.Log("player energy/health: " + playerEnergy + "/ " + playerHealth + " enemy energy/health: " + enemyEnergy + "/ " + enemyHealth);
                }
                else if (ecard.cards == Cards.superAttack)
                {
                    if (enemyEnergy < 3)
                    {
                        Debug.Log("wasted card");
                    }
                    else
                    {
                        enemyEnergy -= 3;

                        enemyEnergyRead.text = "-3";
                        Debug.Log("player energy/health: " + playerEnergy + "/ " + playerHealth + " enemy energy/health: " + enemyEnergy + "/ " + enemyHealth);
                    }
                }
            }
        }

        if (playerEnergy < 0) 
        {
            playerEnergy = 0;
        }

        if (enemyEnergy < 0)
        {
            enemyEnergy = 0;
        }

        enemyHealthUI.text = "Health: " + enemyHealth;
        enemyEnergyUI.text = "Energy: " + enemyEnergy;
        playerHealthUI.text = "Health: " + playerHealth;
        playerEnergyUI.text = "Energy: " + playerEnergy;

        playerRead.text = pcard.cards.ToString() + " played!";
        enemyRead.text = ecard.cards.ToString() + " played!";
    }
}
