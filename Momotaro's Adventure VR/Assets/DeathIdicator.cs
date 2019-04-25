using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DeathIdicator : MonoBehaviour
{
    [SerializeField]
    private Image deathIndicator;

    private Entity entity;

    // Start is called before the first frame update
    void Start()
    {
        entity = GetComponent<Entity>();
    }

    /*
        //Red gradient
        draw_sprite_stretched_ext(spr_Gradient_Min_Round, 0, 0, 0, _w, _h, fade_colour, fade_alpha_current);
    
        if (_p1.entity_health_current <= (30 * _p1.entity_health_max) / 100)
        {
            var _i = clamp( 1 - (_p1.entity_health_current * 2) / _p1.entity_health_max, 0, 1);
            //Red gradient
            draw_sprite_stretched_ext(spr_Gradient_Min_Round, 0, 0, 0, _w, _h, c_red, _i);
        }
     */

    // Update is called once per frame
    void Update()
    {
        float _health = entity.healthCurrent;
        float _healthStart = entity.startinghealth;

        if  (_health <= (30 * _healthStart) / 100)
        {
            float _value = Mathf.Clamp01(1 - (_health * 2) / _healthStart);
            ChangeOpacity(_value);
        }
        else
        {
            ChangeOpacity(0);
        }
    }

    public void ChangeOpacity(float _alpha)
    {
        _alpha = Mathf.Clamp01(_alpha);

        var tempColor = deathIndicator.color;
        tempColor.a = _alpha;

        deathIndicator.color = tempColor;
    }
}
