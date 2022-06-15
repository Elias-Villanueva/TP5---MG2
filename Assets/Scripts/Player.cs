using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int Health;

    private bool hit = true;

    public float moveSpeed;

    public Rigidbody2D rb;
    public Camera cam;

    public GameManager gameManager;

    Vector2 movement;
    Vector2 mousePos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -29.4f, 29.4f), Mathf.Clamp(transform.position.y, -19.4f, 19.4f), transform.position.z);
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.deltaTime);
        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
        
    }

    IEnumerator hitBoxOff()
    {
        hit = false;
        yield return new WaitForSeconds(1.5f);
        hit = true;
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Enemy")
        {
            if(hit)
            {
                StartCoroutine(hitBoxOff());
                Health--;
                Destroy(GameObject.Find("life-box").transform.GetChild(0).gameObject);
                AudioManager.instance.PlaySFX(9);

                if(Health < 1)
                {
                    AudioManager.instance.PlaySFX(8);
                    gameManager.GameOver();
                }
            }
        }
    }
}
