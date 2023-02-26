using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField]
    private float moveSpeed;

    private bool fireInput;
    private bool hasFired;
    private bool isHooked;

    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        fireInput = Input.GetButtonDown("Fire1") && !hasFired;
        Fire();
    }
    private void FixedUpdate()
    {
    }
    void Fire()
    {
        if(fireInput)
        {
          //  rb.AddForce(Vector2.up * moveSpeed * Time.deltaTime, ForceMode2D.Impulse);
            rb.velocity = Vector2.up * moveSpeed * Time.deltaTime;
            hasFired = true;
            fireInput = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Arrow"))
        {
            if (other.GetComponent<Arrow>().isHooked && !isHooked)
            {
                gameManager.canSpawnArrow = true;
                Destroy(gameObject);
            }
        }
        else if (other.CompareTag("Target"))
        {
            rb.bodyType = RigidbodyType2D.Kinematic;
            Debug.Log("Has hit target!");
            rb.velocity = Vector2.zero;
            transform.parent = other.transform;
            gameManager.canSpawnArrow = true;
            isHooked = true;
        }
    }
}
