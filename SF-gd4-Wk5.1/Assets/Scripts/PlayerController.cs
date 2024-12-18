using UnityEngine;
using System.Collections;



public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    public float speed = 5.0f;
    private Transform focalPoint;

    public bool hasPowerup;
    private float powerupStrength = 15.0f;
    public GameObject ReflectIndicator;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRb= GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("FocalPoint").transform;

    }

    // Update is called once per frame
    void Update()
    {
        
        //float forwardInput = Input.GetAxis("Vertical");
        //playerRb.AddForce(focalPoint.transform.forward * speed * forwardInput);

        float verticalInput = Input.GetAxisRaw("Vertical");
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        Vector2 moveDirection = new Vector2(horizontalInput, verticalInput).normalized;

        playerRb.AddForce((focalPoint.forward * moveDirection.y + focalPoint.right * moveDirection.x) * speed);

        //Powerup indicator
        ReflectIndicator.transform.position = transform.position + new Vector3(0,0,0);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUpReflect"))
        {
            hasPowerup = true;
            Destroy(other.gameObject);
            StartCoroutine(PowerupCountdownRoutine());

            //powerup indicator
           ReflectIndicator.gameObject.SetActive(true);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerup)
        { 
          Rigidbody enemyRigidbidy = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position).normalized;

            Debug.Log("Player collided with" + collision.gameObject.name + "with powerup set to" + hasPowerup);

            enemyRigidbidy.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse);
        
        }
    }

    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(5);
        hasPowerup = false;

        //powerup indicator
        ReflectIndicator.gameObject.SetActive(false);

    }


}