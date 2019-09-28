using UnityEngine;
using System.Collections.Generic;
public class MapGenerator : MonoBehaviour
{
    public GameObject[,] gridHexesObjects = new GameObject[8, 9];
    public Vector3[,] gridHexesPositions = new Vector3[8, 9];
    public GameObject hexPrefab;
    private void Start()
    {
        GenerateClassroomGrid();
    }
    private void GenerateClassroomGrid()
    {
        float yPosition = 3.65f;//Posição inicial dos hexes(o primeiro fica no canto superior esquerdo)
        float xDistance = 1.2f, yDistance = 1.05f; //Distância entre o ponto central dos hexes
        for (int row = 0; row < 8; row++)
        {
            if (row % 2 == 0)
            {
                float xPosition = -4.2f;
                for (int column = 0; column < 8; column++)
                {
                    Vector3 hexPosition = new Vector3(xPosition, yPosition, 0.0f);
                    GameObject hexObject = Instantiate(hexPrefab, hexPosition, Quaternion.identity);

                    gridHexesPositions[row, column] = hexPosition;
                    gridHexesObjects[row, column] = hexObject;

                    hexObject.name = "Hex (" + row + "," + column + ")";
                    xPosition += xDistance;
                }
            }
            else
            {
                float xPosition = -4.8f;
                for (int column = 0; column < 9; column++)
                {
                    Vector3 hexPosition = new Vector3(xPosition, yPosition, 0.0f);
                    GameObject hexObject = Instantiate(hexPrefab, hexPosition, Quaternion.identity);

                    gridHexesPositions[row, column] = hexPosition;
                    gridHexesObjects[row, column] = hexObject;

                    hexObject.name = "Hex (" + row + "," + column + ")";
                    xPosition += xDistance;
                }
            }
            yPosition -= yDistance;
        }
    }
}
