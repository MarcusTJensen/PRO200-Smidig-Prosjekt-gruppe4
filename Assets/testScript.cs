using UnityEngine;
using UnityEngine.XR;

[RequireComponent(typeof(Camera))]
public class testScript : MonoBehaviour
{
	readonly string OculusDevice = "Oculus";
	readonly string[] DaydreamDevices = new string[] { "cardboard" };
 
	[Header("Non-VR Settings")]
	[SerializeField] private float fieldOfView = 60f; // Can't get the Camera's FOV because the SDK changes it even before Awake! Need our own separate slider.
 
	#pragma warning disable 108
	private Camera camera;
	#pragma warning restore 108
 
	private void Awake()
	{
		// Doesn't work and isn't needed with Oculus
		if (XRSettings.loadedDeviceName == OculusDevice)
		{
			Destroy(this);
			return;
		}
		camera = GetComponent<Camera>();
		XRSettings.LoadDeviceByName(DaydreamDevices);
		camera.fieldOfView = fieldOfView;
	}
 
	private void Start()
	{
		SetVR(PlayerPrefs.GetInt("VR Mode", 0) == 1);
	}
 
	private void Update()
	{
		if (!XRSettings.enabled)
		{
			if (Application.isEditor)
			{
				transform.Rotate(0f, Input.GetAxis("Mouse X"), 0f, Space.World);
				transform.Rotate(-Input.GetAxis("Mouse Y"), 0f, 0f, Space.Self); // TODO: Stop camera from going upside down
			}
			else
			{
				transform.localPosition = InputTracking.GetLocalPosition(XRNode.CenterEye);          
				transform.localRotation = InputTracking.GetLocalRotation(XRNode.CenterEye);
			}
		}
	}
 
	public void ToggleVR()
	{
		SetVR(!XRSettings.enabled);
	}
 
	public void SetVR(bool enabled)
	{
		XRSettings.enabled = enabled;
		camera.ResetAspect();
		PlayerPrefs.SetInt("VR Mode", enabled ? 1 : 0);
	}
}