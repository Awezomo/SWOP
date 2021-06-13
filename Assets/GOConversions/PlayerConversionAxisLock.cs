using UnityEngine;
using Unity.Entities;
using Unity.Physics;
using Unity.Physics.Authoring;

[DisallowMultipleComponent]
public class PlayerConversionAxisLock : MonoBehaviour
{
	public bool RotationX;
	public bool RotationY;
	public bool RotationZ;
}

[UpdateAfter(typeof(PhysicsBodyConversionSystem))]
public class PlayerEntityConversion : GameObjectConversionSystem
{
	protected override void OnUpdate()
	{
		Entities.ForEach((PlayerConversionAxisLock playerObject) =>
		{
			var entity = GetPrimaryEntity(playerObject.gameObject);
			var mass = DstEntityManager.GetComponentData<PhysicsMass>(entity);

			if (playerObject.RotationX)
				mass.InverseInertia.x = 0.0f;
			if (playerObject.RotationY)
				mass.InverseInertia.y = 0.0f;
			if (playerObject.RotationZ)
				mass.InverseInertia.z = 0.0f;

			DstEntityManager.SetComponentData<PhysicsMass>(entity, mass);
		});
	}
}

