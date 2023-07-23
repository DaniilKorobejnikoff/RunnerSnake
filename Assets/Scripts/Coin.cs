using UnityEngine;

public class Coin : MonoBehaviour {
    [SerializeField] float _speedFollowPlayer, _rangeOfFollow;

    Transform _player;

    void Start() {
        _player = FindObjectOfType<PlayerController>().GetComponent<Transform>();
    }
    void LateUpdate() {
        if (Vector2.Distance(transform.position, _player.position) < _rangeOfFollow) {
            Vector2 toPlayer = (_player.position - transform.position).normalized;
            transform.Translate(toPlayer * Time.deltaTime * _speedFollowPlayer);
        }
    }
}
