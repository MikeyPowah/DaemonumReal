using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EspadaController : MonoBehaviour
{
    public Transform cam;
    public Transform attackPoint;
    public GameObject objectToThrow;

    public int totalThrows;
    public float throwCooldown;

    public KeyCode throwKey = KeyCode.Space;
    public float throwForce;
    public float throwUpwardForce;

    bool readyToThrow;
    bool readyToGet;
    
    // Start is called before the first frame update
    void Start()
    {
        readyToThrow = true;
        readyToGet = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(throwKey) && readyToThrow && totalThrows > 0){
            Throw();
        }
    }
    private void Throw()
    {
        readyToThrow = false;
        GameObject projectile = objectToThrow;
        // objectToThrow.GetComponent<Espadote>().animator.SetBool("Ataque", true); Attacking = true;
        Rigidbody projectileRb = projectile.GetComponent<Rigidbody>();

        Vector3 forceDirection = cam.transform.forward;

        RaycastHit hit;

        if(Physics.Raycast(cam.position, cam.forward, out hit, 500f))
        {
            forceDirection = (hit.point - attackPoint.position).normalized;
        }
        Debug.Log(hit);
        Debug.Log(forceDirection);
        Vector3 forceToAdd = forceDirection * throwForce + transform.up * throwUpwardForce;
        Debug.Log(forceToAdd);
        Debug.Log(ForceMode.Impulse);
        projectileRb.AddForce(forceToAdd, ForceMode.Impulse);

        totalThrows--;

        Invoke(nameof(ResetThrow), throwCooldown);
    }

    private void GetableThrow()
    {
        readyToGet = true;
    }

    private void ResetThrow()
    {
        readyToThrow = true;
    }
}
