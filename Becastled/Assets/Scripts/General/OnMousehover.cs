using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnMousehover : MonoBehaviour
{

    private Vector3 mousePos;
    private Vector3 objectPos;
    public GameObject knightPrefab;
    public GameObject axemanPrefab;
    public GameObject meteorPrefab;

    void Update()
    {
       
        
    }
    public void OnMouseOver()
    {
        if (Input.GetKeyDown("c"))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            Physics.Raycast(ray, out hit);
            Instantiate(knightPrefab, hit.point, Quaternion.identity);
            
        } else if (Input.GetKeyDown("v"))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            Physics.Raycast(ray, out hit);
            Instantiate(axemanPrefab, hit.point, Quaternion.identity);
        } else if (Input.GetKeyDown("x"))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            Physics.Raycast(ray, out hit);
            Instantiate(meteorPrefab, hit.point, Quaternion.identity);
        }

    }
    
}


