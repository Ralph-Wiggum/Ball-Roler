using UnityEngine;
using System.Collections;

/** Creates a circle of pickUps around the y-axis. */
public class ConstructPickUpCircle : MonoBehaviour {

public Transform pickUp;
public int itemCount;
public float radius;

	void Start()
  {
    for (int i = 0; i < itemCount; i++)
    {
      float theta = 2 * Mathf.PI * i / itemCount;
      float x = transform.position.x + radius * Mathf.Cos(theta);
      float z = transform.position.z + radius * Mathf.Sin(theta);
      Instantiate(pickUp, new Vector3(x, 0.5f, z), Quaternion.identity);
    }
	}
}
