using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
//using Ensign.Unity;

public class Health : MonoBehaviour
{
    [SerializeField] GameObject _endScreen;
    public int maxHealth;
    public int currentHealth;
    BountyHolder _boutyHolder;
    [SerializeField] GameObject dmgTextPF;
    [SerializeField] bool popUpsEnable;
    private TMP_Text damage;
    private Vector3 offset;
    private float _timeDelayAdMob = 1f;
    public Animator _anim;

    [SerializeField] GameObject _deadAnimation;
    // Start is called before the first frame update
    void Start()
    {
       
        _boutyHolder = gameObject.GetComponent<BountyHolder>();
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    public void HealthChanging(int value)
    {
        currentHealth = currentHealth + value;

        //pop up value
        if (popUpsEnable)
        {
            offset = new Vector3(Random.Range(-0.5f, 0.5f), Random.Range(-0.5f, 0.5f), 0);
            GameObject dmgText = Instantiate(dmgTextPF, transform.position + offset, Quaternion.identity);
            damage = dmgText.GetComponent<TMP_Text>();
            damage.text = value.ToString();
            Destroy(dmgText, 0.5f);
        }


    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            Die();
        }

        //_anim.SetFloat("Speed", 1.0f);
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        if (currentHealth == 0)
        {
            if (gameObject.CompareTag("Player"))
            {
                Instantiate(_deadAnimation,transform.position,transform.rotation);
                gameObject.SetActive(false);
                Invoke("Die",2.0f);
                Invoke("Ads",5.0f);
                
                
            }
            else
            {

            //_anim.SetBool("ZomNormalDie", true);
            if(_boutyHolder != null)
            {
                _boutyHolder.Drop();  
            } 
                Destroy(gameObject);
                
            } 
        }
    }

    private void Die()
    {
        if(_endScreen)
        {
            Debug.LogWarning(_endScreen.name);
            _endScreen.SetActive(true);
        }
        //Invoke("Ads", 1.0f);
    }
    //private void Ads()
    //{
    //    if(!InGameData.Instance.IsShowAds)
    //    {
    //        GoogleAdsMod.Instance.ShowRewardedVideo();
    //    }
    //}
    public void Holder()
    {
        
                
    }
}
