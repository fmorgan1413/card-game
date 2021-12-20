using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    public DealCards cards;
    public movingCard moveCard;

    public GameObject enemyZone2;
    public slotReader slotReader;

    public List<movingCard> enemyHand = new List<movingCard>();
    public Dictionary<movingCard, float> Dict = new Dictionary<movingCard, float>();
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
        Dict.Clear();
        foreach (movingCard c in enemyHand)
        {
            Dict.Add(c, c.cardVal());
        }
        Debug.Log("eh: " + enemyHand.Count);
        float best = 0;
        movingCard chosen = null;
        foreach (movingCard c in Dict.Keys)
        {
            if (c == null) continue;
            Debug.Log(c + " / " + Dict[c]);
            if (Dict[c] > best)
            {
                best = Dict[c];
                chosen = c;
            }
        }
        Debug.Log("chose: " + chosen + " / " + enemyZone2);
        chosen.transform.SetParent(enemyZone2.transform, false);
        chosen.transform.localPosition = Vector3.zero;
        GameManager.GM.enemyCards[2] = chosen.GetComponent<movingCard>();

        cards.Refresh();
    }
}
