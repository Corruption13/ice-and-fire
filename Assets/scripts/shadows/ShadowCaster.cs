using System.Linq;
using System.Reflection;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.Rendering.Universal;

[RequireComponent(typeof(CompositeCollider2D))]
public class ShadowCaster : MonoBehaviour
{

    [Space]
    [SerializeField]
    private bool selfShadows = true;

    private CompositeCollider2D tilemapCollider;


    static readonly FieldInfo meshField = typeof(ShadowCaster2D).GetField("m_Mesh", BindingFlags.NonPublic | BindingFlags.Instance);
    static readonly FieldInfo shapePathField = typeof(ShadowCaster2D).GetField("m_ShapePath", BindingFlags.NonPublic | BindingFlags.Instance);

    private void Start()
    {
        if(PlayerPrefs.GetInt("shadows") == 0)
        {
            DestroyAllChildren();
        }
    }
    public void Generate()
    {
        DestroyAllChildren();

        tilemapCollider = GetComponent<CompositeCollider2D>();

        for (int i = 0; i < tilemapCollider.pathCount; i++)
        {
            Vector2[] pathVertices = new Vector2[tilemapCollider.GetPathPointCount(i)];
            tilemapCollider.GetPath(i, pathVertices);
            GameObject shadowCaster = new GameObject("shadow_caster_" + i);
            shadowCaster.transform.parent = gameObject.transform;
            UnityEngine.Rendering.Universal.ShadowCaster2D shadowCasterComponent = shadowCaster.AddComponent<UnityEngine.Rendering.Universal.ShadowCaster2D>();
            shadowCaster.transform.position = tilemapCollider.transform.position;
            shadowCasterComponent.selfShadows = this.selfShadows;

            Vector3[] testPath = new Vector3[pathVertices.Length];
            for (int j = 0; j < pathVertices.Length; j++)
            {
                testPath[j] = pathVertices[j];
            }

            shapePathField.SetValue(shadowCasterComponent, testPath);
            meshField.SetValue(shadowCasterComponent, new Mesh());
            
        }

        // Debug.Log("Generate");

    }
    public void DestroyAllChildren()
    {

        var tempList = transform.Cast<Transform>().ToList();
        foreach (var child in tempList)
        {
            DestroyImmediate(child.gameObject);
        }

    }

}