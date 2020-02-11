using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class LevelManager : MonoBehaviour
{

    public GameObject Skill;     //隨機技能物件
    public GameObject objLight;  //光照物件


    [Header("是否自動顯示隨機技能")]
    public bool autoShowSkill;
    [Header("是否自動開門")]
    public bool autoOpenDoor;
    [Header("復活畫面,復活按鈕")]
    public GameObject PanelRevival;
    public Button btnRevival;

    private Animator aniDoor;     //開門動畫
    private Image imgCross;       //轉場
    private AdManager AdManager;  //廣告管理器


    private void Start()
    {
        //GameObject.Find  無法找到隱藏物件
        aniDoor = GameObject.Find("門").GetComponent<Animator>();
        imgCross = GameObject.Find("轉場效果").GetComponent<Image>();
        //如果 是 顯示技能 呼叫 顯示技能方法
        if (autoShowSkill) ShowSkill();
        //如果 是 自動開門 延時呼叫 自動方法
        if (autoOpenDoor) Invoke("OpenDoor", 3);
        if (autoOpenDoor) Invoke("TurnOntheLight", 4);
        //延遲調用("方法名稱",延遲時間)
        //Invoke("OpenDoor", 6);

        //重複調用("方法名稱",延遲時間,重複頻率)
        //InvokeRepeating("OpenDoor", 0, 1.5f);

        AdManager = FindObjectOfType<AdManager>();               //以物件類型搜尋目標物件
        btnRevival.onClick.AddListener(AdManager.ShowADRevival);   //復活按鈕.點擊.增加監聽者
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

    public IEnumerator NextLevel()
    {
        print("載入下一關");
        

        for (int k=0;k<50;k++)
        {
            imgCross.color += new Color(0, 0, 0, 0.02f);
            yield return new WaitForSeconds(0.01f);     //等待()秒動作
        }

        SceneManager.LoadScene("關卡 2");
        yield return new WaitForSeconds(0.5f);     //等待()秒動作


    }

    public IEnumerator ShowRevival()
    {
        PanelRevival.SetActive(true);
        Text TextSec = PanelRevival.transform.GetChild(1).GetComponent<Text>();

        for (int i = 3; i >=0; i--)
        {
            TextSec.text = i.ToString();
            yield return new WaitForSeconds(1);
        }

    }

    public void HideRevival()
    {
        PanelRevival.SetActive(false);
        StopCoroutine(ShowRevival());
    }




}
