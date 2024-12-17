using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody playerRb;
    public float moveSpeed = 5.0f;
    private GameObject focalPoint;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerRb= GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("FocalPoint");

    }

    // Update is called once per frame
    void Update()
    {
        
        float forwardInput = Input.GetAxis("Vertical");
        playerRb.AddForce(focalPoint.transform.forward * moveSpeed * forwardInput);

        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");
        //Vector2 moverDir = new Vector2(horizontalInput, verticalInput).normalised;

        //rb.AddForce((focalPoint.forward * moverDir.y + focalPoint.right * moverDir.x) * moveSpeed);

        //focalPoint.position = transform.position;

    }
}
