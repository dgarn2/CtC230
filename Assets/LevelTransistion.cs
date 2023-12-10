using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTransistion : MonoBehaviour
{
    // Start is called before the first frame update


    public class DoorTransition : MonoBehaviour
    {
        // The name of the scene to load
        public string nextLevel = "BossFight";
        public GameObject a;


        private void OnTriggerEnter2D(Collider2D other)
        {
            // Check if the player has entered the trigger
            if (other.CompareTag("Player"))
            {
                Debug.Log("The player is in the door");
                // Load the next level
                //SceneManager.LoadScene(nextLevel);

                a = GameObject.FindGameObjectWithTag("Player");
                //a.transform.position = new Vector2(190f,355f);
            }
        }
    }
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
