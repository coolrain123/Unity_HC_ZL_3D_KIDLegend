
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace coolrain {
    public class RandomSkill : MonoBehaviour
    {
        [Header("技能圖片:模糊與正常")]
        public Sprite[] spriteBlurs; //模糊圖片陣列
        public Sprite[] spriteSkill; //技能圖片陣列

        [Header("捲動速度"), Range(0.00001f, 3f)]
        public float speed = 0.1f;
        [Header("捲動次數"), Range(1, 10)]
        public int count = 5;
        [Header("音效")]
        public AudioClip soundScroll;
        public AudioClip soundGetSkill;

        private Image img;             //圖片元件
        private Button btn;            //按鈕元件
        private AudioSource aud;       //音源元件
        private Text textSkill;        //技能名稱
        private GameObject panelSkilll;//隨機技能物件
        private string[] nameSkill = { "連續射擊", "正向箭", "背向箭", "側向箭", "血量提升", "攻擊提升", "攻速提升", "爆擊提升" };


    private void Start()
        {
            img = GetComponent<Image>();
            btn = GetComponent<Button>();
            aud = GetComponent<AudioSource>();
            StartCoroutine(ScrollEffect());   //啟動協程
            textSkill = transform.GetChild(0).GetComponent<Text>(); //抓取子物件編號(0)的元件<text>
            panelSkilll = GameObject.Find("隨機技能");

            btn.onClick.AddListener(ChooseSkill);  //設定按鈕點選.監聽者.
        }

        private void ChooseSkill()
        {
            panelSkilll.SetActive(false);
        }


        private IEnumerator ScrollEffect()  //定義協程方法  :滾動效果
        {
            btn.interactable = false;      //按鍵無法選取

            //迴圈
            for (int i = 0; i < count; i++)
            {
                for (int j = 0; j < spriteBlurs.Length; j++) //滾動換圖 模糊圖片陣列
                {
                    img.sprite = spriteBlurs[j];
                    aud.PlayOneShot(soundScroll, 0.2f);
                    yield return new WaitForSeconds(speed);
                }
            }

            int r = Random.Range(0, spriteSkill.Length);    //指定出隨機技能  技能圖片陣列
            img.sprite = spriteSkill[r];
            aud.PlayOneShot(soundGetSkill, 1f);
            textSkill.text = nameSkill[r];   //指定技能名稱為 nameskill陣列之r值
            btn.interactable = true;    //按鍵回覆可選
        }
       
    }
}

