using System;
using System.ComponentModel;
using System.Drawing;


namespace HMI_Eray
{
    public class AxisCommand : INotifyPropertyChanged
    {
        

        private AxisStatus _status;
        private int _value;                              /////////////////////////Değişti/////////////////////////////////////
        

        public AxisName Name { get; private set; }

        public AxisStatus Status
        {
            get { return _status; }
            set
            {
                if (_status == value)
                    return;

                _status = value;
                OnPropertyChanged(nameof(Status));
                OnPropertyChanged(nameof(StatusImage));
            }
        }

        public Image StatusImage
        { get
            {
                switch (Status)
                {
                    case AxisStatus.Idle:
                        return Properties.Resources.icons8_sleeping_26;
                    case AxisStatus.Working:
                        return Properties.Resources.icons8_puzzled_26;
                    case AxisStatus.Error:
                        return Properties.Resources.icons8_sad_26;
                    case AxisStatus.Finished:
                        return Properties.Resources.icons8_happy_26;
                }
                throw new ArgumentOutOfRangeException();
            }
        }
        public int Value                                    /////////////////////////Değişti/////////////////////////////////////             
        {
            get => _value;
            set
            {

                if (_value == value)
                    return;

                _value = value;
                OnPropertyChanged(nameof(Value));
                OnPropertyChanged(nameof(DisplayValue));
            }
        }

        public double DisplayValue
        {
             
            get
            {
                 
                return Value * 0.1; ;
            }
            
        }

       
        public AxisCommand(AxisName name)
        {
            Name = name;
            Status = AxisStatus.Idle;
            Value = 0;                                            /////////////////////////Değişti/////////////////////////////////////
        }







        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName) 
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
