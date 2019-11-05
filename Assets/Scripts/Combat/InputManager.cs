using UnityEngine;
using UnityEngine.UI;
public class InputManager : MonoBehaviour
{
    [HideInInspector]
    public GameObject selectedGoal;
    public Canvas canvas;
    public LayerMask hexLayer;
    private GameObject currentHex;
    private GameObject previousHex;
    private Pathfinding pathfinding;
    private TurnManager turnManager;
    public bool moveButtonPressed = false;
    public bool attackButtonPressed = false;
    public Text movementPointsText;
    public Image bigIconArea;
    public Image smallIconArea;
    public GameObject pauseBackground;
    private void Start()
    {
        pathfinding = GetComponent<Pathfinding>();
        turnManager = GetComponent<TurnManager>();
    }
    private void LateUpdate()
    {
        if (moveButtonPressed)
        {
            HighlightHexToMove();
        }
        if (attackButtonPressed)
        {
            HighlightHexToAttack();
        }
    }
    private void MoveToNewPosition()
    {
        GameObject player = turnManager.GetCharacterInTurn();
        GameObject playerHex = pathfinding.CharacterToHexPosition(player);
        turnManager.movementLeft -= pathfinding.ReturnShortestPathByBFS(playerHex, currentHex).Count;
        movementPointsText.text = turnManager.movementLeft.ToString();
        player.transform.position = currentHex.transform.position;
        pathfinding.ClearAllHexes();
        //pathfinding.DisplayAdjacentHexes();
        pathfinding.CharacterToHexPosition(currentHex).GetComponentInChildren<SpriteRenderer>().color = Color.white; //deixa o hex em que o personagem está ,branco
        moveButtonPressed = false;
    }
    public RaycastHit MousePositionToRaycastHit(LayerMask hexLayer)
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, hexLayer))
        {

        }
        return hit;
    }
    public RaycastHit MousePositionToRaycastHit()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, hexLayer))
        {

        }
        return hit;
    }
    private void HighlightHexToMove()
    {
        RaycastHit hit = MousePositionToRaycastHit(hexLayer);
        if (hit.collider != null)
        {
            if (hit.collider.gameObject.tag == "Hex")
            {
                if (hit.collider.gameObject != currentHex)
                {
                    previousHex = currentHex;
                    currentHex = hit.collider.gameObject;
                }
                if (currentHex.GetComponent<HexProperties>().canMove)
                {
                    currentHex.GetComponentInChildren<SpriteRenderer>().color = Color.red;
                    if (Input.GetMouseButtonDown(1))
                    {
                        MoveToNewPosition();
                    }
                }
                else
                {
                    currentHex.GetComponentInChildren<SpriteRenderer>().color = Color.white;
                }
                if (previousHex != null)
                {
                    if (previousHex.GetComponent<HexProperties>().canMove)
                    {
                        previousHex.GetComponentInChildren<SpriteRenderer>().color = Color.yellow;
                    }
                    else
                    {
                        previousHex.GetComponentInChildren<SpriteRenderer>().color = Color.white;
                    }
                }
            }
            else
            {
                Debug.Log("No Hex here");
            }
        }
    }
    private void HighlightHexToAttack()
    {
        RaycastHit hit = MousePositionToRaycastHit(hexLayer);
        if (hit.collider != null)
        {
            if (hit.collider.gameObject.tag == "Hex")
            {
                if (hit.collider.gameObject != currentHex)
                {
                    previousHex = currentHex;
                    currentHex = hit.collider.gameObject;
                }
                if (currentHex.GetComponent<HexProperties>().canAttack)
                {
                    currentHex.GetComponentInChildren<SpriteRenderer>().color = Color.green;
                    if (Input.GetMouseButtonDown(1))
                    {
                        Debug.Log("Attacking " + currentHex.name);
                    }
                }
                else
                {
                    currentHex.GetComponentInChildren<SpriteRenderer>().color = Color.white;
                }
                if (previousHex != null)
                {
                    if (previousHex.GetComponent<HexProperties>().canAttack)
                    {
                        previousHex.GetComponentInChildren<SpriteRenderer>().color = Color.red;
                    }
                    else
                    {
                        previousHex.GetComponentInChildren<SpriteRenderer>().color = Color.white;
                    }
                }
            }
            else
            {
                Debug.Log("No Hex here");
            }
        }
    }
    public void FinishButton()
    {
        pathfinding.ClearAllHexes();
        GameObject currentCharacter = turnManager.GetCharacterInTurn();
        currentCharacter.GetComponentInChildren<Canvas>().enabled = false;
        turnManager.NextTurn();
        currentCharacter = turnManager.GetCharacterInTurn();
        GameObject nextCharacter = turnManager.GetCharacterInNextTurn();
        currentCharacter.GetComponentInChildren<Canvas>().enabled = true;
        turnManager.movementLeft = currentCharacter.GetComponent<Stats>().move;
        movementPointsText.text = turnManager.movementLeft.ToString();
        bigIconArea.sprite = currentCharacter.GetComponent<Icon>().bigIcon;
        smallIconArea.sprite = nextCharacter.GetComponent<Icon>().smallIcon;
    }
    public void PauseButton()
    {
        pauseBackground.SetActive(true);
        Time.timeScale = 0;
    }
    public void ResumeButton()
    {
        pauseBackground.SetActive(false);
        Time.timeScale = 1;
    }
}