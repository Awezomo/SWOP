using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;


public class PlayerFollowingCamera : MonoBehaviour
{
	public Entity playerEntity;
	public float3 offset = float3.zero;
	private float xSpeed;
	private float ySpeed;
	private EntityManager manager;
	private void Awake()
	{
		manager = World.DefaultGameObjectInjectionWorld.EntityManager;
	}

	private void LateUpdate()
	{
		if (playerEntity == null)
			return;

		Translation t = manager.GetComponentData<Translation>(playerEntity);

		float yDeviation = t.Value.y - transform.position.y;
		float xDeviation = t.Value.x - transform.position.x;

		if (Mathf.Sqrt(xDeviation * xDeviation + yDeviation * yDeviation) > 10)
			transform.position += new Vector3(xDeviation, yDeviation - Mathf.Sign(yDeviation) * 1, 0);

		ySpeed = Mathf.Pow(yDeviation / 2, 3) * 0.3f;

		xSpeed = Mathf.Pow(t.Value.x - transform.position.x, 3) * 0.1f; // I know, magic values bad, but this has been tested to make the camera movement as smooth as possbile;

		transform.position += new Vector3(xSpeed, ySpeed, 0) * Time.deltaTime; //new Vector3(t.Value.x, transform.position.y, transform.position.z);
	}
}