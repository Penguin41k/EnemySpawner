using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float _spawnTimeInterval;
    [SerializeField] private Transform _spawnPoints;
    [SerializeField] private GameObject[] _enemy;

    private Transform[] _points;

    void Start()
    {
        _points = new Transform[_spawnPoints.childCount];

        for (int i =0; i< _points.Count() ; i++) 
        {
            _points[i]= _spawnPoints.GetChild(i).transform;
        }

        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        var timer = new WaitForSeconds(_spawnTimeInterval);

        for (int i = 0; i < _points.Count(); i++)
        {
            int numberOfEnemy = Random.Range(0,_enemy.Length);

            Instantiate(_enemy[numberOfEnemy], _points[i].transform.position, Quaternion.identity);
            yield return timer;
        }
    }
}
