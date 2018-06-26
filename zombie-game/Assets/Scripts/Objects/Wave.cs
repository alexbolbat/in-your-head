using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using ZSG.Behaviour;
using ZSG.Utils;

namespace ZSG.Objects
{
    public class Wave : MonoBehaviour
    {
        [SerializeField]
        private List<int> waves;
        [SerializeField]
        private Character enemyOrigin;
        [SerializeField]
        private RespawnPoint playerRespawn;
        [SerializeField]
        private Character playerOrigin;
        [SerializeField]
        private List<RespawnArea> areas;

        private Character player;
        private List<Character> enemies = new List<Character>();
        private int currentWave;


        private void Start()
        {
            InitPlayer();
            LaunchWave();
        }


        private void InitPlayer()
        {
            player = playerRespawn.Respawn(playerOrigin);
            player.Died += OnPlayerDied;
        }

        private void LaunchWave()
        {
            if (currentWave >= waves.Count)
            {
                currentWave = 0;
            }
            for (int i = 0; i < waves[currentWave]; i++)
            {
                Character enemy = App.NPCs.Create(enemyOrigin, GetRandomPoint());
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


        private void OnPlayerDied()
        {
            TimerUtil.Timeout(3f, () =>
            {
                player.Died -= OnPlayerDied;
                Destroy(player.gameObject);
                InitPlayer();

                enemies.ForEach(e => e.GetBehaviour<Attackable>().SetTarget(player));
            });
        }

        private void OnEnemyDied()
        {
            if (GetWaveCompleted())
            {
                TimerUtil.Timeout(3f, () =>
                {
                    enemies.ForEach(e => Destroy(e.gameObject));
                    enemies.Clear();

                    currentWave++;

                    LaunchWave();
                });
            }
        }
    }
}
