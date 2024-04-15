using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Shahzeb.Model;
using System.Collections.ObjectModel;
using System.Windows;
using System.Configuration;
using System.Runtime.CompilerServices;


namespace Shahzeb.ViewModel
{
    public class EmployeesViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void RaisePropertyChanged([CallerMemberName] string property = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        protected virtual void SetProperty<T>(ref T member, T val, [CallerMemberName] string propertyName = null)
        {
            if (object.Equals(member, val)) return;
            member = val;
            RaisePropertyChanged(propertyName);
        }
        private void OnPropertyChanged(string propertyName)
        {
            if(PropertyChanged != null) 
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }

        }

        EmployeeOperation operation;
        SalaryOperations salary;
        public EmployeesViewModel()
        {
            operation = new EmployeeOperation();
            salary = new SalaryOperations();
            LoadData();
            CurrentEmployee= new Employee();
            saveCommand = new RelayCommand(Save);
            deleteCommand = new RelayCommand(Delete);
            currentSalary = new Employee_Salary();
            ssaveCommand = new RelayCommand(sSave);
            sdeleteCommand = new RelayCommand(sDelete);
            LoadSalaryData();
            Message = "";
        }
        private ObservableCollection<Employee> employeesList;

        public ObservableCollection<Employee> EmployeesList
        {
            get { return employeesList; }
            set { employeesList = value; OnPropertyChanged("EmployeesList"); }
        }

        private ObservableCollection<Employee_Salary> displayemployee_SalariesList;
        public ObservableCollection<Employee_Salary> Displayemployee_SalariesList
        {
            get { return displayemployee_SalariesList; }
            set { displayemployee_SalariesList = value; OnPropertyChanged("Displayemployee_SalariesList"); }
        }

        private Employee selectedBody;

        public Employee SelectedBody
        {
            get { return selectedBody; }
            set { 
                selectedBody = value;
                if(value != null) 
                {
                    DeleteVisibility = Visibility.Visible;
                    LoadSalaryData();
                    Message=value.EmployeeId.ToString();

                }
                //CurrentEmployee = value;
                OnPropertyChanged("SelectedBody"); }
        }

        public Employee_Salary selectedSalary;
        public Employee_Salary SelectedSalary
        {
            get { return selectedSalary; }
            set { selectedSalary = value;
                if (value != null)
                { sDeleteVisibility = Visibility.Visible; }
            }
        }

        private void LoadSalaryData()
        {
            Displayemployee_SalariesList = new ObservableCollection<Employee_Salary>(salary.GetAllS(SelectedBody));
            
        }

        private void LoadData()
        {
            EmployeesList = new ObservableCollection<Employee>(operation.GetAll());
        }


        private Employee currentEmployee;

        public Employee CurrentEmployee
        {
            get { return  currentEmployee; }
            set { currentEmployee = value;
                OnPropertyChanged("CurrentEmployee");
            }
        }

        private Employee_Salary currentSalary;

        public Employee_Salary CurrentSalary
        {
            get { return currentSalary; }
            set
            {
                currentSalary = value;
                OnPropertyChanged("CurrentSalary");
            }
        }

        public string message;
        public string Message
        {
            get { return message; }
            set {  if (value==null || value == "") 
                {
                    message = "";
                }
                else 
                {
                    message = "Salary Detail Of Employee  " + value;
                }
                OnPropertyChanged("Message"); }
        }

        private RelayCommand saveCommand;
        public RelayCommand SaveCommand
        {
            get { return saveCommand; }
        }
        private RelayCommand deleteCommand;
        public RelayCommand DeleteCommand
        {
            get { return deleteCommand; }
        }
        public void Delete()
        {
            try
            {
                if(SelectedBody != null) 
                {
                    operation.Delete(SelectedBody);
                    DeleteVisibility = Visibility.Collapsed;
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Plese Select Item From List To Delete.");
                }
            }
            catch (Exception ex) { }
        }

        public void Save()
        {
            try
            {
                if(CurrentEmployee.EmployeeId == 0) 
                {
                    MessageBox.Show("Plese Enter Valid EmployeeId");
                    return;
                }
                operation.Add(CurrentEmployee);
                //CurrentEmployee.EmployeeId = 0;
                SetCurrentEmployeeToNull();


                LoadData();

            }
            catch (Exception ex) 
            {

            }

        }
        public void SetCurrentEmployeeToNull()
        {
                CurrentEmployee.EmployeeId = 0;
                CurrentEmployee.Fristname = "";
                CurrentEmployee.Lastname = "";
                CurrentEmployee.EmailId = "";
                CurrentEmployee.Location = "";
                CurrentEmployee.DateOfBirth = "";
        }
        public Visibility deleteVisibility = Visibility.Collapsed;
        public Visibility DeleteVisibility
        {
            get { return deleteVisibility; }
            set { SetProperty(ref deleteVisibility, value); }
        }




        private RelayCommand ssaveCommand;
        public RelayCommand sSaveCommand
        {
            get { return ssaveCommand; }
        }
        private RelayCommand sdeleteCommand;
        public RelayCommand sDeleteCommand
        {
            get { return sdeleteCommand; }
        }
        public void sDelete()
        {
            try
            {
                if (SelectedSalary != null)
                {
                    salary.DeleteS(SelectedSalary);
                    sDeleteVisibility = Visibility.Collapsed;
                    LoadSalaryData();
                }
                else
                {
                    MessageBox.Show("Plese Select Item From List To Delete.");
                }
            }
            catch (Exception ex) { }
        }

        public void sSave()
        {
            try
            {
                if (CurrentSalary.Payroll == 0)
                {
                    MessageBox.Show("Plese Enter Valid Payroll");
                    return;
                }
                CurrentSalary.EmployeeId = SelectedBody.EmployeeId;
                salary.AddS(CurrentSalary);
                //CurrentEmployee.EmployeeId = 0;
                sSetCurrentEmployeeToNull();
                LoadSalaryData();

                //LoadData();

            }
            catch (Exception ex)
            {

            }

        }
        public void sSetCurrentEmployeeToNull()
        {
            CurrentSalary.Value = 0;
            CurrentSalary.Payroll= 0;
            CurrentSalary.Name = "";
            CurrentSalary.Type = "";
        }
        public Visibility sdeleteVisibility = Visibility.Collapsed;
        public Visibility sDeleteVisibility
        {
            get { return sdeleteVisibility; }
            set { SetProperty(ref sdeleteVisibility, value); }
        }


    }
}
