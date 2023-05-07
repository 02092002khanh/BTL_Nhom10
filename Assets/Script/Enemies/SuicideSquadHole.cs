using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuicideSquadHole : MonoBehaviour
{
    [SerializeField] Transform[] ships;
    [SerializeField] bool gapEnable;
    // Start is called before the first frame update
    void Start()
    {
        if(gapEnable)
        {
            for(int i = 0; i< transform.childCount; i++)
            {
                ships[i] = transform.GetChild(i);
            }
            int index = Random.Range(0,transform.childCount-1);
            Debug.Log(index);
            Destroy(ships[index].gameObject);
        }
    }

    
}
