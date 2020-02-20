using UnityEngine;

public class Item : MonoBehaviour
{
    [HideInInspector]  //公開欄位在介面隱藏
    public bool pass;

    [Header("道具音效")]
    public AudioClip sound;

    private Transform player;
    private AudioSource aud;

    // Start is called before the first frame update
    void Start()
    {
        Physics.IgnoreLayerCollision(10, 10, false);
        HandleCollision();
        player = GameObject.Find("鼠王").transform;
        aud = GetComponent<AudioSource>();
    }

    private void Update()
    {
        GoToPlayer();
        
       
    }
    /// <summary>
    /// 控制忽略碰撞
    /// </summary>
    private void HandleCollision()
    {
        Physics.IgnoreLayerCollision(10, 9);
        Physics.IgnoreLayerCollision(10, 8);
    }

    private void GoToPlayer()
    {
        if (pass)
        {
            Physics.IgnoreLayerCollision(10, 10);
            transform.position = Vector3.Lerp(transform.position, player.position, 0.5f * Time.deltaTime * 10);

            if (Vector3.Distance(transform.position,player.position) < 0.8f && !aud.isPlaying)
            {
                aud.PlayOneShot(sound, 0.3f);
                Destroy(gameObject, 0.3f);
            }
        }

    }   
}
