<<<<<<< HEAD
using UnityEngine;
using Unity;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Physics;
using Unity.Transforms;

public class ParallaxMovementSystem: ComponentSystem
{
	protected override void OnUpdate()
	{
		Entities.ForEach((ref Translation translation, ref ParallaxComponent parallaxComponent) =>
		{
			if (translation.Value.z != 0)
				translation.Value.x = ParallaxComponent.PlayerPositionX / translation.Value.z;
		});
	}
=======
using UnityEngine;
using Unity;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Physics;
using Unity.Transforms;

public class ParallaxMovementSystem: ComponentSystem
{
	protected override void OnUpdate()
	{
		Entities.ForEach((ref Translation translation, ref ParallaxComponent parallaxComponent) =>
		{
			if (translation.Value.z != 0)
				translation.Value.x = ParallaxComponent.PlayerPositionX / translation.Value.z;
		});
	}
>>>>>>> 5629f42 (background bug, tutorial completed)
}