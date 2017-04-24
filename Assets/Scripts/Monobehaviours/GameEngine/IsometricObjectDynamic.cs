using UnityEngine;


[ExecuteInEditMode]
public class IsometricObjectDynamic : MonoBehaviour
{
    public float gizmoLength = 1.0f;

	private const int IsometricRangePerYUnit = 1;

	[Tooltip("Will use this object to compute z-order")]
	public Transform Target;

	[Tooltip("Use this to offset the object slightly in front or behind the Target object")]
	public int TargetOffset = 0;


	void LateUpdate()
	{
		if (Target == null)
			Target = transform;

        float zOrder = Target.position.y * IsometricRangePerYUnit - TargetOffset;
        Vector3 prevPosition = transform.position;
        transform.position = new Vector3(prevPosition.x, prevPosition.y, zOrder);
    }

    void OnDrawGizmos()
    { 
        Gizmos.color = Color.yellow;

        Vector3 pivotLineStart = new Vector3(transform.position.x - gizmoLength, transform.position.y, transform.position.z);
        Vector3 pivotLineEnd = new Vector3(transform.position.x + gizmoLength, transform.position.y, transform.position.z);

        Gizmos.DrawLine(pivotLineStart, pivotLineEnd);        
    }
}