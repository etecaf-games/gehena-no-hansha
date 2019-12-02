using UnityEngine;
public class HexProperties : MonoBehaviour
{
    public bool initialHex = false;
    public bool canMove = false;
    public bool canAttack = false;
    public bool canSkill = false;
    public bool playerStartsHere = false;
    public int row = 0;
    public int column = 0;
    private GameObject characterInHex = null;
    public SpriteRenderer sprite;

    public GameObject CharacterInHex
    {
        get
        {
            return characterInHex;
        }
        set
        {
            characterInHex = value;
            EqualizeSortingOrderAndRow(character: value);
        }
    }
    private void EqualizeSortingOrderAndRow(GameObject character)
    {
        if (character != null)
        {
            character.GetComponent<SpriteRenderer>().sortingOrder = row;
        }
    }
}