using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour {
    [SerializeField] GameObject CoinPrefab, ObstaclePrefab;
    [SerializeField] float minSpawnTime = 1f;
    [SerializeField] float maxSpawnTime = 2f;

    PlayerController _playerController;
    GameManager _gameManager;

    void Start() {
        _playerController = FindObjectOfType<PlayerController>().GetComponent<PlayerController>();
        _gameManager = FindObjectOfType<GameManager>().GetComponent<GameManager>();
    }
    public void StartSpawn() {
        StartCoroutine(SpawnCoinCoroutine());
        StartCoroutine(SpawnObstacleCoroutine());
    }
    public void StopSpawn() {
        StopAllCoroutines();
    }
    public void IncreaseObstaclesSpawn() {
        StartCoroutine(SpawnObstacleCoroutine());
    }
    IEnumerator SpawnCoinCoroutine() {
        while (_gameManager.GameOn) {
            Instantiate(CoinPrefab, GenerateSpawnPosition(), Quaternion.identity);

            float randomCoinDelay = Random.Range(minSpawnTime, maxSpawnTime) * 1.5f;
            yield return new WaitForSeconds(randomCoinDelay);
        }
    }
    IEnumerator SpawnObstacleCoroutine() {
        while (_gameManager.GameOn) {
            Instantiate(ObstaclePrefab, GenerateSpawnPosition(), Quaternion.identity);

            float randomObstacleDelay = Random.Range(minSpawnTime, maxSpawnTime);
            yield return new WaitForSeconds(randomObstacleDelay);
        }
    }

    Vector2 GenerateSpawnPosition() {
        float randomYPosition = Random.Range(-2f, 2f);
        float randomXPosition = _playerController.transform.position.x + Random.Range(15f, 18f);
        return new Vector2(randomXPosition, randomYPosition);
    }

}
