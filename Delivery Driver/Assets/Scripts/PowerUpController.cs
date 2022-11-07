using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PowerUpController : MonoBehaviour
{
    public List<Transform> spawnLocations;
    public GameObject powerupParent;
    public SpeedBoost prefab;
    public int maxPowerups = 5;

    List<SpeedBoost> powerups = new List<SpeedBoost>();

    void Start()
    {
        for (int i = 0; i < maxPowerups; i++)
        {
            var sb = Instantiate(prefab, powerupParent.transform);
            SetPositionPowerupAndActivate(sb);
        }
    }

    void Update()
    {
        if (powerups.Any(sb => sb.gameObject.activeSelf == false))
        {
            var sb = powerups.Where(sb => sb.gameObject.activeSelf == false).FirstOrDefault();
            if (sb == null)
                return;
            SetPositionPowerupAndActivate(sb);
        }
    }

    void SetPositionPowerupAndActivate(SpeedBoost obj)
    {
        int index = Random.Range(0, spawnLocations.Count);
        while (powerups.Any(sb => sb.GetPositionIndex() == index))
        {
            index = Random.Range(0, spawnLocations.Count);
            obj.SetPositionIndex(index);
        }
        obj.transform.position = spawnLocations[index].transform.position;
        obj.gameObject.SetActive(true);
        if (!powerups.Contains(obj))
            powerups.Add(obj);
    }
}
