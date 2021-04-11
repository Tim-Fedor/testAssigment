using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
   public static void UnitTakeDamage(Unit attacker, Unit taker)
    {
        if(taker != null) {
            var damage = attacker.unitStats.strenght;
            taker.TakeDamage(damage);
        }
        
    }
}
