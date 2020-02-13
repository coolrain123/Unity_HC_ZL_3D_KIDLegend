using UnityEngine;

public class Bullet : MonoBehaviour
{
    /// <summary>
    /// 子彈的傷害
    /// </summary>
    public float damage;

    /// <summary>
    /// 是否為玩家的武器  true 玩家的  false  敵人的
    /// </summary>
    public bool player;


    /// <summary>
    /// 有勾選 IsTrigger 的物件，偵測碰到其他物件執行一次
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if (!player && other.name == "鼠王")                          
        {
            other.GetComponent<Player>().Hit(damage);   //取得<玩家> 的 Hit 方法
            Destroy(gameObject);
        }
        if (player && other.tag == "敵人")
        {
            other.GetComponent<Enemy>().Hit(damage);   //取得<敵人> 的 Hit 方法
            Destroy(gameObject);
        }
        if (player && other.tag == "障礙物")
        {
            
            Destroy(gameObject);
        }
    }

}
