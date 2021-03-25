using UnityEngine;

internal class ThrownObject : MonoBehaviour
{
	public void SetRandomSize(float min, float max)
	{
		transform.localScale = Vector3.one * Random.Range(min, max);
	}
}