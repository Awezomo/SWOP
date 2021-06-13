using Unity.Entities;
using Unity.Jobs;
using Unity.Transforms;
using Unity.Physics;
using Unity.Physics.Systems;
using UnityEngine;

public class PortalCollisionSystem : JobComponentSystem
{
	protected override void OnCreate()
	{
		buildPhysicsWorld = World.GetOrCreateSystem<BuildPhysicsWorld>();
		stepPhysicsWorld = World.GetOrCreateSystem<StepPhysicsWorld>();
	}

	private BuildPhysicsWorld buildPhysicsWorld;
	private StepPhysicsWorld stepPhysicsWorld;

	protected override JobHandle OnUpdate(JobHandle inputDeps)
	{
		inputDeps.Complete();
		ApplicationJob job = new ApplicationJob
		{
			enablerGroup = GetComponentDataFromEntity<PortalPathComponent>(),
			playerEntities = GetComponentDataFromEntity<Translation>(),
			time = Time.ElapsedTime
		};
		return job.Schedule(stepPhysicsWorld.Simulation, ref buildPhysicsWorld.PhysicsWorld, inputDeps);
	}

	private struct ApplicationJob : ITriggerEventsJob
	{
		static double lastPortal = 0;
		public double time;
		public ComponentDataFromEntity<PortalPathComponent> enablerGroup;
		public ComponentDataFromEntity<Translation> playerEntities;

		public void Execute(TriggerEvent triggerEvent)
		{
			if (enablerGroup.HasComponent(triggerEvent.EntityA) && playerEntities.HasComponent(triggerEvent.EntityB))
			{
				if (time - lastPortal < 1.5f)
					return;
				lastPortal = time;

				var playerTranslation = playerEntities[triggerEvent.EntityB];
				Debug.Log(playerTranslation.Value);
				Debug.Log(enablerGroup[triggerEvent.EntityA].directionVector);
				playerTranslation.Value += enablerGroup[triggerEvent.EntityA].directionVector;
				playerEntities[triggerEvent.EntityB] = playerTranslation;
			}

			if (enablerGroup.HasComponent(triggerEvent.EntityB) && playerEntities.HasComponent(triggerEvent.EntityA))
			{
				if (time - lastPortal < 1.5f)
					return;
				lastPortal = time;

				var playerTranslation = playerEntities[triggerEvent.EntityA];
				Debug.Log(playerTranslation.Value);
				Debug.Log(enablerGroup[triggerEvent.EntityB].directionVector);
				playerTranslation.Value += enablerGroup[triggerEvent.EntityB].directionVector;
				Debug.Log(playerTranslation.Value);
				playerEntities[triggerEvent.EntityA] = playerTranslation;
			}
		}
	}
}