using UnityEngine;
using System;
using System.Collections;
using Pathfinding;

public class IdleState : State
{
    private ArrayList enemyList = new ArrayList();

    public IdleState(Unit character) : base(character)
    {
    }

    public override void Tick()
    {
        MakeEnemyList();

        if (CheckEnemyInAttackRange())
        {
            character.SetState(new AttackState(character)); 
        }
        else if(CheckEnemyInRunRange()) {
            character.SetState(new RunState(character));
        }

    }

    public override void OnStateEnter()
    {
        character.anim.SetBool("EnemyNearby", false);
        character.anim.SetBool("EnemyAttack", false);
        character._selfTransform = character.GetComponent<Transform>();
    }

    //Checking enemy in sphere around a unit and make list
    private void MakeEnemyList()
    {
        enemyList.Clear();

        Collider[] checkEnemies = Physics.OverlapSphere(character._selfTransform.position, 20);
        foreach (var collider in checkEnemies)
        {
            if (collider.tag == character.enemyTag)
            {
                enemyList.Add(collider);
            }
        }
    }

    //Check if unit can run to enemy (if enemy close enough)
    private bool CheckEnemyInRunRange()
    {
        foreach (Collider collider in enemyList)
        {
            if (Vector3.Distance(character._selfTransform.position, collider.transform.position) <= character.unitStats.chaseRadius)
            {
                character.target = collider.transform;
                return true;
            }
        }

        return false;
    }

    //Check if unit can attack the enemy (if enemy close enough)
    private bool CheckEnemyInAttackRange()
    {
        foreach (Collider collider in enemyList)
        {
            if (Vector3.Distance(character._selfTransform.position, collider.transform.position) <= character.unitStats.attackRadius)
            {
                character.target = collider.transform;
                return true;
            }
        }

        return false;
    }
}
