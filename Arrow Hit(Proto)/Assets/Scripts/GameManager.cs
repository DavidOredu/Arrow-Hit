using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject arrowPrefab;
    [SerializeField]
    private Transform arrowSpawnPoint;
    [SerializeField]
    private TextMeshProUGUI scoreText;

    public int scoreCount;

    public bool canSpawnArrow;
    // Start is called before the first frame update
    void Start()
    {
        SpawnArrow();
    }

    // Update is called once per frame
    void Update()
    {
        if (canSpawnArrow)
            SpawnArrow();

        scoreText.text = scoreCount.ToString();
    }
    private void SpawnArrow()
    {
        Instantiate(arrowPrefab, arrowSpawnPoint.position, Quaternion.identity);
        canSpawnArrow = false;
    }
}
