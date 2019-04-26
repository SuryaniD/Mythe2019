using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DamageIndicator : MonoBehaviour
{
    [SerializeField]
    private Image deathIndicator;

    private Entity entity;

    // Start is called before the first frame update
    void Start()
    {
        entity = GetComponent<Entity>();
    }


    public void Hit()
    {
        StartCoroutine(HitEffect());
    }

    IEnumerator HitEffect()
    {
        ChangeOpacity(0.5f);

        yield return new WaitForSeconds(1f);

        ChangeOpacity(0f);
    }

    public void ChangeOpacity(float _alpha)
    {
        _alpha = Mathf.Clamp01(_alpha);

        var tempColor = deathIndicator.color;
        tempColor.a = _alpha;

        deathIndicator.color = tempColor;
    }
}
