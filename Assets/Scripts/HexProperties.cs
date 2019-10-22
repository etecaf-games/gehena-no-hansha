using UnityEngine;
public class HexProperties : MonoBehaviour
{
    public bool goal = false;
    public bool initialHex = false;
    public GameObject characterInHex = null;
    public SpriteRenderer sprite;
    void Start()
    {
        sprite = GetComponentsInChildren<SpriteRenderer>()[0];
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