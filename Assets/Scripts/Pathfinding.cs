using UnityEngine;
using System.Collections.Generic;
public class Pathfinding : MonoBehaviour
{
    private MapGenerator mapGenerator;
    private InputManager inputManager;
    private TurnManager turnManager;
    private void Start()
    {
        mapGenerator = GetComponent<MapGenerator>();
        inputManager = GetComponent<InputManager>();
        turnManager = GetComponent<TurnManager>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            ClearAllHexes();
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            DisplayPath();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log(turnManager.turnOrder[turnManager.turnIndex].Key.transform.position);//current character position
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            GameObject currentCharacter = turnManager.turnOrder[turnManager.turnIndex].Key;
            GameObject currentHex = CharacterToHexPosition(currentCharacter);
            List<GameObject> path = ReturnShortestPathByBFS(currentHex, inputManager.selectedGoal);
            CheckIfEnoughMovement(path);
        }
        //if (Input.GetKeyDown(KeyCode.J))
        //{
        //    GameObject currentCharacter = turnManager.turnOrder[turnManager.turnIndex].Key;
        //    GameObject currentHex = CharacterToHexPosition(currentCharacter);
        //    List<GameObject> path = ReturnShortestPathByBFS(currentHex, inputManager.selectedGoal);
        //    CountPath(path);
        //}
    }
    public List<GameObject> ReturnShortestPathByBFS(GameObject startHex, GameObject goalHex)
    {
        Queue<GameObject> Q = new Queue<GameObject>();
        List<GameObject> discoveredNodes = new List<GameObject>();
        Dictionary<GameObject, GameObject> nodeParents = new Dictionary<GameObject, GameObject>();//a key é o filho, o value é o pai
        List<GameObject> shortestPath = new List<GameObject>();
        discoveredNodes.Add(startHex);
        Q.Enqueue(startHex);
        while (Q != null)
        {
            GameObject currentHex = Q.Dequeue();//tira o primeiro da fila
            if (currentHex.transform.position == goalHex.transform.position)//aqui encontrou o caminho final
            {
                shortestPath.Add(currentHex);//goal hex
                while (nodeParents.ContainsKey(currentHex))//se o filho tem um pai
                {
                    shortestPath.Add(nodeParents[currentHex]);
                    currentHex = nodeParents[currentHex];//the new currentHex is the parent of the current currentHex
                }
                shortestPath.Reverse();
                shortestPath.RemoveAt(0);
                return shortestPath;
            }
            List<GameObject> adjacentHexes = FindAdjacentHexes(currentHex);
            foreach (GameObject adjacentHex in adjacentHexes)
            {
                if (!discoveredNodes.Contains(adjacentHex))
                {
                    discoveredNodes.Add(adjacentHex);
                    nodeParents.Add(adjacentHex, currentHex);
                    Q.Enqueue(adjacentHex);
                }
            }
        }
        //This part should never happen
        shortestPath.Add(startHex);
        return shortestPath;
    }
    //Finds each hex adjacent to originHex
    private List<GameObject> FindAdjacentHexes(GameObject currentHex)
    {
        Vector3 currentHexPosition = currentHex.transform.position;
        List<GameObject> adjacentHexesList = new List<GameObject>();
        GameObject[,] gridHexesObjects = mapGenerator.gridHexesObjects;

        Vector3 northWestHexPosition = new Vector3(currentHexPosition.x - 0.6f, currentHexPosition.y + 0.525f, currentHexPosition.z + 0.9f);
        Vector3 northEastHexPosition = new Vector3(currentHexPosition.x + 0.6f, currentHexPosition.y + 0.525f, currentHexPosition.z + 0.9f);
        Vector3 westHexPosition = new Vector3(currentHexPosition.x - 1.2f, currentHexPosition.y, currentHexPosition.z);
        Vector3 eastHexPosition = new Vector3(currentHexPosition.x + 1.2f, currentHexPosition.y, currentHexPosition.z);
        Vector3 southWestHexPosition = new Vector3(currentHexPosition.x - 0.6f, currentHexPosition.y - 0.525f, currentHexPosition.z - 0.9f);
        Vector3 southEastHexPosition = new Vector3(currentHexPosition.x + 0.6f, currentHexPosition.y - 0.525f, currentHexPosition.z - 0.9f);
        for (int row = 0; row < 7; row++)
        {
            if (row == 0 || row == 6)
            {
                for (int column = 0; column < 6; column++)
                {
                    Vector3 currentIterationHex = gridHexesObjects[row, column].transform.position;
                    if (currentIterationHex == northWestHexPosition)
                    {
                        adjacentHexesList.Add(gridHexesObjects[row, column]);
                    }
                    else if (currentIterationHex == northEastHexPosition)
                    {
                        adjacentHexesList.Add(gridHexesObjects[row, column]);
                    }
                    else if (currentIterationHex == westHexPosition)
                    {
                        adjacentHexesList.Add(gridHexesObjects[row, column]);
                    }
                    else if (currentIterationHex == eastHexPosition)
                    {
                        adjacentHexesList.Add(gridHexesObjects[row, column]);
                    }
                    else if (currentIterationHex == southWestHexPosition)
                    {
                        adjacentHexesList.Add(gridHexesObjects[row, column]);
                    }
                    else if (currentIterationHex == southEastHexPosition)
                    {
                        adjacentHexesList.Add(gridHexesObjects[row, column]);
                    }
                }
            }
            else if (row == 1 || row == 5)
            {
                for (int column = 0; column < 7; column++)
                {
                    Vector3 currentIterationHex = gridHexesObjects[row, column].transform.position;
                    if (currentIterationHex == northWestHexPosition)
                    {
                        adjacentHexesList.Add(gridHexesObjects[row, column]);
                    }
                    else if (currentIterationHex == northEastHexPosition)
                    {
                        adjacentHexesList.Add(gridHexesObjects[row, column]);
                    }
                    else if (currentIterationHex == westHexPosition)
                    {
                        adjacentHexesList.Add(gridHexesObjects[row, column]);
                    }
                    else if (currentIterationHex == eastHexPosition)
                    {
                        adjacentHexesList.Add(gridHexesObjects[row, column]);
                    }
                    else if (currentIterationHex == southWestHexPosition)
                    {
                        adjacentHexesList.Add(gridHexesObjects[row, column]);
                    }
                    else if (currentIterationHex == southEastHexPosition)
                    {
                        adjacentHexesList.Add(gridHexesObjects[row, column]);
                    }
                }
            }
            else if (row == 2 || row == 4)
            {
                for (int column = 0; column < 8; column++)
                {
                    Vector3 currentIterationHex = gridHexesObjects[row, column].transform.position;
                    if (currentIterationHex == northWestHexPosition)
                    {
                        adjacentHexesList.Add(gridHexesObjects[row, column]);
                    }
                    else if (currentIterationHex == northEastHexPosition)
                    {
                        adjacentHexesList.Add(gridHexesObjects[row, column]);
                    }
                    else if (currentIterationHex == westHexPosition)
                    {
                        adjacentHexesList.Add(gridHexesObjects[row, column]);
                    }
                    else if (currentIterationHex == eastHexPosition)
                    {
                        adjacentHexesList.Add(gridHexesObjects[row, column]);
                    }
                    else if (currentIterationHex == southWestHexPosition)
                    {
                        adjacentHexesList.Add(gridHexesObjects[row, column]);
                    }
                    else if (currentIterationHex == southEastHexPosition)
                    {
                        adjacentHexesList.Add(gridHexesObjects[row, column]);
                    }
                }
            }
            else if (row == 3)
            {
                for (int column = 0; column < 9; column++)
                {
                    Vector3 currentIterationHex = gridHexesObjects[row, column].transform.position;
                    if (currentIterationHex == northWestHexPosition)
                    {
                        adjacentHexesList.Add(gridHexesObjects[row, column]);
                    }
                    else if (currentIterationHex == northEastHexPosition)
                    {
                        adjacentHexesList.Add(gridHexesObjects[row, column]);
                    }
                    else if (currentIterationHex == westHexPosition)
                    {
                        adjacentHexesList.Add(gridHexesObjects[row, column]);
                    }
                    else if (currentIterationHex == eastHexPosition)
                    {
                        adjacentHexesList.Add(gridHexesObjects[row, column]);
                    }
                    else if (currentIterationHex == southWestHexPosition)
                    {
                        adjacentHexesList.Add(gridHexesObjects[row, column]);
                    }
                    else if (currentIterationHex == southEastHexPosition)
                    {
                        adjacentHexesList.Add(gridHexesObjects[row, column]);
                    }
                }
            }
        }
        return adjacentHexesList;
    }
    private void DisplayPath()
    {
        ClearAllHexes();
        GameObject currentCharacter = turnManager.turnOrder[turnManager.turnIndex].Key;
        GameObject currentHex = CharacterToHexPosition(currentCharacter);
        List<GameObject> path = ReturnShortestPathByBFS(currentHex, inputManager.selectedGoal);
        foreach (var item in path)
        {
            item.GetComponentsInChildren<SpriteRenderer>()[0].color = Color.yellow;
        }
        currentCharacter.GetComponentsInChildren<SpriteRenderer>()[0].color = Color.red;
        inputManager.selectedGoal.GetComponentsInChildren<SpriteRenderer>()[0].color = Color.green;
    }
    private GameObject CharacterToHexPosition(GameObject character)
    {
        GameObject[,] gridHexesObjects = mapGenerator.gridHexesObjects;
        for (int row = 0; row < 7; row++)
        {
            if (row == 0 || row == 6)
            {
                for (int column = 0; column < 6; column++)
                {
                    if (gridHexesObjects[row, column].transform.position == character.transform.position)
                    {
                        return gridHexesObjects[row, column];
                    }
                }
            }
            else if (row == 1 || row == 5)
            {
                for (int column = 0; column < 7; column++)
                {
                    if (gridHexesObjects[row, column].transform.position == character.transform.position)
                    {
                        return gridHexesObjects[row, column];
                    }
                }
            }
            else if (row == 2 || row == 4)
            {
                for (int column = 0; column < 8; column++)
                {
                    if (gridHexesObjects[row, column].transform.position == character.transform.position)
                    {
                        return gridHexesObjects[row, column];
                    }
                }
            }
            else if (row == 3)
            {
                for (int column = 0; column < 9; column++)
                {
                    if (gridHexesObjects[row, column].transform.position == character.transform.position)
                    {
                        return gridHexesObjects[row, column];
                    }
                }
            }
        }
        //this should never happen
        Debug.Log("Deu Merda no Pathfinding pra converter o personagem pra hexPosition");
        return gridHexesObjects[0, 0];
    }
    private void ClearAllHexes()
    {
        GameObject[,] gridHexesObjects = mapGenerator.gridHexesObjects;
        for (int row = 0; row < 7; row++)
        {
            if (row == 0 || row == 6)
            {
                for (int column = 0; column < 6; column++)
                {
                    gridHexesObjects[row, column].GetComponentsInChildren<SpriteRenderer>()[0].color = Color.white;
                }
            }
            else if (row == 1 || row == 5)
            {
                for (int column = 0; column < 7; column++)
                {
                    gridHexesObjects[row, column].GetComponentsInChildren<SpriteRenderer>()[0].color = Color.white;
                }
            }
            else if (row == 2 || row == 4)
            {
                for (int column = 0; column < 8; column++)
                {
                    gridHexesObjects[row, column].GetComponentsInChildren<SpriteRenderer>()[0].color = Color.white;
                }
            }
            else if (row == 3)
            {
                for (int column = 0; column < 9; column++)
                {
                    gridHexesObjects[row, column].GetComponentsInChildren<SpriteRenderer>()[0].color = Color.white;
                }
            }
        }
    }
    private void CheckIfEnoughMovement(List<GameObject> path)
    {
        GameObject currentCharacter = turnManager.turnOrder[turnManager.turnIndex].Key;
        Stats currentCharacterStats = currentCharacter.GetComponent<Stats>();
        if (path.Count > currentCharacterStats.move)
        {
            Debug.Log("Impossivel");
        }
        else
        {
            Debug.Log("Possível");
        }
        //ao marcar o goal, faz o caminho até ele, se o caminho for maior que o move, nao permite!
    }
}