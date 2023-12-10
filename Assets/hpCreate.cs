using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hpCreate : MonoBehaviour
{

    
    public Sprite heart0Sprite;
    [SerializeField] private Sprite heart2Sprite;
    [SerializeField] private Sprite heart3Sprite;
    [SerializeField] private Sprite heart4Sprite;
    
    private List<HeartImage> heartImageList;

    //public Image[] healthImage;
    //public Sprite[] healthSprite;



    private void Awake(){
        heartImageList = new List<HeartImage>();
    }

    // Start is called before the first frame update
    void Start()
    {
        CreateHP(new Vector2(0,0));
        CreateHP(new Vector2(20,0));
        CreateHP(new Vector2(40,0));
        int playHP = combat.playerHealth;
        int playMaxHP = combat.playerMaxHealth;


    }

    private HeartImage CreateHP(Vector2 anchoredPosition){
        GameObject heartGameObject = new GameObject("Heart", typeof(Image));

        heartGameObject.transform.parent = transform;
        heartGameObject.transform.localPosition = Vector3.zero;


        heartGameObject.GetComponent<RectTransform>().anchoredPosition = anchoredPosition;
        heartGameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(1,1);

        Image heartImageUI = heartGameObject.GetComponent<Image>();
        heartImageUI.sprite = heart0Sprite;

        HeartImage heartImage = new HeartImage(heartImageUI);
        heartImageList.Add(heartImage);

        return heartImage;


    }

    public class HeartImage {
        private Image heartImage;

        public HeartImage(Image heartImage){
            this.heartImage = heartImage;
        }
    }

    // Update is called once per frame
    void Update()
    {
     //   foreach(int i = 0; i < hp; i++){
    //        if (i < maxHp) {
        // draw a red heart
   // } else {
        // draw a golden heart
   // }
    }




  //  for (int = 0; i < maxHeart ; i++){

    //    if
   // }
}
