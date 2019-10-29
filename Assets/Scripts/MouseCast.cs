using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCast : MonoBehaviour
{
    public static Vector3 target;
    public static Vector3 toTarget;
    public GameObject ball;
    public GameObject muzFlash;
    public GameObject line;
    public GameObject lazerHit;
    public GameObject Gzone;

    


    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        toTarget = target - transform.position;
        RaycastHit hit;
        
        if (Physics.Raycast(ray, out hit))
        {
            target = hit.point;
            transform.LookAt(target);
        }

        Debug.DrawRay(transform.position, target, Color.red);
        ShootBall();
        ShootRay();
        DeployZone();
    }

    private void ShootBall()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Instantiate(muzFlash, transform.position, Quaternion.identity);
            Instantiate(ball, transform.position, Quaternion.identity);
        }
    }

    private void ShootRay()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            Instantiate(line, transform.position, Quaternion.identity);

            RaycastHit[] hits = Physics.RaycastAll(transform.position, toTarget);
           
            for (int i = 0; i < hits.Length; i++)
            {
                RaycastHit hit = hits[i];
                Rigidbody rb = hit.transform.GetComponent<Rigidbody>();
                if (rb)
                {
                    Instantiate(lazerHit, hit.point, Quaternion.identity);
                    Rigidbody rb2 = hit.collider.gameObject.GetComponent<Rigidbody>();
                    rb2.AddForceAtPosition(transform.forward * 20, hit.point, ForceMode.Impulse);
                }
            }
            
        }
    }

    private void DeployZone()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            

            RaycastHit[] hits = Physics.RaycastAll(transform.position, toTarget);

            for (int i = 0; i < hits.Length; i++)
            {
                RaycastHit hit = hits[i];
                
                if (hit.transform.gameObject.tag == "floor")
                {
                    target.y += 1.5f;
                    Instantiate(Gzone, target, Quaternion.identity);
                }
            }
            
        }
    }
}
