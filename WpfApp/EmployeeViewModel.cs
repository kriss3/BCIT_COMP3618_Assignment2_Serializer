using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Windows.Controls;
using System.Windows.Input;
using Worker;


namespace WpfApp
{
    public class EmployeeViewModel : INotifyPropertyChanged
    {
        private int _employeeId;
        private string _firstName = String.Empty;
        private string _lastName = String.Empty;
        private string _homePhone = String.Empty;
        private string _notes = String.Empty;
        private bool _canShowXml = false;
        private string _state = string.Empty;

        public int EmployeeId
        {
            get { return _employeeId; }
            set
            {
                if (value != _employeeId)
                {
                    _employeeId = value;
                    OnPropertyChanged("EmployeeId");
                }
            }
        }
        public string FirstName
        {
            get { return _firstName; }
            set
            {
                if (value != _firstName)
                {
                    _firstName = value;
                    OnPropertyChanged("FirstName");
                }
            }
        }
        public string LastName
        {
            get { return _lastName; }
            set
            {
                if (value != _lastName)
                {
                    _lastName = value;
                    OnPropertyChanged("LastName");
                }
            }
        }
        public string HomePhone
        {
            get { return _homePhone; }
            set
            {
                if (value != _homePhone)
                {
                    _homePhone = value;
                    OnPropertyChanged("HomePhone");
                }
            }
        }
        public string Notes
        {
            get { return _notes; }
            set
            {
                if (value != _notes)
                {
                    _notes = value;
                    OnPropertyChanged("Notes");
                }
            }
        }
        public bool CanShowXml
        {
            get { return _canShowXml; }
            set
            {
                if (value != _canShowXml)
                {
                    _canShowXml = value;
                    OnPropertyChanged("CanShowXml");
                }
            }
        }
        public string State
        {
            get { return _state; }
            set
            {
                if (value != _state)
                {
                    _state = value;
                    OnPropertyChanged("State");
                }
            }
        }

        private Employee _employee;
        private ICommand _serializeCommand;
        private ICommand _deserializeCommand;
        private ICommand _clearCommand;

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public Employee Employee
        {
            get { return _employee; }
            set
            {
                if (value != _employee)
                    _employee = value;
                OnPropertyChanged("Employee");
            }
        }
        public ICommand SerializeCommand
        {
            get
            {
                if (_serializeCommand == null)
                {
                    _serializeCommand =
                        new RelayCommand(x => DoSerialize(_employee), x => true);
                }
                return _serializeCommand;
            }
        }
        public ICommand DeserializeCommand
        {
            get
            {
                if (_deserializeCommand == null)
                {
                    _deserializeCommand = new RelayCommand(x => DoDeserialize(), x => true);
                }
                return _deserializeCommand;
            }
        }
        public ICommand ClearCommand
        {
            get
            {
                if (_clearCommand == null)
                {
                    _clearCommand = new RelayCommand(x => ClearFields(), x => true);
                }
                return _clearCommand;
            }
        }

        #region Private Methods
        private void DoSerialize(Employee emp)
        {
            emp = new Employee { EmployeeId = EmployeeId, FirstName = FirstName, LastName = LastName, HomePhone = HomePhone, Notes = Notes};
            Work.DoSerialize(emp);
            State = "Finised Serializing!!!";
            if (_canShowXml)
                ShowXml();
        }
        private Employee DoDeserialize()
        {
            _employee = Work.DoDeserialize();
            if (_employee != null)
            {
                EmployeeId = _employee.EmployeeId;
                FirstName = _employee.FirstName;
                LastName = _employee.LastName;
                HomePhone = _employee.HomePhone;
                Notes = _employee.Notes;
            }
            return _employee;
        }

        private void ShowXml()
        {
            //Check if xml file exists!!!
            var directoryName = new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName;
            var filePath = $"{directoryName}\\EmployeeData.xml";
            if (File.Exists(filePath))
            {
                Process.Start("notepad", filePath);
            }
                
        }
        private void ClearFields()
        {
            EmployeeId = 0;
            FirstName = string.Empty;
            LastName = string.Empty;
            HomePhone = string.Empty;
            Notes = string.Empty;
            CanShowXml = false;
            State = String.Empty;
        }
        
        #endregion
    }
}
