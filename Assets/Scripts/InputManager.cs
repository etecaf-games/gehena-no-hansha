using UnityEngine;
public class InputManager : MonoBehaviour
{
    [HideInInspector]
    public GameObject selectedGoal;
    public Canvas canvas;
    [SerializeField]
    private LayerMask hexLayer;
    private GameObject currentHex;
    private GameObject previousHex;
    private Pathfinding pathfinding;
    private TurnManager turnManager;
    private MapGenerator mapGenerator;
    public bool moveButtonPressed = false;
    private void Start()
    {
        pathfinding = GetComponent<Pathfinding>();
        turnManager = GetComponent<TurnManager>();
        mapGenerator = GetComponent<MapGenerator>();
    }
    private void LateUpdate()
    {
        if (moveButtonPressed)
        {
            HighlightHexToMove();
        }
        //    if (Input.GetMouseButtonDown(0))
        //    {
        //        RaycastHit hitMouse = MousePositionToRaycasHit();
        //        if (hitMouse.collider != null)
        //        {
        //            if (hitMouse.collider.gameObject.tag == "Player")
        //            {
        //                Canvas actionWheelCanvas = hitMouse.collider.gameObject.GetComponentInChildren<Canvas>();
        //                actionWheelCanvas.enabled = true;
        //                hitMouse.collider.gameObject.GetComponent<SpriteRenderer>().color = Color.cyan;
        //            }
        //        }
        //    }
        //    DisplayHexAsGoal(hit);
        //    if (Input.GetMouseButtonDown(1))
        //    {
        //        RaycastHit hitMouse = MousePositionToRaycasHit();
        //        MarkHexAsGoal(hitMouse);
        //    }
        //}
        //private void DisplayHexAsGoal(RaycastHit hit)
        //{
        //    if (hit.collider != null)
        //    {
        //        GameObject hex = hit.collider.gameObject;
        //        hex.GetComponentsInChildren<SpriteRenderer>()[0].color = Color.cyan;
        //    }
        //}
        //public void MarkHexAsGoal(RaycastHit hit)
        //{
        //    if (!thereIsASelectedGoal)
        //    {
        //        if (hit.collider != null)
        //        {
        //            selectedGoal = hit.collider.gameObject;
        //            selectedGoal.GetComponent<HexProperties>().goal = true;
        //            selectedGoal.GetComponent<HexProperties>().ChangeSpriteColor();
        //            thereIsASelectedGoal = true;
        //        }
        //        else
        //        {
        //            Debug.Log("To select a goal, you need to right click something");
        //        }
        //    }
        //    else
        //    {
        //        if (hit.collider != null)
        //        {
        //            if (hit.collider.gameObject.GetComponent<HexProperties>().goal)
        //            {
        //                Debug.Log("This is already the goal!");
        //            }
        //            else
        //            {
        //                selectedGoal.GetComponent<HexProperties>().goal = false;
        //                selectedGoal.GetComponent<HexProperties>().ChangeSpriteColor();
        //                selectedGoal = hit.collider.gameObject;
        //                selectedGoal.GetComponent<HexProperties>().goal = true;
        //                selectedGoal.GetComponent<HexProperties>().ChangeSpriteColor();
        //            }
        //        }
        //        else
        //        {
        //            selectedGoal.GetComponent<HexProperties>().goal = false;
        //            selectedGoal.GetComponent<HexProperties>().ChangeSpriteColor();
        //            thereIsASelectedGoal = false;
        //        }
        //    }
    }
    private void MoveToNewPosition()
    {
        GameObject player = GameObject.FindWithTag("Player");
        GameObject playerHex = pathfinding.CharacterToHexPosition(player);
        //Vector3 oldPosition = playerHex.transform.position;
        //Vector3 newPosition = currentHex.transform.position;        //isso não ironicamente está certo
        //pathfinding.movementLeft -= CalculateDistance(oldPosition, newPosition);
        pathfinding.movementLeft -= pathfinding.ReturnShortestPathByBFS(playerHex, currentHex).Count;
        player.transform.position = currentHex.transform.position;
        pathfinding.ClearAllHexes();
        pathfinding.DisplayAdjacentHexes();
        pathfinding.CharacterToHexPosition(currentHex).GetComponentInChildren<SpriteRenderer>().color = Color.white; //deixa o hex em que o personagem está ,branco
    }
    private int CalculateDistance(Vector3 oldPosition, Vector3 newPosition)
    {
        Debug.Log("aaaa");
        float xDistance = mapGenerator.xDistance;
        float yDistance = mapGenerator.yDistance;
        float zDistance = mapGenerator.zDistance;
        float totalMovement;
        if (oldPosition.y == newPosition.y && oldPosition.z == newPosition.z)
        {
            Debug.Log("moveu sim");
            Vector3 totalDistance = new Vector3(Mathf.Abs(oldPosition.x - newPosition.x), Mathf.Abs(oldPosition.y - newPosition.y), Mathf.Abs(oldPosition.z - newPosition.z));
            totalMovement = totalDistance.x / 1.2f;
        }
        else
        {
            Debug.Log("nao moveu nada");
            totalMovement = 0f;
        }
        int totalIntMovement = int.Parse(totalMovement.ToString());
        return totalIntMovement;
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
                ////if (previousHex != null)
                ////{
                ////    if (currentHex.transform.position == turnManager.GetCharacterInTurn().transform.position)
                ////    {
                ////        previousHex.GetComponentInChildren<SpriteRenderer>().color = Color.white;
                ////    }
                ////    else
                ////    {
                ////        previousHex.GetComponentInChildren<SpriteRenderer>().color = Color.yellow;
                ////    }
                ////}
                ////else
                ////{
                ////    Debug.Log("just once ok?");
                ////}

                ////if (currentHex != null)
                ////{
                ////    currentHex.GetComponentInChildren<SpriteRenderer>().color = Color.red;
                ////    if (Input.GetMouseButtonDown(1))
                ////    {
                ////        MoveToNewPosition();
                ////    }
                ////}
                //{
                //    if (currentHex.transform.position == turnManager.GetCharacterInTurn().transform.position)
                //    {
                //        currentHex.GetComponentInChildren<SpriteRenderer>().color = Color.white;
                //    }
                //    else
                //    {
                //        currentHex.GetComponentInChildren<SpriteRenderer>().color = Color.yellow;
                //    }
                //}
                //else
                //{
                //    currentHex = pathfinding.CharacterToHexPosition(turnManager.GetCharacterInTurn());
                //}

            }
            else
            {
                Debug.Log("No Hex here");
            }
        }
    }
}