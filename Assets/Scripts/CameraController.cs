using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

  public GameObject player;

  private Vector3 cameraVector;

	void Start() {
	  cameraVector = transform.position - player.transform.position;

    /* Only use if fullscreen cannot be achieved with CSS. */
	  //Screen.fullScreen = true;
	}

	void LateUpdate() {
	  transform.position = player.transform.position + cameraVector;
	}
}
