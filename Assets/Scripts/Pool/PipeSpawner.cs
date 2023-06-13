using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Pool
{
    public class PipeSpawner : ObjectPool
    {
        [SerializeField] private GameObject _prefab;
        [SerializeField] private float _secondsRate;
        [SerializeField] private Transform[] _points; 
        
        private Coroutine _spawnRoutine;
        private bool _isSpawnRoutineStarted;

        private void Start()
        {
            Initializate(_prefab);
            Spawn();
        }

        private void Spawn() => _spawnRoutine = StartCoroutine(SpawnRoutine());

        private void Stop()
        {
            if (_isSpawnRoutineStarted)
            {
                StopCoroutine(_spawnRoutine);
                _isSpawnRoutineStarted = false;
            }
        }

        private void SetObject(GameObject obj, Vector3 position)
        {
            obj.SetActive(true);
            foreach (Transform child in obj.transform)
            {
                child.gameObject.SetActive(true);
            }
            
            obj.transform.position = position;
        }
        
        private IEnumerator SpawnRoutine()
        {
            _isSpawnRoutineStarted = true;
            
            while (true)
            {
                if (TryGetObject(out GameObject obj))
                {
                    int pointIndex = Random.Range(0, _points.Length);
                    SetObject(obj, _points[pointIndex].position);
                    
                    yield return new WaitForSeconds(_secondsRate);
                }

                yield return null;
            }
        }
    }
}
