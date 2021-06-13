using Unity.Entities;
using Unity.Jobs;
using Unity.Physics;
using Unity.Physics.Systems;
using UnityEngine;

public class JumpEnablingCollisionSystem : JobComponentSystem
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
		var applicationJob = new ApplicationJob
		{
			enablerGroup = GetComponentDataFromEntity<JumpEnablingComponent>(),
			moveableObjects = GetComponentDataFromEntity<PlayerControlSettingsComponent>()
		};

		return applicationJob.Schedule(stepPhysicsWorld.Simulation, ref buildPhysicsWorld.PhysicsWorld, inputDeps);
	}

	private struct ApplicationJob : ITriggerEventsJob
	{
		public ComponentDataFromEntity<JumpEnablingComponent> enablerGroup;
		public ComponentDataFromEntity<PlayerControlSettingsComponent> moveableObjects;
		public void Execute(TriggerEvent triggerEvent)
		{
			if (enablerGroup.HasComponent(triggerEvent.EntityA) && moveableObjects.HasComponent(triggerEvent.EntityB))
			{
				var ctrl = moveableObjects[triggerEvent.EntityB];
				ctrl.currentJumpsEnabled = ctrl.maxJumpsEnabled;
				moveableObjects[triggerEvent.EntityB] = ctrl;
			}

			if (enablerGroup.HasComponent(triggerEvent.EntityB) && moveableObjects.HasComponent(triggerEvent.EntityA))
			{
				var ctrl = moveableObjects[triggerEvent.EntityA];
				ctrl.currentJumpsEnabled = ctrl.maxJumpsEnabled;
				moveableObjects[triggerEvent.EntityA] = ctrl;
			}
		}
	}
}