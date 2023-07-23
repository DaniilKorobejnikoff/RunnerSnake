using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class PlayerController : MonoBehaviour {
    [SerializeField] float _force = 10f;

    Rigidbody2D _rigidbody;
    GameManager _gameManager;
    ParticleSystem _tailParticle;

    void Start() {
        _rigidbody = GetComponent<Rigidbody2D>();
        _gameManager = FindObjectOfType<GameManager>();
        _tailParticle = gameObject.GetComponentInChildren<ParticleSystem>();
    }
    void Update() {
        if (Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0) || Input.GetMouseButton(1)) {
            _rigidbody.AddForce(Vector2.up * _force);
        }

        if (!_gameManager.GameOn && (Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0) || Input.GetMouseButton(1))) {
            _gameManager.StartGame();
            _rigidbody.isKinematic = false;
            _tailParticle.Play();
        }
    }
    void Reset() {
        _rigidbody.isKinematic = true;
        _rigidbody.velocity = Vector2.zero;
        transform.position = Vector3.zero;
    }

    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Obstacle")) {
            _gameManager.GameOver();
            _tailParticle.Stop();
            Reset();
        }


        if (collision.gameObject.GetComponentInParent<Coin>()) {
            Destroy(collision.gameObject);
            _gameManager.UpdateScore(1);
        }

    }
}