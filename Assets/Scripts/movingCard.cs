using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingCard : MonoBehaviour
{
    private bool beingDragged = false;
    private Vector2 startPosition;
    private bool isOverPlayerCardZone1 = false;
    public GameObject playerzone1;
    private bool isOverPlayerCardZone2 = false;
    public GameObject playerzone2;
    private bool isOverPlayerCardZone3 = false;
    public GameObject playerzone3;
    private bool isOverEnemyCardZone1 = false;
    public GameObject enemyzone1;
    private bool isOverEnemyCardZone2 = false;
    public GameObject enemyzone2;
    private bool isOverEnemyCardZone3 = false;
    public GameObject enemyzone3;
    private bool isOverTrashZone = false;
    private GameObject trashzone;

    public DealCards dealcards;
    //public GameManager GM;

    public slotReader HoverOver;
    public Cards cards;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (beingDragged) 
        {
            transform.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        slotReader sl = collision.gameObject.GetComponent<slotReader>();
        if (sl != null)
        {
            HoverOver = sl;
        }

        //if (collision.gameObject.name == "playerCardZone1")
        //{
        //    isOverPlayerCardZone1 = true;
        //    playerzone1 = collision.gameObject;
            
        //}
        //else if (collision.gameObject.name == "playerCardZone2")
        //{
        //    isOverPlayerCardZone2 = true;
        //    playerzone2 = collision.gameObject;
            
        //}
        //else if (collision.gameObject.name == "playerCardZone3")
        //{
        //    isOverPlayerCardZone3 = true;
        //    playerzone3 = collision.gameObject;
            
        //}
        //else if (collision.gameObject.name == "enemyCardZone1")
        //{
        //    isOverEnemyCardZone1 = true;
        //    enemyzone1 = collision.gameObject;
           
        //}
        //else if (collision.gameObject.name == "enemyCardZone2")
        //{
        //    isOverEnemyCardZone2 = true;
        //    enemyzone2 = collision.gameObject;
            
        //}
        //else if (collision.gameObject.name == "enemyCardZone3")
        //{
        //    isOverEnemyCardZone3 = true;
        //    enemyzone3 = collision.gameObject;
            
        //}
        //else if (collision.gameObject.name == "trashZone")
        //{
        //    isOverTrashZone = true;
        //    trashzone = collision.gameObject;
        //}

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject == HoverOver.gameObject)
            HoverOver = null;

        //if (collision.gameObject.name == "playerCardZone1")
        //{
        //    isOverPlayerCardZone1 = false;
        //    playerzone1 = null;
            
        //}
        //else if (collision.gameObject.name == "playerCardZone2")
        //{
        //    isOverPlayerCardZone2 = false;
        //    playerzone2 = null;
            
        //}
        //else if (collision.gameObject.name == "playerCardZone3")
        //{
        //    isOverPlayerCardZone3 = false;
        //    playerzone3 = null;
            
        //}
        //else if (collision.gameObject.name == "enemyCardZone1")
        //{
        //    isOverEnemyCardZone1 = false;
        //    enemyzone1 = null;
            
        //}
        //else if (collision.gameObject.name == "enemyCardZone2")
        //{
        //    isOverEnemyCardZone2 = false;
        //    enemyzone2 = null;
            
        //}
        //else if (collision.gameObject.name == "enemyCardZone3")
        //{
        //    isOverEnemyCardZone3 = false;
        //    enemyzone3 = null;
            
        //}
        //else if (collision.gameObject.name == "trashZone")
        //{
        //    isOverTrashZone = false;
        //    trashzone = null;

        //}
    }

    public void StartDragging() 
    {
        startPosition = transform.position;
        beingDragged = true;
    }

    public void StopDragging() 
    {
        beingDragged = false;

        if (HoverOver != null)
        {
            transform.SetParent(HoverOver.transform, false);
            transform.localPosition = Vector3.zero;
            if(HoverOver.playerSlot)
               GameManager.GM.playerCards[HoverOver.CardSlot] = this;

            else
                GameManager.GM.enemyCards[HoverOver.CardSlot] = this;
        }
        else
        {
            transform.position = startPosition;
        }

        //if (isOverPlayerCardZone1)
        //{
        //    transform.SetParent(playerzone1.transform, false);
        //    transform.position = playerzone1.transform.position;
        //    GM.playerCards[0] = playerzone1.transform.GetChild(0).GetComponent<movingCard>();
        //}
        //else if (isOverPlayerCardZone2)
        //{
        //    transform.SetParent(playerzone2.transform, false);
        //    transform.position = playerzone2.transform.position;
        //    GM.playerCards[1] = this;
        //}
        //else if (isOverPlayerCardZone3)
        //{
        //    transform.SetParent(playerzone3.transform, false);
        //    transform.position = playerzone3.transform.position;
        //    GM.playerCards[2] = playerzone3.transform.GetChild(0).GetComponent<movingCard>();
        //}
        //else if (isOverEnemyCardZone1)
        //{
        //    transform.SetParent(enemyzone1.transform, false);
        //    transform.position = enemyzone1.transform.position;
        //    GM.enemyCards[0] = enemyzone1.transform.GetChild(0).GetComponent<movingCard>();
        //}
        //else if (isOverEnemyCardZone2)
        //{
        //    transform.SetParent(enemyzone2.transform, false);
        //    transform.position = enemyzone2.transform.position;
        //    GM.enemyCards[1] = enemyzone2.transform.GetChild(0).GetComponent<movingCard>();
        //}
        //else if (isOverEnemyCardZone3)
        //{
        //    transform.SetParent(enemyzone3.transform, false);
        //    transform.position = enemyzone3.transform.position;
        //    GM.enemyCards[2] = enemyzone3.transform.GetChild(0).GetComponent<movingCard>();
        //}

        //else if (isOverTrashZone)
        //{
        //    transform.SetParent(trashzone.transform, false);
        //    transform.position = trashzone.transform.position;

        //    //trash card lol
        //    Destroy(trashzone.transform.GetChild(0).gameObject);
        //}
        //else
        //{
        //    transform.position = startPosition;
        //}
    }
}

public enum Cards
{
    attack,
    charge,
    defense,
    superAttack
}
