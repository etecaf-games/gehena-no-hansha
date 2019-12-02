using UnityEngine;
public class CombatAnimationManager : MonoBehaviour
{
    public void AttackAnimation(Animator attackerAnimator, Animator defenderAnimator)
    {
        GameObject attacker = attackerAnimator.gameObject;
        GameObject defender = defenderAnimator.gameObject;
        attackerAnimator.SetTrigger("attacking");
        TurnTowardsTarget(attacker, defender);
        defenderAnimator.SetTrigger("defending");
        TurnTowardsTarget(defenderAnimator.gameObject, attackerAnimator.gameObject);
        if (defenderAnimator.gameObject.GetComponent<Stats>().currentHealthPoints > 0)
        {
            defenderAnimator.SetBool("isAlive", true);
        }
        else
        {
            defenderAnimator.SetBool("isAlive", false);
        }
    }
    public void TakeDamage(Animator defenderAnimator)
    {
        defenderAnimator.SetTrigger("defending");
        if (defenderAnimator.gameObject.GetComponent<Stats>().currentHealthPoints > 0)
        {
            defenderAnimator.SetBool("isAlive", true);
        }
        else
        {
            defenderAnimator.SetBool("isAlive", false);
        }
    }
    public void FenrirSkill01Animation(Animator fenrirAnimator)
    {
        fenrirAnimator.SetTrigger("skill01");
    }
    public void MoveAnimation(Animator currentCharacter, bool isMoving)
    {
        currentCharacter.SetBool("moving", isMoving);
    }
    public void TurnTowardsTarget(GameObject character, GameObject target)
    {
        Vector3 characterPosition = character.transform.position;
        Vector3 targetPosition = target.transform.position;
        SpriteRenderer characterSprite = character.GetComponent<SpriteRenderer>();

        if (characterPosition.x > targetPosition.x)//personagem está na direita do target
        {
            if (character.tag == "Enemy")
            {
                characterSprite.flipX = false;
            }
            else
            {
                characterSprite.flipX = true;
            }
        }
        else if (characterPosition.x < targetPosition.x)
        {
            if (character.tag == "Enemy")
            {
                characterSprite.flipX = true;
            }
            else
            {
                characterSprite.flipX = false;
            }
        }
    }
}