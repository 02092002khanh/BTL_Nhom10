using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BountyHolder : MonoBehaviour
{
    [System.Serializable] struct Bounty
    {
        public GameObject bountyPF;
        public int dropRate;
    }
    [SerializeField] Bounty[] Drops;
    [SerializeField] int score;
    // Start is called before the first frame update
    GameController controller;
    private void Start() 
    {
        controller = GameObject.FindGameObjectWithTag("Controller").GetComponent<GameController>();
    }
    public  void Drop()
    {
        controller.score += score;
        Debug.Log("score" + controller.score.ToString());
        foreach (Bounty items in Drops)
        {
            int result = Random.Range(0, 100);
            if (result <= items.dropRate)
            {
                GameObject.Instantiate(items.bountyPF, gameObject.transform.position, Quaternion.identity);
            }
            
        }
    }
}
