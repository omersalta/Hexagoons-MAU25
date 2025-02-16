using System;
using System.Collections.Generic;
using Game;
using UnityEngine;

namespace Enemy
{
    public class EnemyAI : MonoBehaviour, ILightDarkBehaviour
    {
        [SerializeField] private List<Transform> _wayPoints;
         private float _speed;
        [SerializeField] private float _patrolSpeed = 3f;
        [SerializeField] private float _chaseSpeed = 5f;
        [SerializeField] private float _ReturnSpeed = 7f;
        [SerializeField] private float _chaseRange = 10f;
        [SerializeField] private float _stopChaseDistance = 50f;
         private bool _isPlayerLight = true;
         private bool _canCheckPlayer = true;
        [SerializeField] private Transform _player;

        private int _currentWaypointIndex = 0;
        private bool _isChasing = false;

        private void Start()
        {
            _player = FindObjectOfType<Player>().transform;
            _speed = _patrolSpeed;
        }

        public void OnLight()
        {
            _isPlayerLight = true;
        }
        public void OnDark()
        {
            _isPlayerLight = false;
        }

        private void Update()
        {
            if (_isChasing && !_isPlayerLight)
            {
                ChasePlayer();
            }
            else
            {
                Patrol();
            }
        }

        private void Patrol()
        {
            if (_wayPoints.Count == 0) return;

            Transform targetWaypoint = _wayPoints[_currentWaypointIndex];
            MoveTowards(targetWaypoint.position, _speed);

            if (Vector3.Distance(transform.position, targetWaypoint.position) < 1f)
            {
                _currentWaypointIndex = (_currentWaypointIndex + 1) % _wayPoints.Count;
                Debug.Log("CanCheckkkk");
                _canCheckPlayer = true;
                _speed = _patrolSpeed;
            }

            if (_canCheckPlayer)
            {
                CheckForPlayer();
            }
           
        }

        private void ChasePlayer()
        {
            
            MoveTowards(_player.position, _chaseSpeed);

            Transform nearestWaypoint = GetNearestWaypoint();
            if (Vector3.Distance(transform.position, nearestWaypoint.position) > _stopChaseDistance)
            {
                Debug.Log("Stop Chasing");
                _isChasing = false;
                _canCheckPlayer = false;
                _speed = _ReturnSpeed;
            }
        }

        private void MoveTowards(Vector3 target, float speed)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        }

        private void CheckForPlayer()
        {
            if (Vector3.Distance(transform.position, _player.position) < _chaseRange)
            {
                _isChasing = true;
            }
        }

        private void OnCollisionStay2D(Collision2D other)
        {
            Debug.Log(other.gameObject.name);
        }

        private Transform GetNearestWaypoint()
        {
            Transform nearest = null;
            float minDistance = Mathf.Infinity;

            foreach (var waypoint in _wayPoints)
            {
                float distance = Vector3.Distance(transform.position, waypoint.position);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    nearest = waypoint;
                }
            }
            return nearest;
        }
    }
}