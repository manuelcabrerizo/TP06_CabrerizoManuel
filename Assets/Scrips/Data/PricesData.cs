using UnityEngine;

[CreateAssetMenu(fileName = "PricesData", menuName = "Prices/Data", order = 1)]

public class PricesData : ScriptableObject
{
    [Header("Prices")]
    public int ShipPart1 = 1;
    public int ShipPart2 = 2;
    public int ShipPart3 = 2;
    public int ShipPart4 = 2;
}
