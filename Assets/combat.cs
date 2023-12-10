using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class combat : MonoBehaviour
{
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public int attckDamage = 1;
    
    public static int playerHealth = 4;
    public static int playerMaxHealth = 4;
    private int lastHealth = 4;

    public Image hp1;
    public Image hp2;
    public Image hp3;
    public Image hp4;
    public List <Image> imageList = new List<Image>();


    public AudioSource AudioSource;
    void Start(){
        AudioSource = GetComponent<AudioSource>();

        //imageList = new List<Image>();
        hp1 = GameObject.Find("Canvas").transform.GetChild(13).gameObject.GetComponent<Image>();
        hp2 = GameObject.Find("Canvas").transform.GetChild(14).gameObject.GetComponent<Image>();
        hp3 = GameObject.Find("Canvas").transform.GetChild(15).gameObject.GetComponent<Image>();
        hp4 = GameObject.Find("Canvas").transform.GetChild(16).gameObject.GetComponent<Image>();
        //var tempColor = hp1.color;
        //tempColor.a = 0f;
        //hp1.color = tempColor;
        //imageList.add(hp1);
       // imageList.add(hp2);
       // imageList.add(hp3);
        //imageList.add(hp4);
        
        //GameObject a = GameObject.Find("Canvas");
        //Image v = a.transform.GetChild(7).gameObject.GetComponent<Image>();
        //var tempColor = hp1.color; 
        //tempColor.a = 0f;
        //hp1.color = tempColor;
            

       
    }

    // Update is called once per frame
    void Update()
    {
  
        if (lastHealth != playerHealth){
            AudioSource a = GameObject.FindGameObjectWithTag("sound").transform.GetChild(1).gameObject.GetComponent<AudioSource>();
            a.Play();
            var tempColor = hp1.color; 
            var tempColor1 = hp1.color;
            tempColor.a = 1f;
            tempColor1.a = 0f;
            if (playerHealth == 0){
                SceneManager.LoadScene("Title Screen");
                playerHealth = 4;
                hp1.color = tempColor1;
                hp2.color = tempColor1;
                hp3.color = tempColor1;
                hp4.color = tempColor1;

            }else if(playerHealth == 1){
                hp1.color = tempColor;
                hp2.color = tempColor1;
                hp3.color = tempColor1;
                hp4.color = tempColor1;

            }else if(playerHealth == 2){
                 hp1.color = tempColor;
                hp2.color = tempColor;
                hp3.color = tempColor1;
                hp4.color = tempColor1;

            }else if(playerHealth == 3){
                 hp1.color = tempColor;
                hp2.color = tempColor;
                hp3.color = tempColor;
                hp4.color = tempColor1;

            }else if(playerHealth == 4){
                 hp1.color = tempColor;
                hp2.color = tempColor;
                hp3.color = tempColor;
                hp4.color = tempColor;
            } 

            lastHealth = playerHealth;

            //for(var i = 0; i < playerHealth; i++){

           //         imageList[i].color = tempColor;
           // }
            //for(var i = playerHealth; i < playerMaxHealth; i++){

             //       imageList[i].color = tempColor;
           // }
       }



        if (Input.GetKeyDown(KeyCode.F)){
            Debug.Log("f");
            AudioSource.Play();
            transform.GetComponent<Animator>().SetTrigger("attak");

            Attack();
        }
    }


    void Attack(){

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach(Collider2D enemy in hitEnemies){
            Debug.Log("hit"+enemy.name);
            enemy.GetComponent<enemy>().TakeDamage(attckDamage);


        }
    }

    void onDrawGizmosSelected()
    {
        if( attackPoint == null){
            Debug.Log("null");
            return;
        }
        Debug.Log("1");
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

  }  


