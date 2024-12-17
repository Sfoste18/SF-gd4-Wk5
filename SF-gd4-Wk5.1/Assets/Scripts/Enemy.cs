using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody enemyRb;
        public float speed;
    private GameObject player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
        
    }

    // Update is called once per frame
    void Update()
    {
       Vector3 lookDirection = (player.transform.position - transform.position).normalized;

        enemyRb.AddForce(lookDirection * speed);
        enemyRb.AddForce((player.transform.position - transform.position).normalized * speed);

    }
}
