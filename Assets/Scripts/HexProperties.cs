using UnityEngine;
public class HexProperties : MonoBehaviour
{
    public bool goal = false;
    private SpriteRenderer sprite;
    private Animator animSprite;
    void Start()
    {
        sprite = GetComponentsInChildren<SpriteRenderer>()[0];
        animSprite = GetComponentsInChildren<Animator>()[0];
    }
    public void ChangeSpriteColor()
    {
        if(this.goal)
        {
            sprite.color = Color.green;
        }
        else
        {
            sprite.color = Color.white;
        }
    }
}