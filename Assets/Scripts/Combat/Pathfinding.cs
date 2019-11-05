using System.Collections.Generic;
using UnityEngine;
public class Pathfinding : MonoBehaviour
{
    private MapGenerator mapGenerator;
    private InputManager inputManager;
    private TurnManager turnManager;
    public int range;
    private void Start()
    {
        mapGenerator = GetComponent<MapGenerator>();
        inputManager = GetComponent<InputManager>();
        turnManager = GetComponent<TurnManager>();
    }
    public void FindHexAvailableForMovement(int movementLeft)
    {
        GameObject currentCharacter = turnManager.GetCharacterInTurn();
        GameObject currentHex = CharacterToHexPosition(currentCharacter);
        List<GameObject> adjacentHexes = new List<GameObject>();
        List<GameObject> allHexes = new List<GameObject>();
        for (int i = 0; i < movementLeft; i++)
        {
            if (i == 0)
            {
                adjacentHexes = FindAdjacentHexes(currentHex);
            }
            else
            {
                List<GameObject> tempHexes = new List<GameObject>();
                foreach (var adjacentHex in adjacentHexes)
                {
                    tempHexes = FindAdjacentHexes(adjacentHex);
                    foreach (var tempHex in tempHexes)
                    {
                        if (!adjacentHexes.Contains(tempHex) && tempHex != currentHex)
                        {
                            allHexes.Add(tempHex);
                        }
                    }
                }
            }
            adjacentHexes.AddRange(allHexes);
        }
    }
    public void DisplayAvailableHexesToMove()
    {
        GameObject currentCharacter = turnManager.GetCharacterInTurn();
        GameObject currentHex = CharacterToHexPosition(currentCharacter);
        List<GameObject> moveableHexes = new List<GameObject>();
        foreach (var item in moveableHexes)
        {
            //Debug.Log(item);
            item.GetComponent<HexProperties>().canMove = true;
            item.GetComponentInChildren<SpriteRenderer>().color = Color.yellow;
        }
        currentHex.GetComponentInChildren<SpriteRenderer>().color = Color.white;
    }
    //public void DisplayAvailableHexesToAttack()
    //{
    //    GameObject currentCharacter = turnManager.GetCharacterInTurn();
    //    GameObject currentHex = CharacterToHexPosition(currentCharacter);
    //    List<GameObject> adjacentHexes = new List<GameObject>();
    //    List<GameObject> allHexes = new List<GameObject>();
    //    for (int i = 0; i < range; i++)
    //    {
    //        if (i == 0)
    //        {
    //            adjacentHexes = FindAdjacentHexes(currentHex);
    //        }
    //        else
    //        {
    //            List<GameObject> tempHexes = new List<GameObject>();
    //            foreach (var adjacentHex in adjacentHexes)
    //            {
    //                tempHexes = FindAdjacentHexes(adjacentHex);
    //                foreach (var tempHex in tempHexes)
    //                {
    //                    if (!adjacentHexes.Contains(tempHex) && tempHex != currentHex)
    //                    {
    //                        allHexes.Add(tempHex);
    //                    }
    //                }
    //            }
    //        }
    //        adjacentHexes.AddRange(allHexes);
    //    }
    //    foreach (var item in adjacentHexes)
    //    {
    //        //Debug.Log(item);
    //        item.GetComponent<HexProperties>().canAttack = true;
    //        item.GetComponentInChildren<SpriteRenderer>().color = Color.red;
    //    }
    //    currentHex.GetComponentInChildren<SpriteRenderer>().color = Color.white;
    //}
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
        List<GameObject> gridHexesObjects = mapGenerator.gridHexesObjects;

        Vector3 northWestHexPosition = new Vector3(currentHexPosition.x - 0.6f, currentHexPosition.y + 0.525f, currentHexPosition.z + 0.9f);
        Vector3 northEastHexPosition = new Vector3(currentHexPosition.x + 0.6f, currentHexPosition.y + 0.525f, currentHexPosition.z + 0.9f);
        Vector3 westHexPosition = new Vector3(currentHexPosition.x - 1.2f, currentHexPosition.y, currentHexPosition.z);
        Vector3 eastHexPosition = new Vector3(currentHexPosition.x + 1.2f, currentHexPosition.y, currentHexPosition.z);
        Vector3 southWestHexPosition = new Vector3(currentHexPosition.x - 0.6f, currentHexPosition.y - 0.525f, currentHexPosition.z - 0.9f);
        Vector3 southEastHexPosition = new Vector3(currentHexPosition.x + 0.6f, currentHexPosition.y - 0.525f, currentHexPosition.z - 0.9f);

        foreach (GameObject hex in gridHexesObjects)
        {
            Vector3 hexPosition = hex.transform.position;
            if (hexPosition == northWestHexPosition)
            {
                adjacentHexesList.Add(hex);
            }
            else if (hexPosition == northEastHexPosition)
            {
                adjacentHexesList.Add(hex);
            }
            else if (hexPosition == westHexPosition)
            {
                adjacentHexesList.Add(hex);
            }
            else if (hexPosition == eastHexPosition)
            {
                adjacentHexesList.Add(hex);
            }
            else if (hexPosition == southWestHexPosition)
            {
                adjacentHexesList.Add(hex);
            }
            else if (hexPosition == southEastHexPosition)
            {
                adjacentHexesList.Add(hex);
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
    public GameObject CharacterToHexPosition(GameObject character)
    {
        List<GameObject> gridHexesObjects = mapGenerator.gridHexesObjects;
        GameObject returnHex = null;
        foreach (GameObject hex in gridHexesObjects)
        {
            Vector3 hexPosition = hex.transform.position;
            if (hexPosition == character.transform.position)
            {
                returnHex = hex;
            }
        }
        //this should never happen
        if (returnHex == null)
        {
            Debug.Log("Deu Merda no Pathfinding pra converter o personagem pra hexPosition");
        }
        return returnHex;
    }
    public void ClearAllHexes()
    {
        List<GameObject> gridHexesObjects = mapGenerator.gridHexesObjects;
        foreach (GameObject hex in gridHexesObjects)
        {
            hex.GetComponentsInChildren<SpriteRenderer>()[0].color = Color.white;
            HexProperties hexProperties = hex.GetComponent<HexProperties>();
            hexProperties.canMove = false;
            hexProperties.canAttack = false;
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