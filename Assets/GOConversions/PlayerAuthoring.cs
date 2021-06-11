<<<<<<< HEAD
using UnityEngine;
using Unity.Entities;

[AddComponentMenu("Custom Authoring/Player Authoring")]
public class PlayerAuthoring : MonoBehaviour, IConvertGameObjectToEntity
{
	public GameObject followingCamera;
	public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
	{
		PlayerFollowingCamera playerFollowingCamera = followingCamera.GetComponent<PlayerFollowingCamera>();

		if (followingCamera == null)
			playerFollowingCamera = followingCamera.AddComponent<PlayerFollowingCamera>();

		playerFollowingCamera.playerEntity = entity;
	}
=======
using UnityEngine;
using Unity.Entities;

[AddComponentMenu("Custom Authoring/Player Authoring")]
public class PlayerAuthoring : MonoBehaviour, IConvertGameObjectToEntity
{
	public GameObject followingCamera;
	public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
	{
		PlayerFollowingCamera playerFollowingCamera = followingCamera.GetComponent<PlayerFollowingCamera>();

		if (followingCamera == null)
			playerFollowingCamera = followingCamera.AddComponent<PlayerFollowingCamera>();

		playerFollowingCamera.playerEntity = entity;
	}
>>>>>>> 5629f42 (background bug, tutorial completed)
}