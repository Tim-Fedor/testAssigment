using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Knight : Unit
{
   
    void Start()
    {
        HP = unitStats.amountHP;
        anim = GetComponent<Animator>();
        SetState(new IdleState(this));
        

    }


    void Update()
    {
        currentState.Tick();
    }

   
}
