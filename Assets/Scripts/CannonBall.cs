using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall : MonoBehaviour
{
    public float force = 20f;
    public float radius = 3f;
    public GameObject effect;
    void Start()
    {
        StartCoroutine(CanonBall());
    }



    private IEnumerator CanonBall()
    {
        Rigidbody rb = gameObject.GetComponent<Rigidbody>();
        rb.AddRelativeForce(MouseCast.toTarget, ForceMode.Impulse);
        yield return new WaitForSeconds(2);
        Instantiate(effect, transform.position, Quaternion.identity);
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        foreach (Collider collider in colliders)
        {
            Rigidbody rb2 = collider.GetComponent<Rigidbody>();
            if (rb2)
            {
                rb2.AddExplosionForce(force, transform.position, radius, 3, ForceMode.Impulse);
            }
        }
        Destroy(this.gameObject);

    }
}
