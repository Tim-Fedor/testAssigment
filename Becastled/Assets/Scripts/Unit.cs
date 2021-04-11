using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public UnitStats unitStats;
    protected float HP;
    public Transform target;
    public string enemyTag;
    public Transform _selfTransform;
    public Animator anim;
    protected State currentState;
    private Transform childObj;
    public GameObject unitRagdoll;
    public GameObject bloodSpray;
    private bool isDead;

    private void Start()
    {
        isDead = false;
        childObj = transform.Find("rig_tank_animation:J_HIPS");
    }
    
    public void DoMeleeDamage()
    {
        if(target != null)
        {
            CombatManager.UnitTakeDamage(this, target.GetComponent<Unit>());
        }
        
    }

    public void EndMeleeAttack()
    {
        Debug.Log("No Attack!");
    }

    public void TakeDamage(float damage)
    {
        HP -= damage;
        Instantiate(bloodSpray, transform.position + Vector3.up * 0.5f, transform.rotation * Quaternion.Euler(90f, 180f, 0f));
        if (HP <= 0 && !isDead)
        {
            isDead = true;
            Death();
        }
        
    }

    public void SetState(State state)
    {
        if (currentState != null)
            currentState.OnStateExit();

        currentState = state;

        if (currentState != null)
            currentState.OnStateEnter();
    }
    private void Death()
    {
        Instantiate(unitRagdoll, transform.position, transform.rotation);
        Destroy(gameObject);
    }

   
}
