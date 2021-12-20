using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealCards : MonoBehaviour
{
    public GameObject attackCard;
    public GameObject defenseCard;
    public GameObject chargeCard;
    public GameObject superAttack;
    public GameObject playerArea;
    public GameObject enemyArea;

    public GameObject playerCards;
    public GameObject enemyCards;

    public Cards Cards;
    public movingCard movingCard;
    public EnemyControl enemyControl;

    List<GameObject> cards = new List<GameObject>();


    // Start is called before the first frame update
    void Start()
    {
        cards.Add(attackCard);
        cards.Add(defenseCard);
        cards.Add(chargeCard);
        cards.Add(superAttack);

        for (var i = 0; i < 5; i++) 
        {
            playerCards = Instantiate(cards[Random.Range(0, cards.Count)], new Vector3(0, 0, 0), Quaternion.identity);
            playerCards.transform.SetParent(playerArea.transform, false);

            enemyCards = Instantiate(cards[Random.Range(0, cards.Count)], new Vector3(0, 0, 0), Quaternion.identity);
            enemyCards.transform.SetParent(enemyArea.transform, false);
            enemyControl.enemyHand.Add(enemyCards.GetComponent<movingCard>());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick() 
    {
        Refresh();
        GameManager.GM.EndTurn();
    }

    public void Refresh()
    {

        for (var i = 0; i < 5; i++)
        {
            if (playerArea.transform.childCount < 5)
            {
                playerCards = Instantiate(cards[Random.Range(0, cards.Count)], new Vector3(0, 0, 0), Quaternion.identity);
                playerCards.transform.SetParent(playerArea.transform, false);
            }
            if (enemyArea.transform.childCount < 5)
            {
                enemyCards = Instantiate(cards[Random.Range(0, cards.Count)], new Vector3(0, 0, 0), Quaternion.identity);
                enemyCards.transform.SetParent(enemyArea.transform, false);

                enemyControl.enemyHand.Add(enemyCards.GetComponent<movingCard>());
            }
        }
    }


}
