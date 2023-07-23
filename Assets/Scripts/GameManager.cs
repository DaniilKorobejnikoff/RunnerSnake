using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    public bool GameOn = false;

    [SerializeField] Text _startTips, _scoreText;

    Spawner _spawner;

    int _score = 0;

    public void StartGame() {
        GameOn = true;
        _startTips.gameObject.SetActive(false);
        _spawner.StartSpawn();
    }
    public void GameOver() {
        GameOn = false;
        _spawner.StopSpawn();
        UpdateScore(0);
        _startTips.gameObject.SetActive(true);

        foreach (var usedObstacle in FindObjectsOfType<Obstacle>()) {
            Destroy(usedObstacle.gameObject);
        }
        foreach (var usedCoin in FindObjectsOfType<Coin>()) {
            Destroy(usedCoin.gameObject);
        }
    }
    // Changes the score and increases obstacles to spawn
    public void UpdateScore(int scoreAmount) {
        if (scoreAmount == 0) {
            _score = 0;
        }
        else _score += scoreAmount;

        if (_score % 3 == 0) {
            _spawner.IncreaseObstaclesSpawn();
        }

        _scoreText.text = _score.ToString();
    }
    void Start() {
        _spawner = FindObjectOfType(typeof(Spawner)) as Spawner;
    }
}
