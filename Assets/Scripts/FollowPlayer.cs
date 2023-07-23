using UnityEngine;

public class FollowPlayer : MonoBehaviour {
    Transform _player;

    void Start() {
        _player = FindObjectOfType<PlayerController>().GetComponent<Transform>();
    }
    void LateUpdate() {
        transform.position = new Vector3(_player.transform.position.x + 3.5f, transform.position.y, transform.position.z);
    }
}
