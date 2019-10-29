using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GzoneScript : MonoBehaviour
{
    
    
    
   

    private void Update()
    {
        StartCoroutine(GravityZone());
    }

    IEnumerator GravityZone()
    {
        
        Collider[] colliders = Physics.OverlapSphere(transform.position, 2f);
        foreach (Collider collider in colliders)
        {
                Rigidbody rb2 = collider.GetComponent<Rigidbody>();
                if (rb2)
                {
                    rb2.AddForce(transform.up * 15f);
                }
        }
        yield return null;
       
    }
    
}
