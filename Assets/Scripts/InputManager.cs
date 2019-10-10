using UnityEngine;
public class InputManager : MonoBehaviour
{
    private bool thereIsASelectedGoal = false;
    public GameObject selectedGoal;
    private void Update()
    {
        RaycastHit hit = MousePositionToRaycasHit();
        DisplayHexAsGoal(hit);
        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hitMouse = MousePositionToRaycasHit();
            MarkHexAsGoal(hitMouse);
        }
    }
    public void MoveCharacter()
    {
        //Debug.Log
    }
    private void DisplayHexAsGoal(RaycastHit hit)
    {
        if (hit.collider != null)
        {
            GameObject hex = hit.collider.gameObject;
            hex.GetComponentsInChildren<SpriteRenderer>()[0].color = Color.cyan;
        }
    }
    private void MarkHexAsGoal(RaycastHit hit)
    {
        if (!thereIsASelectedGoal)
        {
            if (hit.collider != null)
            {
                selectedGoal = hit.collider.gameObject;
                selectedGoal.GetComponent<HexProperties>().goal = true;
                selectedGoal.GetComponent<HexProperties>().ChangeSpriteColor();
                thereIsASelectedGoal = true;
            }
            else
            {
                Debug.Log("To select a goal, you need to right click something");
            }
        }
        else
        {
            if (hit.collider != null)
            {
                if (hit.collider.gameObject.GetComponent<HexProperties>().goal)
                {
                    Debug.Log("This is already the goal!");
                }
                else
                {
                    selectedGoal.GetComponent<HexProperties>().goal = false;
                    selectedGoal.GetComponent<HexProperties>().ChangeSpriteColor();
                    selectedGoal = hit.collider.gameObject;
                    selectedGoal.GetComponent<HexProperties>().goal = true;
                    selectedGoal.GetComponent<HexProperties>().ChangeSpriteColor();
                }
            }
            else
            {
                selectedGoal.GetComponent<HexProperties>().goal = false;
                selectedGoal.GetComponent<HexProperties>().ChangeSpriteColor();
                thereIsASelectedGoal = false;
            }
        }
    }
    private RaycastHit MousePositionToRaycasHit()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {

        }
        return hit;
    }
}