using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class InputManager : MonoBehaviour
{
    public GameObject AR_object;
    public Camera AR_Camera;
    public ARRaycastManager raycastManager;
    public List<ARRaycastHit> hits = new List<ARRaycastHit>();
    public ARPlaneManager aRPlaneManager;

    void Start()
    {
        //raycastManager변수에는 ARSessionOrigin이 할당되어 있다. 그래서
        //ARSessionOrigin에 있는 ArPlaneManager 컴포넌트를 들고와서 설정.
        aRPlaneManager = raycastManager.GetComponent<ARPlaneManager>();
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = AR_Camera.ScreenPointToRay(Input.mousePosition);
            // Raycast(Ray, List<ARRaycastHit>, ) 
            // : 추적가능한 물체(plane과 같은)에 Ray를 쏜다.
            // true : rarycast가 trakbalteTypes의 tarckable에 hit한 경우.
            if(raycastManager.Raycast(ray, hits))
            {
                Pose pose = hits[0].pose;
                Instantiate(AR_object, pose.position, pose.rotation);
                
                //aRPlaneManager 컴포넌트를 비활성화 시킨다. 그런데, 터치를 입력으로 받기 때문에 toggle로 작동함.
                aRPlaneManager.enabled = !aRPlaneManager.enabled;
                foreach(ARPlane plane in aRPlaneManager.trackables)
                {
                    plane.gameObject.SetActive(aRPlaneManager.enabled);
                }
            }
        }
    }
}

// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;
// using UnityEngine.XR.ARFoundation;

// public class InputManager : MonoBehaviour
// {
//     public GameObject AR_object;
//     public Camera AR_Camera;
//     public ARRaycastManager raycastManager;
//     public List<ARRaycastHit> hits = new List<ARRaycastHit>();
//     public ARPlaneManager aRPlaneManager;

//     [Tooltip("The UI Text element used to display plane detection messages.")]
//     [SerializeField]
//     Text m_TogglePlaneDetectionText;

//     public Text togglePlaneDetectionText
//     {
//         get {return m_TogglePlaneDetectionText; }
//         set {m_TogglePlaneDetectionText = value; }
//     }

    
//     public void TogglePlaneDetection()
//     {
//         aRPlaneManager.enabled = !aRPlaneManager.enabled;
        
//         string planeDetectionMessage = "";
//         if (aRPlaneManager.enabled)
//         {
//             planeDetectionMessage = "Disable Plane Detection and Hide Existing";
//             // SetAllPlanesActive(true);
//         }
//         else 
//         {
//             planeDetectionMessage = "Enable Plane Detection and Show Existing";
//             // SetAllPlanesActive(false);
//         }

//         if (togglePlaneDetectionText != null)
//             togglePlaneDetectionText.text = planeDetectionMessage;

//     }

//     void SetAllPlanesActive(bool value)
//     {
//         foreach (var plane in aRPlaneManager.trackables)
//             plane.gameObject.SetActive(value);
//     }

//     void Awake()
//     {
//         aRPlaneManager = raycastManager.GetComponent<ARPlaneManager>();
//     }
// }

