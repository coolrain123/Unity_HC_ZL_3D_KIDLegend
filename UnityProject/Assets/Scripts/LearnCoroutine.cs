using UnityEngine;
using System.Collections;  //引用  系統.集合api

public class LearnCoroutine : MonoBehaviour
{
   
    public IEnumerator Test()
    {
        print("執行協程方法");

        for (int k = 0; k < 10; k++)
        {
            yield return new WaitForSeconds(k);  //等待2秒

            print("又過了" + k + "秒");
        }            

    }

    public Transform mouse;



    public IEnumerator Big()
    {
        for (int k = 0; k < 10; k++)
        {
            mouse.localScale += Vector3.one;
            yield return new WaitForSeconds(0.1f);
        }
       
    }



    void Start()
    {
        // StartCoroutine(Test());  //啟動編程
        StartCoroutine(Big());
    }

}
