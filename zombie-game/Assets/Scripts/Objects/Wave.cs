using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using ZSG.Controller;
using ZSG.Behaviour;

namespace ZSG.Objects
{
    public class Wave : MonoBehaviour
    {
        [SerializeField]
        private List<int> waves;
        [SerializeField]
        private Character enemyOrigin;
        [SerializeField]
        private Character player;
        [SerializeField]
        private List<RespawnArea> areas;

        private List<Character> enemies = new List<Character>();
        private int currentWave;
        private Vector3 startPos;


        private void Start()
        {
            startPos = player.transform.position;
            NextWave();
        }


        private void NextWave()
        {
            if (currentWave >= waves.Count)
            {
                currentWave = 0;
            }
            for (int i = 0; i < waves[currentWave]; i++)
            {
                Character enemy = Instantiate(enemyOrigin, GetRandomPoint(), Quaternion.identity);
                enemy.GetBehaviour<Attackable>().SetTarget(player);
                enemy.Died += OnEnemyDied;

                enemies.Add(enemy);
            }
        }

        private Vector3 GetRandomPoint()
        {
            RespawnArea area = areas[Random.Range(0, areas.Count)];
            return area.GetRandomPoint();
        }

        private bool GetWaveCompleted()
        {
            return !enemies.Any(e => !e.IsDead);
        }


        private void OnEnemyDied()
        {
            if (GetWaveCompleted())
            {
                enemies.ForEach(e => Destroy(e.gameObject));
                enemies.Clear();

                player.transform.position = startPos;

                currentWave++;
                NextWave();
            }
        }
    }
}
