using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;


[AddComponentMenu("Custom Authoring/Portal Authoring")]
public class PortalAuthoring : MonoBehaviour, IConvertGameObjectToEntity
{
	public GameObject target;
	public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
	{
		if (target == null)
			throw new System.Exception("No sourcepath component in source!");

		var directionVector = target.GetComponent<Transform>().localPosition - GetComponent<Transform>().localPosition;
		dstManager.AddComponent<PortalPathComponent>(entity);
		dstManager.SetComponentData<PortalPathComponent>(entity, new PortalPathComponent { directionVector = directionVector });
	}
}