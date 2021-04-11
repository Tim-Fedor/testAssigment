using UnityEngine;
using System;
using System.Collections;
using Pathfinding;

public class AttackState : State
{
    private float attackTimer;

    public AttackState(Unit character) : base(character)
    {
    }

    public override void Tick()
    {
        character.anim.SetBool("EnemyAttack", false);
        if (character.target != null)
        {

            if (CheckTargetInAttackRange())
            {
                SlowTurnToTarget();
                character.anim.SetBool("EnemyAttack", true);
            }
            else
            {
                character.anim.SetBool("EnemyAttack", false);
                character.SetState(new RunState(character));
            }
        }
        else {
            
            character.SetState(new IdleState(character));
        }
        
            

    }

    public override void OnStateEnter()
    {
        character._selfTransform = character.GetComponent<Transform>();
        
    }

    
    
    //Check if unit can attack the target (if enemy close enough)
    private bool CheckTargetInAttackRange()
    {
            if (Vector3.Distance(character._selfTransform.position, character.target.transform.position) <= character.unitStats.attackRadius)
            {
                return true;
            }

     return false;
    }

    private void SlowTurnToTarget()
    {
        Vector3 relativePos = character.target.position - character._selfTransform.position;
        Quaternion toRotation = Quaternion.LookRotation(relativePos);
        character._selfTransform.rotation = Quaternion.Lerp(character._selfTransform.rotation, toRotation, 4 * Time.deltaTime);
    }
}
