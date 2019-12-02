using UnityEngine;
using System.Collections.Generic;
public class MapGenerator : MonoBehaviour
{
    //This script creates the hexes in the scene!
    [HideInInspector]
    public List<Vector3> gridHexesPositions = new List<Vector3>();
    [HideInInspector]
    public List<GameObject> gridHexesObjects = new List<GameObject>();
    public GameObject hexPrefab;
    public float xDistance = 1.2f;
    public float yDistance = 0.525f;
    public float zDistance = 0.9f; //Distância entre o ponto central dos hexes
    public bool classroomFight = false;
    public bool corridorFight = false;
    public bool terraceFight = false;
    private Pathfinding pathfinding;
    private void Start()
    {
        pathfinding = GetComponent<Pathfinding>();
        if (classroomFight)
        {
            GenerateClassroomGrid();
        }
        else if (corridorFight)
        {
            GenerateCorridorGrid();
        }
        else if (terraceFight)
        {
            GenerateTerraceGrid();
        }
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject player in players)
        {
            GameObject hexWithAPlayer = pathfinding.CharacterToHexPosition(player);
            hexWithAPlayer.GetComponent<HexProperties>().CharacterInHex = player;
        }
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
            GameObject hexWithAnEnemy = pathfinding.CharacterToHexPosition(enemy);
            hexWithAnEnemy.GetComponent<HexProperties>().CharacterInHex = enemy;
        }
    }
    private void GenerateClassroomGrid()
    {
        float yPosition = 1.575f, zPosition = 2.7f;//Posição inicial dos hexes(o primeiro fica no canto superior esquerdo)
        for (int row = 0; row < 7; row++)
        {
            float xPosition;
            switch (row)
            {
                case 0:
                    xPosition = -3.0f;
                    for (int column = 0; column < 6; column++)
                    {
                        if (column < 3)
                        {
                            InstantiateHex(xPosition, yPosition, zPosition, row, column, true);
                        }
                        else
                        {
                            InstantiateHex(xPosition, yPosition, zPosition, row, column, false);
                        }
                        xPosition += xDistance;
                    }
                    break;
                case 1:
                    xPosition = -3.6f;
                    for (int column = 0; column < 7; column++)
                    {
                        if (column < 3)
                        {
                            InstantiateHex(xPosition, yPosition, zPosition, row, column, true);
                        }
                        else
                        {
                            InstantiateHex(xPosition, yPosition, zPosition, row, column, false);
                        }
                        xPosition += xDistance;
                    }
                    break;
                case 2:
                    xPosition = -4.2f;
                    for (int column = 0; column < 8; column++)
                    {
                        if (column < 4)
                        {
                            InstantiateHex(xPosition, yPosition, zPosition, row, column, true);
                        }
                        else
                        {
                            InstantiateHex(xPosition, yPosition, zPosition, row, column, false);
                        }
                        xPosition += xDistance;
                    }
                    break;
                case 3:
                    xPosition = -4.8f;
                    for (int column = 0; column < 9; column++)
                    {
                        if (column < 4)
                        {
                            InstantiateHex(xPosition, yPosition, zPosition, row, column, true);
                        }
                        else
                        {
                            InstantiateHex(xPosition, yPosition, zPosition, row, column, false);
                        }
                        xPosition += xDistance;
                    }
                    break;
                case 4:
                    xPosition = -4.2f;
                    for (int column = 0; column < 8; column++)
                    {
                        if (column < 4)
                        {
                            InstantiateHex(xPosition, yPosition, zPosition, row, column, true);
                        }
                        else
                        {
                            InstantiateHex(xPosition, yPosition, zPosition, row, column, false);
                        }
                        xPosition += xDistance;
                    }
                    break;
                case 5:
                    xPosition = -3.6f;
                    for (int column = 0; column < 7; column++)
                    {
                        if (column < 3)
                        {
                            InstantiateHex(xPosition, yPosition, zPosition, row, column, true);
                        }
                        else
                        {
                            InstantiateHex(xPosition, yPosition, zPosition, row, column, false);
                        }
                        xPosition += xDistance;
                    }
                    break;
                case 6:
                    xPosition = -3.0f;
                    for (int column = 0; column < 6; column++)
                    {
                        if (column < 3)
                        {
                            InstantiateHex(xPosition, yPosition, zPosition, row, column, true);
                        }
                        else
                        {
                            InstantiateHex(xPosition, yPosition, zPosition, row, column, false);
                        }
                        xPosition += xDistance;
                    }
                    break;
                default:
                    Debug.Log("Invalid row generation");
                    break;
            }
            yPosition -= yDistance;
            zPosition -= zDistance;
        }
    }
    private void GenerateCorridorGrid()
    {
        float yPosition = 0.525f, zPosition = 0.9f;//Posição inicial dos hexes(o primeiro fica no canto superior esquerdo)
        for (int row = 0; row < 3; row++)
        {
            float xPosition;
            switch (row)
            {
                case 0:
                    xPosition = -3.6f;
                    for (int column = 0; column < 7; column++)
                    {
                        if (column < 3)
                        {
                            InstantiateHex(xPosition, yPosition, zPosition, row, column, true);
                        }
                        else
                        {
                            InstantiateHex(xPosition, yPosition, zPosition, row, column, false);
                        }
                        xPosition += xDistance;
                    }
                    break;
                case 1:
                    xPosition = -4.2f;
                    for (int column = 0; column < 8; column++)
                    {
                        if (column < 4)
                        {
                            InstantiateHex(xPosition, yPosition, zPosition, row, column, true);
                        }
                        else
                        {
                            InstantiateHex(xPosition, yPosition, zPosition, row, column, false);
                        }
                        xPosition += xDistance;
                    }
                    break;
                case 2:
                    xPosition = -3.6f;
                    for (int column = 0; column < 7; column++)
                    {
                        if (column < 3)
                        {
                            InstantiateHex(xPosition, yPosition, zPosition, row, column, true);
                        }
                        else
                        {
                            InstantiateHex(xPosition, yPosition, zPosition, row, column, false);
                        }
                        xPosition += xDistance;
                    }
                    break;
            }
            yPosition -= yDistance;
            zPosition -= zDistance;
        }
    }
    private void GenerateTerraceGrid()
    {
        float yPosition = 2.1f, zPosition = 3.6f;//Posição inicial dos hexes(o primeiro fica no canto superior esquerdo)
        for (int row = 0; row < 9; row++)
        {
            float xPosition;
            switch (row)
            {
                case 0:
                    xPosition = -4.3f;
                    for (int column = 0; column < 8; column++)
                    {
                        if (column < 4)
                        {
                            InstantiateHex(xPosition, yPosition, zPosition, row, column, true);
                        }
                        else
                        {
                            InstantiateHex(xPosition, yPosition, zPosition, row, column, false);
                        }
                        xPosition += xDistance;
                    }
                    break;
                case 1:
                    xPosition = -4.9f;
                    for (int column = 0; column < 9; column++)
                    {
                        if (column < 4)
                        {
                            InstantiateHex(xPosition, yPosition, zPosition, row, column, true);
                        }
                        else
                        {
                            InstantiateHex(xPosition, yPosition, zPosition, row, column, false);
                        }
                        xPosition += xDistance;
                    }
                    break;
                case 2:
                    xPosition = -5.5f;
                    for (int column = 0; column < 10; column++)
                    {
                        if (column < 5)
                        {
                            InstantiateHex(xPosition, yPosition, zPosition, row, column, true);
                        }
                        else
                        {
                            InstantiateHex(xPosition, yPosition, zPosition, row, column, false);
                        }
                        xPosition += xDistance;
                    }
                    break;
                case 3:
                    xPosition = -6.1f;
                    for (int column = 0; column < 11; column++)
                    {
                        if (column < 5)
                        {
                            InstantiateHex(xPosition, yPosition, zPosition, row, column, true);
                        }
                        else
                        {
                            InstantiateHex(xPosition, yPosition, zPosition, row, column, false);
                        }
                        xPosition += xDistance;
                    }
                    break;
                case 4:
                    xPosition = -5.5f;
                    for (int column = 0; column < 10; column++)
                    {
                        if (column < 5)
                        {
                            InstantiateHex(xPosition, yPosition, zPosition, row, column, true);
                        }
                        else
                        {
                            InstantiateHex(xPosition, yPosition, zPosition, row, column, false);
                        }
                        xPosition += xDistance;
                    }
                    break;
                case 5:
                    xPosition = -6.1f;
                    for (int column = 0; column < 11; column++)
                    {
                        if (column < 5)
                        {
                            InstantiateHex(xPosition, yPosition, zPosition, row, column, true);
                        }
                        else
                        {
                            InstantiateHex(xPosition, yPosition, zPosition, row, column, false);
                        }
                        xPosition += xDistance;
                    }
                    break;
                case 6:
                    xPosition = -5.5f;
                    for (int column = 0; column < 10; column++)
                    {
                        if (column < 5)
                        {
                            InstantiateHex(xPosition, yPosition, zPosition, row, column, true);
                        }
                        else
                        {
                            InstantiateHex(xPosition, yPosition, zPosition, row, column, false);
                        }
                        xPosition += xDistance;
                    }
                    break;
                case 7:
                    xPosition = -4.9f;
                    for (int column = 0; column < 9; column++)
                    {
                        if (column < 4)
                        {
                            InstantiateHex(xPosition, yPosition, zPosition, row, column, true);
                        }
                        else
                        {
                            InstantiateHex(xPosition, yPosition, zPosition, row, column, false);
                        }
                        xPosition += xDistance;
                    }
                    break;
                case 8:
                    xPosition = -4.3f;
                    for (int column = 0; column < 8; column++)
                    {
                        if (column < 4)
                        {
                            InstantiateHex(xPosition, yPosition, zPosition, row, column, true);
                        }
                        else
                        {
                            InstantiateHex(xPosition, yPosition, zPosition, row, column, false);
                        }
                        xPosition += xDistance;
                    }
                    break;
            }
            yPosition -= yDistance;
            zPosition -= zDistance;
        }
    }
    private void InstantiateHex(float xPosition, float yPosition, float zPosition, int row, int column, bool initialHex)
    {
        Vector3 hexPosition = new Vector3(xPosition, yPosition, zPosition);
        Vector3 hexRotation = new Vector3(60f, 0f, 0f);

        GameObject hexObject = Instantiate(hexPrefab, hexPosition, Quaternion.Euler(hexRotation));

        gridHexesPositions.Add(hexPosition);

        hexObject.name = "Hex (" + row + "," + column + ")" + " (" + gridHexesPositions.Count + ") ";

        HexProperties hexProperties = hexObject.GetComponent<HexProperties>();
        hexProperties.initialHex = initialHex;
        hexProperties.row = row;
        hexProperties.column = column;

        gridHexesObjects.Add(hexObject);
    }
}