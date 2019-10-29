using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazeScript : MonoBehaviour
{
    LineRenderer line;
    public Vector3 startPoint;
    void Start()
    {
        line = gameObject.GetComponent<LineRenderer>();
        startPoint = GameObject.Find("Head").transform.position;
        StartCoroutine(ShootBeam());
    }



    IEnumerator ShootBeam()
    {
        line.SetPosition(1, startPoint);

        RaycastHit[] hits;
        hits = Physics.RaycastAll(transform.position, MouseCast.toTarget);
        for (int i = 0; i < hits.Length; i++)
        {
            RaycastHit hit = hits[i];
            Rigidbody rb = hit.transform.GetComponent<Rigidbody>();

            if (rb == null)
            {
                line.SetPosition(1, hit.point);
            }
            //else line.SetPosition(1, MouseCast.toTarget * 5000);

            yield return new WaitForSeconds(1);
            Destroy(this.gameObject);
        }
    }


}
