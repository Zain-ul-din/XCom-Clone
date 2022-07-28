using UnityEngine;

[RequireComponent(typeof(Camera))]
public class OrbitCamera : MonoBehaviour {
  
  [Header("Look at target")][SerializeField] private Transform target;

  [SerializeField] private float rotationSensitivity = 1f;
  [Tooltip("Camera Rotation Speed")][SerializeField] private float rotationSpeed = 0.1f;
  [Tooltip("Z off set from camera (positive val)")][SerializeField] private float zOffSet = 5f;
  [Tooltip("smooth val")] [SerializeField] private float rotationSmoothing = 2f;
  [SerializeField] private float yVal = 2;
    
  private float xVelocity ,  rotationAxisX  ;
  
  private void LateUpdate() {
    if (!target) return;

    Quaternion rotation;
    Vector3 position;
    var transform = this.transform;
    
    if (Input.GetMouseButton(0))  xVelocity += Input.GetAxis("Mouse X") * rotationSensitivity;
    rotationAxisX += xVelocity;

    rotation = Quaternion.Euler( transform.eulerAngles.x , rotationAxisX * rotationSpeed , 0);
    position = rotation * new Vector3(0f, 0f , -zOffSet) + target.position;
    position.y = yVal;

    transform.position = position;
    transform.rotation = rotation;
    
    // move smoothly
    xVelocity = Mathf.Lerp(xVelocity, 0, Time.deltaTime * rotationSmoothing);
  }

}
