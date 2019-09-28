using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClick : MonoBehaviour
{
    public bool selected = false;
    public bool goal = false;
   // public bool discovered = false;
    private SpriteRenderer sprite;
    private PlayerTest player;
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        player = GameObject.FindWithTag("Player").GetComponent<PlayerTest>();
    }
    public void ChangeSpriteColor()
    {
        if (this.selected)
        {
            sprite.color = Color.red;
        }
        else if(this.goal)
        {
            sprite.color = Color.green;
        }
        else
        {
            sprite.color = Color.white;
        }

        if (player.transform.position == this.transform.position)
        {
            SpriteRenderer playerSprite = player.GetComponent<SpriteRenderer>();
            if (this.selected)
            {
                player.Selected = true;
            }
            else if (this.goal)
            {
                playerSprite.color = Color.green;
            }
            else
            {
                playerSprite.color = Color.white;
            }

        }
    }
}