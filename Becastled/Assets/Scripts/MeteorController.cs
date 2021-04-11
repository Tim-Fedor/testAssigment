using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorController : MonoBehaviour
{
    private Transform _selfTransform;

    void Start()
    {
        StartCoroutine(waiter());
        _selfTransform = GetComponent<Transform>();


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator waiter()
    {
        yield return new WaitForSeconds(0.5f);
        Collider[] checkEnemies = Physics.OverlapSphere(_selfTransform.position, 3);
        foreach (var collider in checkEnemies)
        {
            var unit = collider.gameObject.GetComponent<Unit>(); 
            if (unit != null)
            {
                unit.TakeDamage(1000);

            }
        }
        yield return new WaitForSeconds(1.5f);
        Destroy(gameObject);
    }
}
