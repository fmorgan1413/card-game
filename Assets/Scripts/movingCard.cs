using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingCard : MonoBehaviour
{
    private bool beingDragged = false;
    private Vector2 startPosition;
    public GameObject playerzone1;
    public GameObject playerzone2;
    public GameObject playerzone3;
    public GameObject enemyzone1;
    public GameObject enemyzone2;
    public GameObject enemyzone3;

    public DealCards dealcards;

    public slotReader HoverOver;
    public Cards cards;

    public EnemyControl enemy;

    public AudioSource sound;

    public void Start()
    {
        sound = this.GetComponent<AudioSource>();
    }

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
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject == HoverOver.gameObject)
            HoverOver = null;
    }

    public void StartDragging() 
    {
        startPosition = transform.position;
        beingDragged = true;

        sound.Play();
    }

    public void StopDragging() 
    {
        beingDragged = false;

        if (HoverOver != null)
        {
            transform.SetParent(HoverOver.transform, false);
            transform.localPosition = Vector3.zero;
            if (HoverOver.playerSlot)
            {
                if (HoverOver.CardSlot == 4)
                {
                    Destroy(this.gameObject);
                }
                else
                {
                    GameManager.GM.playerCards[HoverOver.CardSlot] = this;
                }
            }
            else
            {
                GameManager.GM.enemyCards[HoverOver.CardSlot] = this;
            }

            
        }
        else
        {
            transform.position = startPosition;
        }
    }

    public float cardVal() 
    {
        float v = 1;
        switch (cards)
        {
            case Cards.attack:
            {
                    if (GameManager.GM.enemyEnergy >= 3 && GameManager.GM.playerHealth >= 5)
                    {
                        v += 3;
                    }
                    else if (GameManager.GM.enemyEnergy < 3 && GameManager.GM.enemyEnergy >= 1) 
                    {
                        v += 1;
                    }

                break;
            }
            case Cards.charge:
            {
                    if (GameManager.GM.enemyEnergy < 5)
                    {
                        v += 2;
                    }
                    else if (GameManager.GM.enemyEnergy >= 5) 
                    {
                        v++;
                    }

                    break;
            }
            case Cards.defense:
            {
                    if (GameManager.GM.enemyHealth < 5)
                    {
                        v += 5;
                    }
                    else if (GameManager.GM.enemyEnergy == 0 || GameManager.GM.enemyHealth >= 5) 
                    {
                        v += 1;
                    }
                    break;
            }
            case Cards.superAttack:
            {
                    if (GameManager.GM.enemyEnergy > 9 && GameManager.GM.playerHealth > 5)
                    {
                        v ++;
                    }

                    break;
            }
        }
        Debug.Log("Val: " + cards + " / " + v);
        return v;
    }
}

public enum Cards
{
    attack,
    charge,
    defense,
    superAttack
}
