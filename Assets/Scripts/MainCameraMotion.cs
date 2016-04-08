using UnityEngine;
using System.Collections;

public class MainCameraMotion : MonoBehaviour {

    Transform tr;

    public float y = 13;
    public float speed = 60;


    void Awake () {
        tr = transform;
	}
	


	void FixedUpdate () {
        tr.LookAt(Vector3.zero);

        Vector3 position = tr.position;

        position += tr.forward * Input.GetAxis("Vertical") * speed;
        position += tr.right * Input.GetAxis("Horizontal") * GetDistanceFromTheCenter(tr.position)/ 10 * speed;
        position.y = y;
        tr.position = position;
    }

    private float GetDistanceFromTheCenter(Vector3 position)
    {
        return Mathf.Sqrt(Mathf.Pow(position.x,2) + Mathf.Pow(position.z,2));
    }
}
