using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSoldier : MonoBehaviour
{
    [SerializeField] GameObject _enemyPrefab;
    [SerializeField] float _cooldown, number;
    int remaint;
    bool _spawn = true;

    private void Start()
    {
        remaint = (int)number;
    }
    // Update is called once per frame
    [System.Obsolete]
    void Update()
    {

        if (_spawn)
        {
            remaint--;
            Instantiate(_enemyPrefab, transform.position, transform.rotation);
            _spawn = false;
            StartCoroutine(delaySpawn());
        }
        if(remaint == 0)
        {
            Destroy(gameObject);
        }

    }
    private IEnumerator delaySpawn()
    {
        yield return new WaitForSeconds(_cooldown);
        _spawn = true;
    }
}
