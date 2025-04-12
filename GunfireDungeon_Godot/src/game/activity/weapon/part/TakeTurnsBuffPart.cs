
public class TakeTurnsBuffPart : BuffPart
{
    private int index = 0;

    public override PartBase[] PlanningNext(PartBase[] occupancy)
    {
        if (index >= occupancy.Length)
        {
            index = 0;
        }

        return new[] { occupancy[index++] };
    }
}