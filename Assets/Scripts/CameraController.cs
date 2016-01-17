using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

  public GameObject player;

  private Vector3 cameraVector;

	void Start() {
	  cameraVector = transform.position - player.transform.position;
	  Screen.fullScreen = true;
	}

	void LateUpdate() {
	  transform.position = player.transform.position + cameraVector;
	}
}
