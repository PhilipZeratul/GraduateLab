using UnityEngine;


[ExecuteInEditMode]
public class IsometricObjectStatic : MonoBehaviour
{
	private const int IsometricRangePerYUnit = 1;

	[Tooltip("Will use this object to compute z-order")]
	public Transform Target;

	[Tooltip("Use this to offset the object slightly in front or behind the Target object")]
	public int TargetOffset = 0;


	#if UNITY_EDITOR
	void LateUpdate()
	{
		if (!Application.isPlaying)
		{
			if (Target == null)
				Target = transform;
            
            float zOrder = Target.position.y * IsometricRangePerYUnit - TargetOffset;
            Vector3 prevPosition = transform.position;
            transform.position = new Vector3(prevPosition.x, prevPosition.y, zOrder);
        }
    }
	#endif
}