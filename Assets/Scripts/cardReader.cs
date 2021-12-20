using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cardReader : MonoBehaviour
{
    public GameObject board;
    private GameObject zoom;


    // Start is called before the first frame update
    void Awake()
    {
        board = GameObject.Find("Canvas");

    }

    // Update is called once per frame
    void Update()
    {
        
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
