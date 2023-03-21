using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody rigidbody;
    private Vector3 movement;
    [SerializeField]
    private float speed = 5f;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        float eixoX = Input.GetAxis("Horizontal");
        float eixoZ = Input.GetAxis("Vertical");

        movement = transform.TransformVector(new Vector3(eixoX, 0, eixoZ));
    }

    private void FixedUpdate()
    {
        rigidbody.MovePosition(rigidbody.position + (movement * speed * Time.fixedDeltaTime));
    }
}
