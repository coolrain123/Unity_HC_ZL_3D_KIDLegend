using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LearnLoop : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //不使用迴圈
        print("嗨 , 1");
        print("嗨 , 2");
        print("嗨 , 3");
        print("嗨 , 4");



        //使用迴圈
        int num = 0;

        while (num < 50) 
        {
            num++;
           // print("哈囉 while迴圈 :" + num);
        }

        for (int k=0; k < 10; k++)
        {
           // print("哈囉 for迴圈 :" + k);
        }

        for (int a = 1; a < 10; a++)
        {
            for (int b = 1; b < 10; b++)
            {
                print(a * b);
            }
        }


    }

    
}
