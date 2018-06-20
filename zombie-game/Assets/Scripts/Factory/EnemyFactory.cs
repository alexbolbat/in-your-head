using UnityEngine;

namespace ZSG.Controller
{
    public class EnemyFactory
    {
        public static GameObject InitEnemy(GameObject origin, Vector3 position)
        {
            return GameObject.Instantiate(origin, position, Quaternion.identity);
        }
    }
}
