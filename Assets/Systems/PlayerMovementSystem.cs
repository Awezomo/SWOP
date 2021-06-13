using UnityEngine;
using Unity;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Physics;
using Unity.Transforms;

public class PlayerMovementSystem : ComponentSystem
{
	protected override void OnUpdate()
	{
		float dT = Time.DeltaTime;
		float horizontalControl = Input.GetAxis("x");
		Entities.ForEach((
			ref PlayerControlSettingsComponent controlSettingsComponent,
			ref Translation translation,
			ref PhysicsVelocity velocity,
			ref PlayerSpeedComponent playerSpeedComponent,
			ref PhysicsCollider collider
		) =>
		{
			if (controlSettingsComponent.currentJumpsEnabled > 1 && Input.GetKeyDown(controlSettingsComponent.jumpKey))
			{
				velocity.Linear.y = controlSettingsComponent.jumpForce;
				controlSettingsComponent.currentJumpsEnabled = Mathf.Max(0, controlSettingsComponent.currentJumpsEnabled - 1);
			}
			velocity.Linear.x = playerSpeedComponent.maxHorizontalSpeed * horizontalControl;
		});
	}
}