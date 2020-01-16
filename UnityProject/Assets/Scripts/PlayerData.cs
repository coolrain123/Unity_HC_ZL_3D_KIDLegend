
using UnityEngine;
[CreateAssetMenu(fileName = "玩家資料", menuName = "Coolrain/玩家資料")]
public class PlayerData : ScriptableObject
{
    [Header("血量"), Range(200, 10000)]
    public float HP;

    public float HpMax;
}
