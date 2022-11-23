using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundLoop : MonoBehaviour
{
    private float width;

    private void Awake()
    {
        BoxCollider2D backGroundCollider = GetComponent<BoxCollider2D>();
        width = backGroundCollider.size.x;
    }

    private void Update()
    {
        if(transform.position.x <= -width * transform.localScale.x)
        {
            Reposition();
        }
    }

    private void Reposition()
    {
        Vector2 offset=new Vector2(width * transform.localScale.x * 2, 0);
        transform.position = (Vector2) transform.position + offset;
    }
   
}
