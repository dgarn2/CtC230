using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class enemy : MonoBehaviour
{

    public int maxHealth = 4;
    int curHealth;
    public GameObject a;
public GameObject b;
    public AudioSource AudioSource;



     [SerializeField]
    private TextMeshProUGUI firstMinute;

    [SerializeField]
    private TextMeshProUGUI secondMin;
  
    [SerializeField]
    private TextMeshProUGUI firstSec;
    [SerializeField]
    private TextMeshProUGUI secondSec;


     [SerializeField]
    private TextMeshProUGUI keepfirstMinute;

    [SerializeField]
    private TextMeshProUGUI keepsecondMin;
  
    [SerializeField]
    private TextMeshProUGUI keepfirstSec;
    [SerializeField]
    private TextMeshProUGUI keepsecondSec;

    // Start is called before the first frame update
    void Start()
    {
        curHealth = maxHealth;
        AudioSource = GetComponent<AudioSource>();
        a = GameObject.FindGameObjectWithTag("Player");




    }

    public void TakeDamage(int Damage){
        curHealth -= Damage;
       
        if(curHealth<=0){
            Die();
        }
    }

    void Die(){
        Debug.Log("dd");
        a.GetComponent<CharacterController2D>().Respawn();
        BearObject.hasReceivedBuff = false;
        keepfirstMinute.text = firstMinute.text;
        keepfirstSec.text =  firstSec.text;
        keepsecondMin.text =  secondMin.text;
        keepsecondSec.text =  secondSec.text;
        
        GameObject.Find("Canvas").transform.GetChild(17).gameObject.GetComponent<Timer>().ResetTimer();
        curHealth=maxHealth;
        AudioSource.Play();
        //GameObject.Find("Canvas").transform.GetChild(11).gameObject.GetComponent<Timer>()
        
        //b.GetComponent<Timer>().Flash();
        //GameObject.Find("Canvas").transform.GetChild(11).gameObject.GetComponent<Timer>().Re();
        //b.GetComponent<Timer>().UpdateTimer(0);
        //audio

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
