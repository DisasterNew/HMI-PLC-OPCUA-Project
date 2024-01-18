namespace HMI_Eray
{
    public class RunningAxisData
    {
        public AxisCommand Command { get; set; }
        public AxisStatus Status { get; set; }
        public bool Running
        {
            get
            {
                return Status == AxisStatus.Working;
            }
        }
        public RunningAxisData(AxisCommand command, AxisStatus status) 
        {
            Command = command;
            Status = status;
        }
    }
}
