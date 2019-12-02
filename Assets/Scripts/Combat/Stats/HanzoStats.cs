using UnityEngine;

public class HanzoStats : MonoBehaviour
{public string characterName = "Hanzo";

   int maxHealthPoints = (GlobalControl.Instance.HPBaseHanzo * 5) + (GlobalControl.Instance.HPBaseHanzo * GlobalControl.Instance.vitalityHanzo);
  int currentHealthPoints;
     int maxSoulPoints = (GlobalControl.Instance.SPBaseHanzo * 5) + (GlobalControl.Instance.SPBaseHanzo * GlobalControl.Instance.spiritHanzo);
     int currentSoulPoints;
     int maxMove = GlobalControl.Instance.moveHanzo;
    int currentMove;
     int range = GlobalControl.Instance.rangeHanzo;
     int maxActionPoints = GlobalControl.Instance.actionPointsHanzo;
     int currentActionPoints;

     int strength = GlobalControl.Instance.strengthHanzo;
     int attack = GlobalControl.Instance.attackHanzo;
     int resistance = GlobalControl.Instance.resistanceHanzo; 
     int defense = GlobalControl.Instance.defenseHanzo;
     int agility = GlobalControl.Instance.agilityHanzo;
     int magic = GlobalControl.Instance.magicHanzo;
     int vitality = GlobalControl.Instance.vitalityHanzo;
     int spirit = GlobalControl.Instance.spiritHanzo;

     private bool isAlive = true;
    
    public bool IsAlive
     {
         get
         {
             return isAlive;
         }
         set
         {
             isAlive = value;
             if (!value)
             {
                 TurnManager turnManager = Camera.main.GetComponent<TurnManager>();
                 turnManager.RemoveCharacterFromQueue(gameObject);
             }

         }
     }
    
    void start()
    {

      maxHealthPoints = (GlobalControl.Instance.HPBaseHanzo * 5) + (GlobalControl.Instance.HPBaseHanzo * GlobalControl.Instance.vitalityHanzo);
     maxSoulPoints = (GlobalControl.Instance.SPBaseHanzo * 5) + (GlobalControl.Instance.SPBaseHanzo * GlobalControl.Instance.spiritHanzo);
     maxMove = GlobalControl.Instance.moveHanzo;
   range = GlobalControl.Instance.rangeHanzo;
    maxActionPoints = GlobalControl.Instance.actionPointsHanzo;
    

     strength = GlobalControl.Instance.strengthHanzo;
     attack = GlobalControl.Instance.attackHanzo;
    resistance = GlobalControl.Instance.resistanceHanzo; 
     defense = GlobalControl.Instance.defenseHanzo;
    agility = GlobalControl.Instance.agilityHanzo;
   magic = GlobalControl.Instance.magicHanzo;
   vitality = GlobalControl.Instance.vitalityHanzo;
   spirit = GlobalControl.Instance.spiritHanzo;
        currentHealthPoints = maxHealthPoints;
        currentActionPoints = maxActionPoints;
        currentMove = maxMove;
        currentSoulPoints = maxSoulPoints;

    }
}

