using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private GameManager gameManager;

    [SerializeField]
    private float rotationSpeed = 5f;
    [SerializeField]
    private float arrowCheckRadius = 5f;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Rotate();
        CheckArrows();
    }
    void Rotate()
    {
        transform.Rotate(Vector3.forward, rotationSpeed);
    }
    void CheckArrows()
    {
        var hits = Physics2D.OverlapCircleAll(transform.position, arrowCheckRadius, LayerMask.GetMask("Arrow"));
        gameManager.scoreCount = hits.Length;
        Debug.Log("Arrow Count: " + hits.Length);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, arrowCheckRadius);
    }
}
