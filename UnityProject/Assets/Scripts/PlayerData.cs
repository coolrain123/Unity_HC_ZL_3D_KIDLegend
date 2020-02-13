
using UnityEngine;
[CreateAssetMenu(fileName = "玩家資料", menuName = "Coolrain/玩家資料")]
public class PlayerData : ScriptableObject
{
    [Header("血量"), Range(200, 10000)]
    public float HP;
    public float HpMax;
    [Header("子彈位移")]
    public float attackY;
    public float attackZ;
    [Header("攻擊冷卻"), Range(0, 1.5f)]
    public float cd = 0.7f;   
    [Header("遠距離子彈速度"), Range(0, 5000)]
    public int bulletPower;
    [Header("攻擊力"), Range(50, 1000)]
    public float damage;


}
