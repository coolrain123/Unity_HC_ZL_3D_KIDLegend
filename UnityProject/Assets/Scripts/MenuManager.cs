using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [Header("玩家資料")]
    public PlayerData dataPlayer;

    public void BuyHP()
    {
        dataPlayer.HpMax += 500;
        dataPlayer.HP = dataPlayer.HpMax;
    }

    public void BuyAtk()
    {
        dataPlayer.damage += 50;
    }

    public void LoadLevel()
    {
        dataPlayer.HP = dataPlayer.HpMax;
        SceneManager.LoadScene("關卡 1");
    }


}
