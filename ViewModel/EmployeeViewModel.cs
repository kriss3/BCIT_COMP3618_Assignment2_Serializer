﻿using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Windows.Input;
using Worker;

namespace ViewModel
{
    /// <summary>
    /// ViewModel Class to satisfy MVVM pattern;
    /// Krzysztof Szczurowski;
    /// BCIT COMP 3618;
    /// Repo: https://github.com/kriss3/BCIT_COMP3618_Assignment2_Serializer.git
    /// </summary>
    public class EmployeeViewModel : INotifyPropertyChanged
    {
        #region ViewModel State
        private int _employeeId;
        private string _firstName = String.Empty;
        private string _lastName = String.Empty;
        private string _homePhone = String.Empty;
        private string _notes = String.Empty;
        private bool _canShowXml = false;
        private string _state = string.Empty;
        private int _noOfSubordinates;
        private Manager _manager;

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
        public int NoOfSubordinates
        {
            get { return _noOfSubordinates; }
            set
            {
                if (value != _noOfSubordinates)
                {
                    _noOfSubordinates = value;
                    OnPropertyChanged("NoOfSubordinates");
                }
            }
        }
        public Manager Manager
        {
            get { return _manager; }
            set
            {
                if (value != _manager)
                    _manager = value;
                OnPropertyChanged("Manager");
            }
        }

        private ICommand _serializeCommand;
        private ICommand _deserializeCommand;
        private ICommand _clearCommand;

        #endregion

        #region Events
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        #region Commands
        public ICommand SerializeCommand
        {
            get
            {
                if (_serializeCommand == null)
                {
                    _serializeCommand =
                        new RelayCommand(x => DoSerialize(_manager), x => true);
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
        #endregion

        #region Private Methods
        private void DoSerialize(Manager _mgr)
        {
            _mgr = new Manager { NoOfSubordinates = NoOfSubordinates, EmployeeId = EmployeeId, FirstName = FirstName, LastName = LastName, HomePhone = HomePhone, Notes = Notes};
            Work.DoSerialize(_mgr);
            State = "Finished Serializing Manager object !";
            if (_canShowXml)
                ShowXml();
        }
        private Manager DoDeserialize()
        {
            _manager = Work.DoDeserialize();
            if (_manager != null)
            {
                EmployeeId = _manager.EmployeeId;
                FirstName = _manager.FirstName;
                LastName = _manager.LastName;
                HomePhone = _manager.HomePhone;
                Notes = _manager.Notes;
                NoOfSubordinates = _manager.NoOfSubordinates;
                State = "Finished DeSerializing Manager object !";
            }
            return _manager;
        }
        private void ShowXml()
        {
            //Check if xml file exists!!!
            var directoryName = new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName;
            var filePath = $"{directoryName}\\ManagerData.xml";
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
            NoOfSubordinates = 0;
        }
        
        #endregion
    }
}
