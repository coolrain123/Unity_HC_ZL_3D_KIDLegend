using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    public GameObject Skill;     //隨機技能物件
    public GameObject objLight;  //光照物件


    [Header("是否自動顯示隨機技能")]
    public bool autoShowSkill;
    [Header("是否自動開門")]
    public bool autoOpenDoor;

    private Animator aniDoor;     //開門動畫

    private void Start()
    {
        //GameObject.Find  無法找到隱藏物件
        aniDoor = GameObject.Find("門").GetComponent<Animator>();
       
        //如果 是 顯示技能 呼叫 顯示技能方法
        if (autoShowSkill) ShowSkill();
        //如果 是 自動開門 延時呼叫 自動方法
        if (autoOpenDoor) Invoke("OpenDoor", 3);
        if (autoOpenDoor) Invoke("TurnOntheLight", 4);
        //延遲調用("方法名稱",延遲時間)
        //Invoke("OpenDoor", 6);

        //重複調用("方法名稱",延遲時間,重複頻率)
        //InvokeRepeating("OpenDoor", 0, 1.5f);
    }
    /// <summary>
    /// 顯示技能
    /// </summary>
    private void ShowSkill()
    {
        Skill.SetActive(true);
    }
    /// <summary>
    /// 開門、光照
    /// </summary>
    private void OpenDoor()
    {
        aniDoor.SetTrigger("開門觸發");              
    }
    private void TurnOntheLight()
    {
        objLight.SetActive(true);
    }


}
