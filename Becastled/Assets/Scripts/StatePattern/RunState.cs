using UnityEngine;
using System;
using System.Collections;
using Pathfinding;

public class RunState : State
{
    
    public RunState(Unit character) : base(character)
    {
    }

    

    public override void Tick()
    { 
        if(character.target != null)
        {
            if (CheckTargetInAttackRange())
            {
                var ai = character.GetComponent<AIPath>();
                ai.enabled = false;
                character.GetComponent<AIDestinationSetter>().target = null;
                

                character.SetState(new AttackState(character));
            }

        }
        else
        {
            var ai = character.GetComponent<AIPath>();
            ai.enabled = false;

            character.GetComponent<AIDestinationSetter>().target = null;
            character.SetState(new IdleState(character));
        }
        
       

    }

    public override void OnStateEnter()
    {
        var ai = character.GetComponent<AIPath>();
        ai.enabled = true;
        character.GetComponent<AIDestinationSetter>().target = character.target;
        character.anim.SetBool("EnemyNearby", true);
        character._selfTransform = character.GetComponent<Transform>();
    }

    private bool CheckTargetInAttackRange()
    {
        if (Vector3.Distance(character._selfTransform.position, character.target.transform.position) <= character.unitStats.attackRadius)
        {
            return true;
        }

        return false;
    }
}
