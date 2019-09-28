using UnityEngine;

public class Player : MonoBehaviour
{
    private bool selected;

    public bool Selected
    {
        get
        {
            return selected;
        }
        set
        {
            selected = value;
            if (selected)
            {
                GetComponent<SpriteRenderer>().color = Color.red;
            }
            else
            {
                GetComponent<SpriteRenderer>().color = Color.white;
            }
        }
    }
}
