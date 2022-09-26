using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace WC
{
    public readonly struct FootHit
	{
		public readonly IReadOnlyList<Hit> Hits;
		public readonly float RaysIndent;
		public readonly float RaycastDistance;

		public FootHit(IReadOnlyList<Hit> readOnlyList, float raysIndent, float raycastDistance)
		{
			RaycastDistance = raycastDistance;
			Hits = readOnlyList;
			RaysIndent = raysIndent;
		}

		public bool HasHit => Hits.Any(raycastHit => raycastHit.Occure);

        public Vector3 NearestNormal(float distancePower = 1f)
		{
			if (!HasHit)
				throw new Exception("There are no hits.");

			float maxDistance = MaxDistance();
			float minDistance = MinDistance();

			Vector3 normalSum = Vector3.zero;
			float weightSum = 0f;

			foreach (var raycastHit in Hits.Where(raycastHit => raycastHit.Occure))
			{
				float distance = raycastHit.Distance - RaysIndent;

				float weight = 1f - Mathf.Pow((distance - minDistance) / (maxDistance - minDistance), distancePower);

				normalSum += raycastHit.Normal * weight;

				weightSum += weight;
			}

			return Vector3.Normalize(normalSum / weightSum);
		}

		public float MinDistance()
		{
			if (!HasHit)
				throw new Exception("There are no hits.");

			float minDistance = Single.MaxValue;

			foreach (var raycastHit in Hits.Where(raycastHit => raycastHit.Occure))
			{
				float distance = raycastHit.Distance - RaysIndent;

				if (distance < minDistance)
				{
					minDistance = distance;
				}
			}

			return minDistance;
		}

		public float MinDistanceWithAngleConstraint(float maxAngle)
		{
			if (!HasHit)
				throw new Exception("There are no hits.");

			float minDistance = Single.MaxValue;

			foreach (var raycastHit in Hits.Where(raycastHit => raycastHit.Occure))
			{
				float distance = raycastHit.Distance - RaysIndent;
				float angle = Vector3.Angle(Vector3.up, raycastHit.Normal);

				if (distance < minDistance && angle <= maxAngle)
				{
					minDistance = distance;
				}
			}

			return minDistance;
		}

		public float MaxDistance()
		{
			if (!HasHit)
				throw new Exception("There are no hits.");

			float maxDistance = Single.MinValue;

			foreach (var raycastHit in Hits.Where(raycastHit => raycastHit.Occure))
			{
				float distance = raycastHit.Distance - RaysIndent;

				if (distance > maxDistance)
				{
					maxDistance = distance;
				}
			}

			return maxDistance;
		}

		public Vector3 AverageNormal()
		{
			if (!HasHit)
				throw new Exception("There are no hits.");

			Vector3 normalSum = Vector3.zero;
			float distanceSum = 0f;
			int hits = 0;

			foreach (var raycastHit in Hits.Where(raycastHit => raycastHit.Occure))
			{
				hits += 1;
				distanceSum += raycastHit.Distance;
				normalSum += raycastHit.Normal;
			}

			if (hits == 0)
				throw new Exception("There no ground hit.");

			return normalSum / hits;
		}

		public float AverageDistance()
		{
			if (!HasHit)
				throw new Exception("There are no hits.");

			Vector3 normalSum = Vector3.zero;
			float distanceSum = 0f;
			int hits = 0;

			foreach (var raycastHit in Hits.Where(raycastHit => raycastHit.Occure))
			{
				hits += 1;
				distanceSum += raycastHit.Distance;
				normalSum += raycastHit.Normal;
			}

			if (hits == 0)
				throw new Exception("There are no hits.");

			return distanceSum / hits - RaysIndent;
		}
	}
}
