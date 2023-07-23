using UnityEngine;

public class Obstacle : MonoBehaviour {
    Vector3 _topTarget, _bottomTarget, _currentTarget;

    void Start() {
        SetLimits();
    }
    void Update() {
        transform.position = Vector3.Lerp(transform.position, _currentTarget, Time.deltaTime);

        if (Vector3.Distance(transform.position, _currentTarget) < 0.5f) {
            ChangeTarget();
        }
    }

    void ChangeTarget() {
        if (_currentTarget == _topTarget) {
            _currentTarget = _bottomTarget;
        }
        else _currentTarget = _topTarget;
    }
    void SetLimits() {
        _bottomTarget = new Vector2(transform.position.x, Random.Range(-4f, 1f));
        _topTarget = _bottomTarget + Vector3.up * 3;

        ChangeTarget();
    }
}
