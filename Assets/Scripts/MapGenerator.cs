using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public GameObject testObject;
    public IDictionary<Vector3, GameObject> hexReference = new Dictionary<Vector3, GameObject>();
    public IDictionary<Vector3, bool> walkablePositions = new Dictionary<Vector3, bool>();
    private void Start()    
    {
        GenerateClassroomGrid();
    }
    private void GenerateClassroomGrid()
    {
        float xPosition = -4.2f, yPosition = 3.65f;//Posição inicial dos hexes(o primeiro fica no canto superior esquerdo)
        float xDistance = 1.2f, yDistance = 1.05f;//Distância entre o ponto central dos hexes

        for (int row = 1; row <= 8; row++)
        {
            if (row % 2 == 1)
            {
                xPosition = -4.2f;
                for (int column = 1; column <= 8; column++)
                {
                    GameObject hexObject = Instantiate(testObject, new Vector3(xPosition, yPosition, 0.0f), Quaternion.identity);
                    hexObject.name = "Hex (" + row + "," + column + ")";
                    xPosition += xDistance;
                    hexReference.Add(new KeyValuePair<Vector3, GameObject>(hexObject.transform.position, hexObject));
                    walkablePositions.Add(new KeyValuePair<Vector3, bool>(hexObject.transform.position, true));
                }
            }
            else
            {
                xPosition = -4.8f;
                for (int column = 1; column <= 9; column++)
                {
                    GameObject hexObject = Instantiate(testObject, new Vector3(xPosition, yPosition, 0.0f), Quaternion.identity);
                    hexObject.name = "Hex (" + row + "," + column + ")";
                    xPosition += xDistance;
                    hexReference.Add(new KeyValuePair<Vector3, GameObject>(hexObject.transform.position, hexObject));
                    walkablePositions.Add(new KeyValuePair<Vector3, bool>(hexObject.transform.position, true));
                }
            }
            yPosition -= yDistance;
        }
    }
}
