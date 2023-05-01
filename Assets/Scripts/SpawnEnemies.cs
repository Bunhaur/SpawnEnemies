using System.Collections;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    [SerializeField] private Object _enemiePrefab;
    [SerializeField] private Transform _spawnPoints;

    private float _spawnTime;
    private int _current;

    private Transform[] _points;
    private IEnumerator _spawner;

    private void Start()
    {
        _points = new Transform[_spawnPoints.childCount];
        _spawnTime = 2.0f;

        for (int i = 0; i < _spawnPoints.childCount; i++)
        {
            _points[i] = _spawnPoints.GetChild(i).transform;
        }

        _spawner = Spawn();
        StartCoroutine(_spawner);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            StopCoroutine(_spawner);
        }
    }

    IEnumerator Spawn()
    {
        while (true)
        {
            Instantiate(_enemiePrefab, _points[_current].position, Quaternion.identity);
            
            _current++;

            if (_current == _spawnPoints.childCount)
            {
                _current = 0;
            }

            yield return new WaitForSeconds(_spawnTime);
        }
    }
}