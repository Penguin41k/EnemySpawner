using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private float _spawnTimeInterval;
    [SerializeField] private Transform _spawnPoints;
    [SerializeField] private Enemy[] _enemies;

    private Transform[] _creationPoints;

    private void Start()
    {
        _creationPoints = new Transform[_spawnPoints.childCount];

        for (int i =0; i< _creationPoints.Count() ; i++) 
        {
            _creationPoints[i]= _spawnPoints.GetChild(i).transform;
        }

        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        var timer = new WaitForSeconds(_spawnTimeInterval);

        for (int i = 0; i < _creationPoints.Count(); i++)
        {
            int numberOfEnemy = Random.Range(0,_enemies.Length);

            Instantiate(_enemies[numberOfEnemy], _creationPoints[i].transform.position, Quaternion.identity);
            yield return timer;
        }
    }
}
