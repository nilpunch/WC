using UnityEngine;

namespace WC
{
	public class CharacterPhysicsPipeline : MonoBehaviour
	{
		[SerializeField] private Physics _physics;
		[SerializeField] private CharacterFoot _characterFoot;
		[SerializeField] private FootRaycast _footRaycast;
		[SerializeField] private CharacterPhysicsModule[] _physicsModules;

		public void ManualUpdate()
		{
			_footRaycast.UpdateFootHit();
			_characterFoot.UpdateGroundState();

			foreach (var module in _physicsModules)
				module.Affect(_physics);

            _physics.ApplyVelocityChanges();
		}
	}
}
