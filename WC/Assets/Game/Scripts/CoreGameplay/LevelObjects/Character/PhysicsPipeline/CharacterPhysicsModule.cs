using UnityEngine;

namespace WC
{
	public abstract class CharacterPhysicsModule : MonoBehaviour
	{
		public abstract void Affect(IPhysics physics);
	}
}