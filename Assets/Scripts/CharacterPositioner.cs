using UnityEngine;
using System.Collections.Generic;
public class CharacterPositioner : MonoBehaviour
{
    private List<GameObject> playableCharacters;
    private Pathfinding pathfinding;
    private GameObject markedCharacter;
    private GameObject previousHex;
    [SerializeField]
    private LayerMask hexLayer;
    [SerializeField]
    private LayerMask characterLayer;
    [SerializeField]
    private GameObject gameScreen;
    [SerializeField]
    private GameObject characterPositioningScreen;
    private bool characterAtValidPosition = false;
    private void Update()
    {
        if (markedCharacter != null)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, hexLayer))
            {
                //Debug.Log("hit something");
            }
            if (hit.collider != null)
            {
                if (hit.collider.gameObject.tag == "Hex")
                {
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
                        hit.collider.gameObject.GetComponentsInChildren<SpriteRenderer>()[0].color = Color.green;
                        previousHex = hit.collider.gameObject;
                        characterAtValidPosition = true;
                    }
                    else
                    {
                        markedCharacter.transform.position = hit.collider.gameObject.transform.position;
                        markedCharacter.GetComponent<SpriteRenderer>().color = Color.red;
                        hit.collider.gameObject.GetComponentsInChildren<SpriteRenderer>()[0].color = Color.red;
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
    private GameObject[] GetAllPlayableCharactersInScene()
    {
        int playerCount = GameObject.FindGameObjectsWithTag("Player").Length;
        GameObject[] allPlayers = new GameObject[playerCount];
        allPlayers = GameObject.FindGameObjectsWithTag("Player");
        return allPlayers;
    }
    public void EndCharacterPositioningPhase()
    {
        this.enabled = false;
        TurnManager turnManager = GetComponent<TurnManager>();
        turnManager.enabled = true;
        GetComponent<TurnManager>().enabled = true;
        GetComponent<InputManager>().enabled = true;
        GetComponent<Pathfinding>().enabled = true;
        characterPositioningScreen.SetActive(false);
        gameScreen.SetActive(true);
        turnManager.GetCharacterInTurn().GetComponentInChildren<Canvas>().enabled = true;
    }
}