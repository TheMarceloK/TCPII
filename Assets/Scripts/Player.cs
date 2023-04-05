using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody rigidbody;
    private Vector3 movement;
    [SerializeField]
    private float walkspeed, runningspeed, crouchspeed, crouchYScale;
    private float startYScale;
    private float speed;

    [SerializeField]
    private List<GameObject> gun;

    public KeyCode runningkey = KeyCode.LeftShift;
    public KeyCode crouchkey = KeyCode.LeftControl;

    public int Bullets = 6;
    public int defaultBullets;
    public float currentLife = 50;

    [SerializeField]
    private GameObject textTrade;

    [SerializeField]
    private GameObject bullet;
    [SerializeField]
    private GameObject bulletSpawnPlace;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        startYScale= transform.localScale.y;
        defaultBullets = Bullets;
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
            Bullets = defaultBullets;
        }
        if (Input.GetKeyDown(crouchkey))
        {
            transform.localScale = new Vector3(transform.localScale.x, crouchYScale, transform.localScale.z);
            rigidbody.AddForce(Vector3.down*5f,ForceMode.Impulse);
        }
        if (Input.GetKeyUp(crouchkey))
        {
            transform.localScale = new Vector3(transform.localScale.x, startYScale, transform.localScale.z);
            rigidbody.AddForce(Vector3.down * 5f, ForceMode.Impulse);
        }
        StateHandler();
    }
    
    private void FixedUpdate()
    {
        rigidbody.MovePosition(rigidbody.position + (movement * speed * Time.fixedDeltaTime));
    }
    public MovementState state;
    public enum MovementState
    {
        walking,
        running,
        crounching
    }
    private void StateHandler()
    {
        if (Input.GetKey(runningkey))
        {
            state = MovementState.running;
            speed = runningspeed;
        }
        else { state = MovementState.walking;
            speed = walkspeed;
        }
        
        if (Input.GetKey(crouchkey))
        {
            state = MovementState.crounching;
            speed = crouchspeed;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        textTrade.SetActive(true);
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (other.gameObject.tag == "Heal")
            {
                currentLife += 50;
                Destroy(other.gameObject);
                textTrade.SetActive(false);
            }
            if (other.gameObject.tag == "Gun2")
            {
                Bullets = 30;
                defaultBullets = Bullets;
                Destroy(other.gameObject);
                textTrade.SetActive(false);
                //Trocar arma por aqui. 
                //tá escrito porcamente, tem que melhorar isso, mas está "funcionando"
                if (gun[0].active == true) { gun[0].SetActive(false); gun[1].SetActive(true); }
                else if (gun[1].active == true) { gun[1].SetActive(false); gun[0].SetActive(true); }
              


            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        textTrade.SetActive(false);
    }
}
/*control agacha e faz se mover mais devagar
 shift faz correr
 */
