using UnityEngine;
using System.Collections;
public class CharacterPositioner : MonoBehaviour
{
    private GameObject markedCharacter;
    private GameObject previousHex;
    public LayerMask hexLayer;
    public LayerMask characterLayer;
    public GameObject gameScreen;
    public GameObject characterPositioningScreen;
    private bool characterAtValidPosition = false;
    private TurnManager turnManager;
    private void Awake()
    {
        turnManager = GetComponent<TurnManager>();
    }
    private void Update()
    {
        if (markedCharacter != null)
        {
            RaycastHit hit = HitHexes();
            if (hit.collider != null)
            {
                if (hit.collider.gameObject.tag == "Hex")
                {
                    GameObject hex = hit.collider.gameObject;
                    if (previousHex != null)
                    {
                        previousHex.GetComponentsInChildren<SpriteRenderer>()[0].color = Color.white;
                        previousHex.GetComponent<HexProperties>().characterInHex = null;
                    }
                    if (hit.collider.gameObject.GetComponent<HexProperties>().initialHex)
                    {
                        //Debug.Log("Segue o mouse");
                        markedCharacter.transform.position = hit.collider.gameObject.transform.position;
                        markedCharacter.GetComponent<SpriteRenderer>().color = Color.green;
                        hex.GetComponentsInChildren<SpriteRenderer>()[0].color = Color.green;
                        previousHex = hit.collider.gameObject;
                        characterAtValidPosition = true;
                    }
                    else
                    {
                        markedCharacter.transform.position = hit.collider.gameObject.transform.position;
                        markedCharacter.GetComponent<SpriteRenderer>().color = Color.red;
                        hex.GetComponentsInChildren<SpriteRenderer>()[0].color = Color.red;
                        previousHex = hit.collider.gameObject;
                        characterAtValidPosition = false;
                    }
                }
                else
                {
                    Debug.Log("No Hex here");
                }
            }
            if (Input.GetMouseButtonDown(0))
            {
                HexProperties hexProperties = previousHex.GetComponent<HexProperties>();
                if (characterAtValidPosition && hexProperties.characterInHex == false)
                {
                    Debug.Log("cancela");
                    markedCharacter.GetComponent<SpriteRenderer>().color = Color.white;
                    previousHex.GetComponentsInChildren<SpriteRenderer>()[0].color = Color.white;
                    previousHex.GetComponent<HexProperties>().characterInHex = markedCharacter;
                    markedCharacter = null;
                }
                else
                {
                    Debug.Log("nao da pra soltar aqui!");
                }
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit, Mathf.Infinity, characterLayer))
                {
                    if (hit.collider.gameObject.tag == "Player")
                    {
                        markedCharacter = hit.collider.gameObject;
                        markedCharacter.GetComponent<SpriteRenderer>().color = Color.green;
                    }
                }
            }
        }
    }
    private RaycastHit HitHexes()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, hexLayer))
        {
            //Debug.Log("hit something");
        }
        return hit;
    }
    public void EndCharacterPositioningPhase()
    {
        this.enabled = false;
        characterPositioningScreen.SetActive(false);
        gameScreen.SetActive(true);
        turnManager.UpdateCombatUIValues(true);
    }
}