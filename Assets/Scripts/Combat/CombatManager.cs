using UnityEngine;
public class CombatManager : MonoBehaviour
{
    private TurnManager turnManager;
    private void Start()
    {
        turnManager = GetComponent<TurnManager>();
    }
    public void Combat(GameObject attacker, GameObject defender)
    {
        Stats attackerStats = attacker.GetComponent<Stats>();
        int attackerMisses = 0;
        int attackerHits = 0;
        int attackerMagicHits = 0;
        int attackerCriticalHits = 0;
        int minimumDamage;
        int attackerTotalDamage;
        int totalDamage;
        for (int rolls = attackerStats.attack; rolls > 0; rolls--)//rola a quantidade de attack
        {
            int attackerRollResult = DiceRoll();
            switch (attackerRollResult)
            {
                case 1:
                    attackerMisses++;
                    ////Debug.Log("1 - ERRO");
                    break;
                case 2:
                    attackerHits++;
                    ////Debug.Log("2 - Acerto");
                    break;
                case 3:
                    attackerHits++;
                    ////Debug.Log("3 - Acerto");
                    break;
                case 4:
                    attackerMagicHits++;
                    ////Debug.Log("4 - Elemento");
                    break;
                case 5:
                    //attacker.Hansha();
                    ////Debug.Log("5 - Hansha");
                    break;
                case 6:
                    if (attackerCriticalHits < attackerStats.agility)
                    {
                        attackerCriticalHits++;
                        rolls++;
                        //Debug.Log("6 - Crítico +1 Dado");
                    }
                    else
                    {
                        //Debug.Log("6 - Crítico sem dados");
                    }
                    break;
            }
        }
        minimumDamage = attackerHits + attackerMagicHits + attackerCriticalHits;
        attackerTotalDamage = (attackerHits * attackerStats.strength) + (attackerMagicHits * attackerStats.magic) + (attackerCriticalHits * attackerStats.strength);

        Stats defenderStats = defender.GetComponent<Stats>();
        int defenderMisses = 0;
        int defenderHits = 0;
        int defenderMagicHits = 0;
        int defenderCriticalHits = 0;
        int defenderReducedDamage;
        for (int rolls = defenderStats.defense; rolls > 0; rolls--)
        {
            int defenderRollResult = DiceRoll();
            switch (defenderRollResult)
            {
                case 1:
                    defenderMisses++;
                    //Debug.Log("1 - ERRO");
                    break;
                case 2:
                    defenderHits++;
                    //Debug.Log("2 - Acerto");
                    break;
                case 3:
                    defenderHits++;
                    //Debug.Log("3 - Acerto");
                    break;
                case 4:
                    defenderMagicHits++;
                    //Debug.Log("4 - Elemento");
                    break;
                case 5:
                    //attacker.Hansha();
                    //Debug.Log("5 - Hansha");
                    break;
                case 6:
                    if (defenderCriticalHits < defenderStats.agility)
                    {
                        defenderCriticalHits++;
                        rolls++;
                        //Debug.Log("6 - Crítico +1 Dado");
                    }
                    else
                    {
                        //Debug.Log("6 - Crítico sem dados");
                    }
                    break;
            }
        }
        defenderReducedDamage = (defenderHits * defenderStats.resistance) + (defenderMagicHits * defenderStats.magic) + (defenderCriticalHits * defenderStats.resistance);
        totalDamage = attackerTotalDamage - defenderReducedDamage;
        //Debug.Log("attackerTotalDamage = " + attackerTotalDamage);
        //Debug.Log("defenderReducedDamage = " + defenderReducedDamage);
        //Debug.Log("totalDamage = " + totalDamage);
        //Debug.Log("minimumDamage = " + minimumDamage);
        if (totalDamage < minimumDamage)
        {
            totalDamage = minimumDamage;
        }
        //Debug.Log("totalDamage = " + totalDamage);
        defenderStats.currentHealthPoints -= totalDamage;
        turnManager.UpdateCombatUIValues(false);
    }
    private int DiceRoll()
    {
        int rollResult = Random.Range(1, 7);
        return rollResult;
    }
}