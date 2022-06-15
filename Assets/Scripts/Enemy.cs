using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float healthEnemy;

    public GameObject healthBar;

    private Transform playerPos;
    public float moveSpeed;
    private Rigidbody2D rb;
    private Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        buscarPlayer();
        recibirDaño();
        
    }

    void recibirDaño()
    {
        if(healthEnemy < 1)
        {
            Destroy(gameObject);
            AudioManager.instance.PlaySFX(3);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Bullet")
        {
            healthEnemy--;
            AudioManager.instance.PlaySFX(0);
            Destroy(other.gameObject);

            healthBar.transform.localScale = new Vector3(healthEnemy / 100, healthBar.transform.localScale.y, healthBar.transform.localScale.z);
        }
    }

    void buscarPlayer()
    {
        Vector3 direction = playerPos.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
        direction.Normalize();
        movement = direction;
    }

    private void FixedUpdate()
    {
        moveCharacter(movement);
    }

    void moveCharacter(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }
}
