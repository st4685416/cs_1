namespace Restaurant;

public class Tables
{
    private uint _lastId = 1;
    private uint _count = 0;
    private Dictionary<uint, Table> _tables = new Dictionary<uint, Table>();

    public uint Count
    {
        get { return _count; }
    }

    public void AddTables(uint count = 1)
    {
        for (uint i = 1; i <= count; i++)
        {
            AddTable(new Table());
        }
    }

    public void AddTable(Table table)
    {
        table.Id = _lastId;
        _tables.Add(_lastId++, table);
    }

    public Table GetTable(uint id)
    {
        if (id > 0)
        {
            if (_tables.ContainsKey(id))
            {
                if (_tables[id].AvailabilityStatus)
                {
                    return _tables[id];
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }
        else
        {
            return FindFreeTable();
        }
    }

    private Table FindFreeTable()
    {
        foreach (Table tmpTable in _tables.Values)
        {
            if (tmpTable.AvailabilityStatus)
            {
                return tmpTable;
            }
        }

        return null;
    }

    public void RemoveTable(uint id)
    {
        if (_tables.ContainsKey(id))
            _tables.Remove(id);
    }

    public void SetTableAvailable(uint id)
    {
        if (_tables.ContainsKey(id))
            _tables[id].SwitchAvailabilityStatus();
    }
}