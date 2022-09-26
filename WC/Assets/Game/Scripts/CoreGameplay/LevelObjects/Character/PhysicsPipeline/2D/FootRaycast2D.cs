using System.Collections.Generic;
using System.Linq;
using Unity.Collections;
using UnityEngine;

namespace WC
{
    public class FootRaycast2D : FootRaycast
    {
        [SerializeField] private Transform _checkOrigin;
        [SerializeField] private LayerMask _raycastMask;
        [SerializeField, Min(0f)] private float _raysDistance;
        [SerializeField, Min(0f)] private float _raysRadius;
        [SerializeField, Min(1)] private int _raysCount;

        [Header("Minor settings")] [SerializeField, Min(0f)]
        private float _raysIndent = 0.1f;

        private Vector3[] _raysPositions;
        private List<RaycastHit2D> _hits;

        private void Awake()
        {
            _raysPositions = LinearPointsDistribution(_raysCount).ToArray();
            _hits = new List<RaycastHit2D>();
        }

        public override void UpdateFootHit()
        {
            _hits.Clear();
            for (int i = 0; i < _raysPositions.Length; i++)
            {
                Vector2 from = _checkOrigin.position + _raysPositions[i] * _raysRadius + Vector3.up * _raysIndent;
                _hits.Add(Physics2D.Raycast(from, Vector2.down, _raysDistance + _raysIndent, _raycastMask));
            }

            FootHit = new FootHit(
                _hits.Select(hit => new Hit()
                {
                    Distance = hit.distance,
                    Normal = hit.normal,
                    Point = hit.point,
                    Occure = hit.transform is not null
                }).ToArray(),
                _raysIndent, _raysDistance);
        }

        private void OnDrawGizmosSelected()
        {
            if (_checkOrigin == null)
                return;

            foreach (var point in LinearPointsDistribution(_raysCount))
            {
                Vector3 from = _checkOrigin.position + point * _raysRadius + Vector3.up * _raysIndent;
                Gizmos.DrawLine(from, from + Vector3.down * (_raysDistance + _raysIndent));
            }
        }

        private static IEnumerable<Vector3> LinearPointsDistribution(int points)
        {
            float start = -0.5f;
            float end = 0.5f;

            for (int i = 0; i < points + 1; ++i)
            {
                yield return new Vector3(Mathf.Lerp(start, end, (i) / (float)points), 0f, 0f);
            }
        }
    }
}
