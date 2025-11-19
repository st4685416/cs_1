namespace Restaurant;

public class Table
{
    private uint _id;
    private bool _availabilityStatus = true;
    private string _description = "";

    public uint Id
    {
        get { return _id; }
        set { _id = value; }
    }

    public bool AvailabilityStatus
    {
        get { return _availabilityStatus; }
    }

    public void SwitchAvailabilityStatus()
    {
        _availabilityStatus = !_availabilityStatus;
    }

    public void ShowInfo()
    {
        string status = "зайнятий";
        if (_availabilityStatus)
        {
            status = "вільний";
        }

        Program.Printer($"Столик {_id} {status}. {_description}");
    }
}