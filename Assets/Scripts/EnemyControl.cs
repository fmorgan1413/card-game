using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyControl : MonoBehaviour
{
    public DealCards cards;
    public movingCard moveCard;

    public GameObject enemyZone2;
    public GameObject trash;
    public slotReader slotReader;

    public List<movingCard> enemyHand = new List<movingCard>();
    public Dictionary<movingCard, float> Dict = new Dictionary<movingCard, float>();

    public TextMeshProUGUI trashRead;

    public void AI() 
    {
        Dict.Clear();
        foreach (movingCard c in enemyHand)
        {
            Dict.Add(c, c.cardVal());
        }
        Debug.Log("eh: " + enemyHand.Count);
        float best = 0;
        float worst = 10;
        movingCard chosen = null;
        movingCard trashed = null;
        foreach (movingCard c in Dict.Keys)
        {
            if (c == null) continue;
            Debug.Log(c + " / " + Dict[c]);
            if (Dict[c] > best)
            {
                best = Dict[c];
                chosen = c;
            }

            if (Dict[c] < worst) 
            {
                worst = Dict[c];
                trashed = c;
            }
        }

        Debug.Log("chose: " + chosen + " / " + enemyZone2);
        chosen.transform.SetParent(enemyZone2.transform, false);
        chosen.transform.localPosition = Vector3.zero;
        GameManager.GM.enemyCards[2] = chosen.GetComponent<movingCard>();

        Debug.Log("to trash: " + trashed + " / " + trash);
        trashRead.text = trashed.cards.ToString() + " was trashed!";
        trashed.transform.SetParent(trash.transform, false);
        trashed.transform.localPosition = Vector3.zero;
        Destroy(trashed);
        Destroy(trashed.gameObject);

        cards.Refresh();
    }
}
