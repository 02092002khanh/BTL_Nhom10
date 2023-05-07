using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemyBig : MonoBehaviour
{
    public GameObject _enemyPrefab;
    float _rand;
    Vector3 _offset;
    public float _cooldown;
    bool _spawn = true;

    // Update is called once per frame
    [System.Obsolete]
    void Update()
    {

        if (_spawn)
        {
            _rand = Random.Range(-7,7);
            _offset = new Vector3(_rand, 0, 0);
            Instantiate(_enemyPrefab, transform.position + _offset, transform.rotation);
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
