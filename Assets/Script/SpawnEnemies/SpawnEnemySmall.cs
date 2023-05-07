using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemySmall : MonoBehaviour
{
    public GameObject[] _spawnPoint;
    public GameObject _enemyPrefab;
    int _rand;
    public float _cooldown;
    bool _spawn = true;
    // Start is called before the first frame update
    void Start()
    {
        int i = 0;
        foreach (Transform child in transform)
        {
            _spawnPoint[i] = child.gameObject;
            i++;
        }
    }
    // Update is called once per frame
    void Update()
    {

        if (_spawn)
        {
            _rand = Random.Range(0, 3);
            Instantiate(_enemyPrefab, _spawnPoint[_rand].transform.position, Quaternion.identity);
            _spawn = false;
            StartCoroutine(delaySpawn());
        }


    }
    private IEnumerator delaySpawn()
    {
        yield return new WaitForSeconds(_cooldown);
        _spawn = true;
    }
}
