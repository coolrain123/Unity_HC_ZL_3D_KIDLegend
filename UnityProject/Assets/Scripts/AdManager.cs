using UnityEngine;
using UnityEngine.Advertisements;   //引用廣告API

//繼承只能一個
//介面可有多個，類似裝備，啟用後獲得效果
//介面多為 I 開頭
//IUnityAdsListener :廣告監聽者，觀察玩家看廣告的狀態
public class AdManager : MonoBehaviour , IUnityAdsListener
{
    private string GoogleID = "3465971";    //Google Play 廣告ID
    private string placementRevival = "revival";
    private Player player;

    private void Start()
    {
        Advertisement.Initialize(GoogleID, false);  //廣告.初始化(廣告ID,)
        Advertisement.AddListener(this);           //增加監聽者（此腳本）
        player = FindObjectOfType<Player>();
    }


    /// <summary>
    /// 顯示復活廣告
    /// </summary>
    public void ShowADRevival()
    {
        if (Advertisement.IsReady(placementRevival))
        {
            Advertisement.Show(placementRevival);
        }
    }

    //廣告準備完成
    public void OnUnityAdsReady(string placementId)
    {
       
    }
    //廣告錯誤
    public void OnUnityAdsDidError(string message)
    {
        
    }
    //廣告開始
    public void OnUnityAdsDidStart(string placementId)
    {
        
    }
    //廣告完成
    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        if (placementId == placementRevival)   //if(廣告ID=復活ID)
        {
            switch (showResult)                //轉換判斷式
            {
                case ShowResult.Failed:        //第一種結果
                    print("失敗");
                    break;
                case ShowResult.Skipped:       //第二種結果
                    print("略過");
                    break;
                case ShowResult.Finished:      //第三種結果
                    print("完成");
                    GameObject.Find("鼠王").GetComponent<Player>().Revival();                   
                    break;               
            }
        }
    }
}
