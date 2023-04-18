using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlBulletEnemy : MonoBehaviour
{
    public float Velocidade = 20;
    private Rigidbody rigidbodyBala;
    public AudioClip SomDeKill;
    private int DanoDeTiro = 1;
    Player player;

    private void Start()
    {
        rigidbodyBala = GetComponent<Rigidbody>();
        player = GameObject.FindObjectOfType<Player>();
    }
    void FixedUpdate()
    {
        rigidbodyBala.MovePosition(rigidbodyBala.position +
            (transform.forward * Velocidade * Time.deltaTime));
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            player.TakeDamage(10);
        }
    }
}
