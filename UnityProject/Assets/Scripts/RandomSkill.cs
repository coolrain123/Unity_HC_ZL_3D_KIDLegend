
using UnityEngine;
using UnityEngine.UI;

namespace coolrain {
    public class RandomSkill : MonoBehaviour
    {
        [Header("技能圖片:模糊與正常")]

        public Sprite[] spriteBlurs; //模糊圖片陣列
        public Sprite[] spriteSkill; //技能圖片陣列

        private Image img;          //圖片元件
        private Button btn;         //按鈕元件


        private void Start()
        {
            img = GetComponent<Image>();
            btn = GetComponent<Button>();
            //啟動協程
        }
        


        //定義協程方法
        //按鍵無法選取
    }
}

