using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private bool thereIsASelectedGameObject = false, thereIsASelectedGoal = false;
    private GameObject selectedGameObject, selectedGoal;
    private MapGenerator map;
    private Player player;
    private bool move;
    private float t = 0;
    private int pathIndex = 1;
    private void Start()
    {
        map = GameObject.Find("Grid").GetComponent<MapGenerator>();
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))//find adjacent hexes
        {
            FindAdjacentHexes(selectedGameObject);
        }
        if (Input.GetKeyDown(KeyCode.L))//clear hexes color
        {
            ClearAllHexes();
        }
        if (Input.GetKeyDown(KeyCode.H))//show path
        {
            DisplayPath();
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            MoveToGoal(BFS(selectedGameObject, selectedGoal));
        }
        if (!thereIsASelectedGameObject && !thereIsASelectedGoal)//nao tem nada selecionado
        {
            if (Input.GetMouseButtonDown(0))//clique do botao esquerdo
            {
                RaycastHit2D hit = MousePositionToRaycasHit2D();
                if (hit.collider != null) //acertou algo
                {
                    selectedGameObject = hit.collider.gameObject;
                    selectedGameObject.GetComponent<OnClick>().selected = true;
                    selectedGameObject.GetComponent<OnClick>().ChangeSpriteColor();
                    thereIsASelectedGameObject = true;
                }
                else
                {
                    Debug.Log("You need to click on something to select it.");
                }
            }
            if (Input.GetMouseButtonDown(1))
            {
                Debug.Log("You must select a GameObject before choosing a goal.");
            }
        }
        else if (thereIsASelectedGameObject && !thereIsASelectedGoal)
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit2D hit = MousePositionToRaycasHit2D();
                if (hit.collider != null)
                {
                    if (hit.collider.gameObject.GetComponent<OnClick>().selected)
                    {
                        Debug.Log("This is already selected");
                    }
                    else
                    {
                        selectedGameObject.GetComponent<OnClick>().selected = false;
                        selectedGameObject.GetComponent<OnClick>().ChangeSpriteColor();
                        selectedGameObject = hit.collider.gameObject;
                        selectedGameObject.GetComponent<OnClick>().selected = true;
                        selectedGameObject.GetComponent<OnClick>().ChangeSpriteColor();
                    }
                }
                else
                {
                    selectedGameObject.GetComponent<OnClick>().selected = false;
                    selectedGameObject.GetComponent<OnClick>().ChangeSpriteColor();
                    selectedGameObject = null;
                    thereIsASelectedGameObject = false;
                }
            }
            if (Input.GetMouseButtonDown(1))
            {
                RaycastHit2D hit = MousePositionToRaycasHit2D();
                if (hit.collider != null)
                {
                    if (hit.collider.gameObject.GetComponent<OnClick>().selected)
                    {
                        Debug.Log("This can't be a goal because it is already selected");
                    }
                    else
                    {
                        selectedGoal = hit.collider.gameObject;
                        selectedGoal.GetComponent<OnClick>().goal = true;
                        selectedGoal.GetComponent<OnClick>().ChangeSpriteColor();
                        thereIsASelectedGoal = true;
                    }
                }
                else
                {
                    Debug.Log("To select a goal, you need to right click something");
                }
            }
        }
        else if (thereIsASelectedGameObject && thereIsASelectedGoal)
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit2D hit = MousePositionToRaycasHit2D();
                if (hit.collider != null)
                {
                    if (hit.collider.gameObject.GetComponent<OnClick>().selected)
                    {
                        Debug.Log("This is already selected");
                    }
                    else if (hit.collider.gameObject.GetComponent<OnClick>().goal)
                    {
                        selectedGoal.GetComponent<OnClick>().goal = false;
                        selectedGoal.GetComponent<OnClick>().ChangeSpriteColor();
                        thereIsASelectedGoal = false;
                        selectedGameObject.GetComponent<OnClick>().selected = false;
                        selectedGameObject.GetComponent<OnClick>().ChangeSpriteColor();
                        selectedGameObject = hit.collider.gameObject;
                        selectedGameObject.GetComponent<OnClick>().selected = true;
                        selectedGameObject.GetComponent<OnClick>().ChangeSpriteColor();
                    }
                    else
                    {
                        selectedGoal.GetComponent<OnClick>().goal = false;
                        selectedGoal.GetComponent<OnClick>().ChangeSpriteColor();
                        thereIsASelectedGoal = false;
                        selectedGameObject.GetComponent<OnClick>().selected = false;
                        selectedGameObject.GetComponent<OnClick>().ChangeSpriteColor();
                        selectedGameObject = hit.collider.gameObject;
                        selectedGameObject.GetComponent<OnClick>().selected = true;
                        selectedGameObject.GetComponent<OnClick>().ChangeSpriteColor();
                    }
                }
                else
                {
                    selectedGoal.GetComponent<OnClick>().goal = false;
                    selectedGoal.GetComponent<OnClick>().ChangeSpriteColor();
                    thereIsASelectedGoal = false;
                    selectedGameObject.GetComponent<OnClick>().selected = false;
                    selectedGameObject.GetComponent<OnClick>().ChangeSpriteColor();
                    thereIsASelectedGameObject = false;
                }
            }
            if (Input.GetMouseButtonDown(1))
            {
                RaycastHit2D hit = MousePositionToRaycasHit2D();
                if (hit.collider != null)
                {
                    if (hit.collider.gameObject.GetComponent<OnClick>().selected)
                    {
                        Debug.Log("This is already selected, it can't be the goal!");
                    }
                    else if (hit.collider.gameObject.GetComponent<OnClick>().goal)
                    {
                        Debug.Log("This is already the goal!");
                    }
                    else
                    {
                        selectedGoal.GetComponent<OnClick>().goal = false;
                        selectedGoal.GetComponent<OnClick>().ChangeSpriteColor();
                        selectedGoal = hit.collider.gameObject;
                        selectedGoal.GetComponent<OnClick>().goal = true;
                        selectedGoal.GetComponent<OnClick>().ChangeSpriteColor();
                    }
                }
                else
                {
                    selectedGoal.GetComponent<OnClick>().goal = false;
                    selectedGoal.GetComponent<OnClick>().ChangeSpriteColor();
                    thereIsASelectedGoal = false;
                }
            }
        }
    }
    private List<GameObject> BFS(GameObject startHex, GameObject goalHex)
    {
        Queue<GameObject> Q = new Queue<GameObject>();
        List<GameObject> discoveredNodes = new List<GameObject>();
        Dictionary<GameObject, GameObject> nodeParents = new Dictionary<GameObject, GameObject>();//a key é o filho, o value é o pai
        List<GameObject> path = new List<GameObject>();
        discoveredNodes.Add(startHex);
        Q.Enqueue(startHex);
        while (Q != null)
        {
            GameObject currentHex = Q.Dequeue();//tira o primeiro da fila
            if (currentHex.transform.position == goalHex.transform.position)//aqui encontrou o caminho final
            {
                path.Add(currentHex);//goal hex
                while (nodeParents.ContainsKey(currentHex))//se o filho tem um pai
                {
                    path.Add(nodeParents[currentHex]);
                    currentHex = nodeParents[currentHex];//the new currentHex is the parent of the current currentHex
                }
                path.Reverse();
                return path;
            }
            foreach (GameObject adjacentHex in FindAdjacentHexes(currentHex))
            {
                if (!discoveredNodes.Contains(adjacentHex))
                {
                    discoveredNodes.Add(adjacentHex);
                    nodeParents.Add(adjacentHex, currentHex);
                    Q.Enqueue(adjacentHex);
                }
            }
        }
        path.Add(startHex);
        return path;
    }
    private List<GameObject> FindAdjacentHexes(GameObject originHex)
    {
        List<GameObject> adjacentHexesList = new List<GameObject>();
        GameObject[,] gridHexesObjects = map.gridHexesObjects;

        Vector3 northWestHex = new Vector3(originHex.transform.position.x - 0.6f, originHex.transform.position.y + 1.05f);
        Vector3 northEastHex = new Vector3(originHex.transform.position.x + 0.6f, originHex.transform.position.y + 1.05f);
        Vector3 westHex = new Vector3(originHex.transform.position.x - 1.2f, originHex.transform.position.y);
        Vector3 eastHex = new Vector3(originHex.transform.position.x + 1.2f, originHex.transform.position.y);
        Vector3 southWestHex = new Vector3(originHex.transform.position.x - 0.6f, originHex.transform.position.y - 1.05f);
        Vector3 southEastHex = new Vector3(originHex.transform.position.x + 0.6f, originHex.transform.position.y - 1.05f);

        for (int row = 0; row < 8; row++)
        {
            if (row % 2 == 0)
            {
                for (int column = 0; column < 8; column++)
                {
                    if (gridHexesObjects[row, column].transform.position == northWestHex)
                    {
                        adjacentHexesList.Add(gridHexesObjects[row, column]);
                    }
                    else if (gridHexesObjects[row, column].transform.position == northEastHex)
                    {
                        adjacentHexesList.Add(gridHexesObjects[row, column]);
                    }
                    else if (gridHexesObjects[row, column].transform.position == westHex)
                    {
                        adjacentHexesList.Add(gridHexesObjects[row, column]);
                    }
                    else if (gridHexesObjects[row, column].transform.position == eastHex)
                    {
                        adjacentHexesList.Add(gridHexesObjects[row, column]);
                    }
                    else if (gridHexesObjects[row, column].transform.position == southWestHex)
                    {
                        adjacentHexesList.Add(gridHexesObjects[row, column]);
                    }
                    else if (gridHexesObjects[row, column].transform.position == southEastHex)
                    {
                        adjacentHexesList.Add(gridHexesObjects[row, column]);
                    }
                }
            }
            else
            {
                for (int column = 0; column < 9; column++)
                {
                    if (gridHexesObjects[row, column].transform.position == northWestHex)
                    {
                        adjacentHexesList.Add(gridHexesObjects[row, column]);
                    }
                    else if (gridHexesObjects[row, column].transform.position == northEastHex)
                    {
                        adjacentHexesList.Add(gridHexesObjects[row, column]);
                    }
                    else if (gridHexesObjects[row, column].transform.position == westHex)
                    {
                        adjacentHexesList.Add(gridHexesObjects[row, column]);
                    }
                    else if (gridHexesObjects[row, column].transform.position == eastHex)
                    {
                        adjacentHexesList.Add(gridHexesObjects[row, column]);
                    }
                    else if (gridHexesObjects[row, column].transform.position == southWestHex)
                    {
                        adjacentHexesList.Add(gridHexesObjects[row, column]);
                    }
                    else if (gridHexesObjects[row, column].transform.position == southEastHex)
                    {
                        adjacentHexesList.Add(gridHexesObjects[row, column]);
                    }
                }
            }
        }
        return adjacentHexesList;
    }
    private RaycastHit2D MousePositionToRaycasHit2D()
    {
        LayerMask clickabesLayer = LayerMask.GetMask("ClickablesLayer");
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
        RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero, clickabesLayer);
        return hit;
    }
    private void ClearAllHexes()
    {
        GameObject[,] gridHexesObjects = map.gridHexesObjects;
        for (int row = 0; row < 8; row++)
        {
            if (row % 2 == 0)
            {
                for (int column = 0; column < 8; column++)
                {
                    gridHexesObjects[row, column].GetComponent<SpriteRenderer>().color = Color.white;
                }
            }
            else
            {
                for (int column = 0; column < 9; column++)
                {
                    gridHexesObjects[row, column].GetComponent<SpriteRenderer>().color = Color.white;
                }
            }
        }
    }
    private void MoveToGoal(List<GameObject> path)
    {
        try
        {
            if (pathIndex != path.Count)
            {
                t += 0.01f;
                player.transform.position = new Vector3(Mathf.Lerp(path[pathIndex - 1].transform.position.x, path[pathIndex].transform.position.x, t), Mathf.Lerp(path[pathIndex - 1].transform.position.y, path[pathIndex].transform.position.y, t));
                if (path[pathIndex - 1].transform.position == path[pathIndex].transform.position)
                {
                    t = 0f;
                    pathIndex++;
                }
            }
            else
            {
                pathIndex = 1;
            }
        }
        catch
        {
            Debug.Log(pathIndex);
        }
    }
    private void DisplayPath()
    {
        ClearAllHexes();
        List<GameObject> path = BFS(selectedGameObject, selectedGoal);
        foreach (var item in path)
        {
            item.GetComponent<SpriteRenderer>().color = Color.yellow;
        }
        selectedGameObject.GetComponent<SpriteRenderer>().color = Color.red;
        selectedGoal.GetComponent<SpriteRenderer>().color = Color.green;
    }
}