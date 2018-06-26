using UnityEngine;
using ZSG.Objects;

namespace ZSG.Factory
{
    public class NPCFactory : MonoBehaviour
    {
        private TemplatePool<Character> pool;


        public Character Create(Character original, Vector3 position)
        {
            Character character = pool.Get(original);
            character.transform.position = position;
            return character;
        }


        private void Awake()
        {
            pool = new TemplatePool<Character>(transform);
        }
    }
}
