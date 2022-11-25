using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EspadoteAtaque : MonoBehaviour {
    private Animator animator;
    private Vector3 offset = new Vector3(1f, 0f, 0f);
    private float smoothTime = 0.35f;
    private Vector3 velocity = Vector3.zero;

    [SerializeField] private Transform target;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Vector3 targetPosition = target.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        
        if (Input.GetKey(KeyCode.Space))
            {
                animator.SetBool("Ataque", true);
                StartCoroutine(ExampleCoroutine());
                animator.SetBool("Ataque", false);
            }
    }

    IEnumerator ExampleCoroutine()
    {
        yield return new WaitForSeconds(1);
    }
}