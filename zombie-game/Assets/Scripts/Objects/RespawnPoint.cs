using UnityEngine;

namespace ZSG.Objects
{
    public class RespawnPoint : MonoBehaviour
    {
        public T Respawn<T>(T origin) where T : Object
        {
            return Instantiate(origin, transform.position, transform.rotation);
        }
    }
}
