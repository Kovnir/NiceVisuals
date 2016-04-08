using UnityEngine;
using System.Collections;

public class BGColorController : MonoBehaviour {



    public const float COLOR_EPS = 0.05f;
    [Range(0, 1)]
    public float colorSpeed = 0.01f;
    [Range(0, 1)]
    public float bottomBorder = 0.8f;

    void Start()
    {
        StartCoroutine(BGColorCoroutine());
    }


    IEnumerator BGColorCoroutine()
    {
        Camera camera = GetComponent<Camera>();
        camera.backgroundColor = new Color(1, 0, 0);
        while (true)
        {
            //увеличиваем зелёную составляющую цвета
            while (camera.backgroundColor.g <= 1 - COLOR_EPS)
            {
                yield return new WaitForSeconds(0.1f);
                camera.backgroundColor += new Color(0, colorSpeed, 0);
            }
            //уменьшаем красную
            while (camera.backgroundColor.r >= bottomBorder + COLOR_EPS)
            {
                yield return new WaitForSeconds(0.1f);
                camera.backgroundColor -= new Color(colorSpeed, 0, 0);
            }
            //увеличиваем синую
            while (camera.backgroundColor.b <= 1 - COLOR_EPS)
            {
                yield return new WaitForSeconds(0.1f);
                camera.backgroundColor += new Color(0, 0, colorSpeed);
            }
            //уменьшаем зелёную 
            while (camera.backgroundColor.g >= bottomBorder + COLOR_EPS)
            {
                yield return new WaitForSeconds(0.1f);
                camera.backgroundColor -= new Color(0, colorSpeed, 0);
            }
            //увеличиваем красную
            while (camera.backgroundColor.r <= 1 - COLOR_EPS)
            {
                yield return new WaitForSeconds(0.1f);
                camera.backgroundColor += new Color(colorSpeed, 0, 0);
            }
            //уменьшаем синую
            while (camera.backgroundColor.b >= bottomBorder + COLOR_EPS)
            {
                yield return new WaitForSeconds(0.1f);
                camera.backgroundColor -= new Color(0, 0, colorSpeed);
            }
        }
    }

}
