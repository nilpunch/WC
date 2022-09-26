using UnityEngine;

namespace WC
{
    public class Rigidbody3DPhysics : Physics
	{
		[SerializeField] private Rigidbody _rigidbody;
		[SerializeField, Min(0f)] private float _maxFallVelocity = 5;

		private Vector3 _inheritedVelocityChange;
		private Vector3 _velocityChange;

		private Vector3 _lastInheritedVelocityChange;

		private Vector3 _expectedVelocity;

		public override Vector3 Velocity => _rigidbody.velocity - _lastInheritedVelocityChange;
		public override Vector3 Depenetration => _expectedVelocity - _rigidbody.velocity;
		public override Vector3 Position => _rigidbody.position;

		public override void AddInheritedForce(Vector3 velocity)
		{
			_inheritedVelocityChange += velocity;
		}

		public override void AddForce(Vector3 velocity)
		{
			_velocityChange += velocity;
		}

		public override void ApplyVelocityChanges()
		{
			Vector3 newInternalVelocity = Velocity + _velocityChange;

			newInternalVelocity = new Vector3(newInternalVelocity.x, Mathf.Max(newInternalVelocity.y, -_maxFallVelocity), newInternalVelocity.z);

			Vector3 newAbsoluteVelocity = newInternalVelocity + _inheritedVelocityChange;

			_rigidbody.velocity = newAbsoluteVelocity;
			_expectedVelocity = newAbsoluteVelocity;

			_lastInheritedVelocityChange = _inheritedVelocityChange;

			_velocityChange = Vector3.zero;
			_inheritedVelocityChange = Vector3.zero;
		}
	}
}
