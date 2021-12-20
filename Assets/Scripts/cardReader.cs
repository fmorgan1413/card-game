using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cardReader : MonoBehaviour
{
    public GameObject board;
    private GameObject zoom;

    public void Awake()
    {
        board = GameObject.Find("Canvas");
    }

    public void Hovering() 
    {
        zoom = Instantiate(gameObject, new Vector2(Input.mousePosition.x, Input.mousePosition.y + 250), Quaternion.identity);
        zoom.transform.SetParent(board.transform, false);
        zoom.layer = LayerMask.NameToLayer("zoom");

        RectTransform rect = zoom.GetComponent<RectTransform>();
        rect.sizeDelta = new Vector2(272, 456);
    }

    public void notHovering()
    {
        Destroy(zoom);
    }


}
