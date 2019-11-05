using UnityEngine;
public class CombatManager : MonoBehaviour
{
    public int attackDamage, defenseDamage, damageReduction, totalDamage, attackHits, attackMagicHits, attackCriticalHits, defenseHits, defenseMagicHits, defenseCriticalHits, minimumDamage;
    public Stats attacker, defender;
    public void Start()
    {
        attacker = GetComponent<Stats>();
        defender = GetComponent<Stats>();
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Attack(attacker.strength, attacker.attack, attacker.agility, attacker.magic);//3 attacks, 6 max
            Defense(defender.strength, defender.resistance, defender.defense, defender.agility, defender.magic);//2 attacks, 5 max
            totalDamage = attackDamage - damageReduction;
            Debug.Log("danoTotal = " + totalDamage + " danoDeattack = " + attackDamage + " reducaoDeDano = " + damageReduction);
            if (totalDamage < minimumDamage)
            {
                totalDamage = minimumDamage;
            }
            defender.healthPoints -= totalDamage;
            attackDamage = 0; //reseta os danos
            damageReduction = 0; //reseta os danos
            if (defender.healthPoints <= 0)
            {
                Debug.Log("Morreu defender kkkk");
            }
        }
        if (Input.GetKeyDown(KeyCode.V))
        {
            Attack(attacker.strength, attacker.attack, attacker.agility, attacker.magic);//3 attacks, 6 max
            Defense(defender.strength, defender.resistance, defender.defense, defender.agility, defender.magic);//3 attacks, 6 max
            totalDamage = attackDamage - damageReduction;
            Debug.Log("danoTotal = " + totalDamage + " danoDeattack = " + attackDamage + " reducaoDeDano = " + damageReduction);
            if (totalDamage < minimumDamage)
            {
                totalDamage = minimumDamage;
            }
            defender.healthPoints -= totalDamage;
            attackDamage = 0; // reseta os danos
            damageReduction = 0; //reseta os danos
            if (defender.healthPoints <= 0)
            {
                Debug.Log("Morreu defender kkkk");
            }
        }
    }
    public void Defense(int defenderStrength, int defenderResistance, int defenderDefense, int defenderAgility, int defenderMagic)
    {
        int hits = 0, criticalHits = 0;
        for (int rolls = defenderDefense; rolls > 0; rolls--)//rola a quantidade de defesa
        {
            int rollResult = Roll();
            switch (rollResult)
            {
                case 1:
                    Debug.Log("1 - Erro");
                    break;
                case 2:
                    defenseHits++;
                    Debug.Log("2 - Defesa");
                    break;
                case 3://acerto
                    defenseHits++;
                    Debug.Log("3 - Defesa");
                    break;
                case 4://elemento
                    defenseMagicHits++;//elemento deve ser diferente
                    Debug.Log("4 - magic");
                    break;
                case 5://hansha
                    //defender.Hansha();
                    Debug.Log("5 - HANSHA");
                    break;
                case 6:
                    defenseDamage += defenderStrength;
                    damageReduction += defenderResistance;
                    if (criticalHits < defenderAgility)
                    {
                        criticalHits++;
                        hits++;
                        rolls++;
                        Debug.Log("6 - Crítico +1 Dado");
                    }
                    else
                    {
                        Debug.Log("6 - Crítico sem dados");
                    }
                    break;
            }
        }
        damageReduction = (defenseHits * defenderResistance) + (defenseMagicHits * defenderMagic) + (defenseCriticalHits * defenderResistance);
        Debug.Log("Dano Reduzido: " + damageReduction);
        Debug.Log("Dano Causado por críticos na defesa: " + defenseDamage);
        Debug.Log("Fim da Rolagem");
    }
    public void Attack(int attackerStrength, int attackerAttack, int attackerAgility, int attackerMagic)
    {
        for (int rolls = attackerAttack; rolls > 0; rolls--)//rola a quantidade de attack
        {
            int rollResult = Roll();
            switch (rollResult)
            {
                case 1:
                    Debug.Log("1 - ERRO");
                    break;
                case 2:
                    attackDamage += attackerStrength;
                    attackerAttack++;
                    minimumDamage++;
                    Debug.Log("2 - Acerto");
                    break;
                case 3:
                    attackDamage += attackerStrength;
                    attackerAttack++;
                    minimumDamage++;
                    Debug.Log("3 - Acerto");
                    break;
                case 4:
                    attackDamage += attackerMagic;
                    attackMagicHits++;
                    minimumDamage++;
                    Debug.Log("4 - Elemento");
                    break;
                case 5:
                    //attacker.Hansha();
                    Debug.Log("5 - Hansha");
                    break;
                case 6:
                    attackDamage += attackerStrength;
                    if (attackCriticalHits < attackerAgility)
                    {
                        attackCriticalHits++;
                        rolls++;
                        minimumDamage++;
                        Debug.Log("6 - Crítico +1 Dado");
                    }
                    else
                    {
                        Debug.Log("6 - Crítico sem dados");
                    }
                    break;
            }
        }
        attackDamage = (attackerAttack * attackerStrength) + (attackMagicHits * attackerMagic) + (attackCriticalHits * attackerStrength);
        Debug.Log("Dano Causado: " + attackDamage);
        Debug.Log("Fim da Rolagem");
    }
    public int Roll()
    {
        Random roll = new Random();
        int rollResult = Random.Range(1, 7);
        return rollResult;
    }
}