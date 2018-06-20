using UnityEngine;
using ZSG.Controller;
using ZSG.Behaviour;
using ZSG.Objects;

namespace Objects
{
    public class Wave : MonoBehaviour
    {
        [SerializeField]
        private Attackable mamberOrigin;
        [SerializeField]
        private Character player;
        [SerializeField]
        private int count = 1;
        [SerializeField]
        private float sizeX = 1f;
        [SerializeField]
        private float sizeZ = 1f;


        private void Start()
        {
            for (int i = 0; i < count; i++)
            {
                Vector3 pos = transform.position;
                float x = Random.Range(pos.x - sizeX / 2, pos.x + sizeX / 2);
                float z = Random.Range(pos.z - sizeZ / 2, pos.z + sizeZ / 2);
                Attackable instance = Instantiate(mamberOrigin, new Vector3(x, 0, z), Quaternion.identity);
                instance.SetTarget(player);
            }
        }



        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Vector3 p1 = transform.position - new Vector3(-sizeX / 2f, 0, -sizeZ / 2f);
            Vector3 p2 = transform.position - new Vector3(sizeX / 2f, 0, -sizeZ / 2f);
            Vector3 p3 = transform.position - new Vector3(sizeX / 2f, 0, sizeZ / 2f);
            Vector3 p4 = transform.position - new Vector3(-sizeX / 2f, 0, sizeZ / 2f);
            Gizmos.DrawLine(p1, p2);
            Gizmos.DrawLine(p2, p3);
            Gizmos.DrawLine(p3, p4);
            Gizmos.DrawLine(p4, p1);
        }
    }
}
