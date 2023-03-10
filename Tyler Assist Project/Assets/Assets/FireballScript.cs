using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballScript : MonoBehaviour
{
    //public GameObject explosion;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(transform.forward*Time.deltaTime*10);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(1);
        //Instantiate(explosion);
        Collider[] colliders = Physics.OverlapSphere(transform.position, 5);
        foreach (Collider localCollider in colliders)
        {
            Rigidbody localRigid = localCollider.GetComponent<Rigidbody>();
            
            if (localRigid!=null)
            {
                if (localRigid.gameObject.tag!="Weapon")
                localRigid.AddExplosionForce(1000, transform.position, 5);
            }
        }
        Destroy(gameObject);
    }
}
