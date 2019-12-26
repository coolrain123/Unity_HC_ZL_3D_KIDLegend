
using UnityEngine;

public class mathflerp : MonoBehaviour
{
    // Start is called before the first frame update
    public float a = 0;
    public float b = 10;

    public Vector2 v2a = new Vector2(0, 0);
    public Vector2 v2b = new Vector2(500, 500);

    public Color cA, cB, cC;

    public Transform cube, sphere;


    void Start()
    {
       
       print( Mathf.Lerp(a, b, 0.6f));
       print(Vector2.Lerp(v2a, v2b, 0.6f));

       cC =  Color.Lerp(cA, cB, 0.3f);
    }

    // Update is called once per frame
    void Update()
    {

        cube.position = Vector3.Lerp(cube.position, sphere.position, 0.3f * Time.deltaTime);

    }
}
