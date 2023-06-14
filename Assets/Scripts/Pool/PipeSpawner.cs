using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;
using FSM.States;

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
        }
        
        private void OnEnable()
        {
            StartLevelState.Entered += OnLevelStart;
        }

        private void OnDisable()
        {
            StartLevelState.Entered -= OnLevelStart;
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
            yield return new WaitForSeconds(1.5f);
            
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

        private void OnLevelStart()
        {
            Debug.Log("Hui sosi");
            Spawn();
        }
    }
}
