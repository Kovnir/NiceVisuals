using UnityEngine;

public class QubeParticleBehaviour : TranslationalMotionParticleBehaviour
{

    protected override void Start()
    {
        base.Start();
        //присваеваем кубику uv-координаты определённого цвета на текстуре-палитре
        Mesh mesh = column.GetComponent<MeshFilter>().mesh;
        Vector2[] uv = mesh.uv;
        Vector2 newUV = new Vector2(UnityEngine.Random.value,0);
        uv = new Vector2[mesh.vertexCount];
        for (int i = 0; i < mesh.vertexCount; i++)
            uv[i] = newUV;
        mesh.uv = uv;
    }
}
