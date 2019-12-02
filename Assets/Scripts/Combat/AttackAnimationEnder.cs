using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackAnimationEnder : MonoBehaviour
{
    public void EndAttackAnimation()
    {
        TurnManager turnManager = Camera.main.GetComponent<TurnManager>();
        turnManager.HasAttacked = true;
    }
}
