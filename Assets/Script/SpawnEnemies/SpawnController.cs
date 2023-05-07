
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    [SerializeField] int stageDuration,currentGameStage;
    [SerializeField]private float actualGameTime;
    public Spawner[] spawners;
    [SerializeField] float spawnRate;
    [SerializeField] bool ready = true;
    // Start is called before the first frame update
    void Awake()
    {
        int i = 0;
        foreach (Transform child in transform)
        {
            spawners[i] = child.gameObject.GetComponent<Spawner>();
            i++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        actualGameTime += Time.deltaTime;
        if(actualGameTime > stageDuration)
        {
            Debug.Log("new stage, new wave");
            currentGameStage ++;
            // stageDuration += 2;
            // stageDuration = Mathf.Clamp(stageDuration, 10,20);
            spawners[0].AttackWave(currentGameStage);
            actualGameTime = 0;
        }
        //spawn enemies
        if(ready)
        {               
            if(currentGameStage < 7)
            {
                spawners[0].CasualSpawn(currentGameStage);                
                ready = false;
                StartCoroutine(DelaySpawn());
            }
            else 
            {
                int index = Random.Range(0,14);
                index = Mathf.Clamp(index - 10,0,4);   
                spawners[index].CasualSpawn(currentGameStage);
                ready = false;
                StartCoroutine(DelaySpawn());
            }
        }
        
    }
    IEnumerator DelaySpawn()
    {
        yield return new WaitForSeconds(1/(spawnRate + currentGameStage * 0.3f));
        ready = true;
    }

}
