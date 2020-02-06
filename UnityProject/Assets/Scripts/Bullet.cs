using UnityEngine;

public class Bullet : MonoBehaviour
{
    /// <summary>
    /// 子彈的傷害
    /// </summary>
    public float damage;


    /// <summary>
    /// 有勾選 IsTrigger 的物件，偵測碰到其他物件執行一次
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "鼠王")                          
        {
            other.GetComponent<Player>().Hit(damage);   //取得<玩家> 的 Hit 方法
        }
    }

}
