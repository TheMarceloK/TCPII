using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody rigidbody;
    private Vector3 movement;
    [SerializeField]
    private float speed = 5f;

    public int Bullets = 6;

    [SerializeField]
    private GameObject bullet;
    [SerializeField]
    private GameObject bulletSpawnPlace;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        float eixoX = Input.GetAxis("Horizontal");
        float eixoZ = Input.GetAxis("Vertical");

        movement = transform.TransformVector(new Vector3(eixoX, 0, eixoZ));

        if(Bullets > 0)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Instantiate(bullet, bulletSpawnPlace.transform.position, bulletSpawnPlace.transform.rotation);
                Bullets--;
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Bullets = 6;
        }
    }

    private void FixedUpdate()
    {
        rigidbody.MovePosition(rigidbody.position + (movement * speed * Time.fixedDeltaTime));
    }
}
