using UnityEngine;

namespace coolrain {


    public class CameraContral : MonoBehaviour
    {
        [Header("速度"), Range(0, 100)]
        public float speed = 1.5f;
        [Header("上方限制")]
        public float top;
        [Header("下方限制")]
        public float bottom;

        private Transform player;      


        void Start()
        {
            player = GameObject.Find("鼠王").transform;
        }

        private void LateUpdate()
        {
            Track();
        }
        //攝影機追蹤
        private void Track()
        {
            Vector3 posP = player.position;
            Vector3 posC = transform.position;

            posP.x = 0;
            posP.y = 18;
            posP.z -= 18;

            posP.z = Mathf.Clamp(posP.z, bottom, top);
            transform.position = Vector3.Lerp(posC, posP, 0.3f * Time.deltaTime * speed);
           
        }
    }
}

