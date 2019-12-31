using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LearnArray : MonoBehaviour
{

    //陣列:儲存相同的資料

    public string[] names;
    public int[] numbers;
    public Player[] players;


    public float[] damages = new float[5];
    public string[] props = new string[3] { ("紅水"), ("藍水"), ("黃水") };

    public Vector2[] position = { new Vector2(1, 2), new Vector2(3, 4) };





    private void Start()
    {
        //取得陣列值
        print("取得道具: "+props[1]);
        //存放陣列值
        damages[2] = 99.9f;

        //陣列長度(數量)
        print("地點數量有:" + position.Length);
    }
}
