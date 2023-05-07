using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] Enemy ;
    public bool ordered;       
    public int enemyIndex;   
    
    public void CasualSpawn(int stage)
    {
        stage = Mathf.Clamp(stage,0, Enemy.Length);
        enemyIndex = Random.Range(0,stage);
        GameObject.Instantiate(Enemy[enemyIndex],transform.position + new Vector3(Random.Range(-3f,3f),Random.Range(-3f,0f),0) , Quaternion.identity);

    }

    public void AttackWave(int stage)
    {
        for(int i=0; i<stage; i++)
        {
            stage = Mathf.Clamp(stage,0, Enemy.Length);
            int enemyIndex = Random.Range(0,stage);
            GameObject.Instantiate(Enemy[enemyIndex],transform.position + new Vector3(Random.Range(-3f,3f),Random.Range(-3f,0f),0), Quaternion.identity);
        }
    }   
}
