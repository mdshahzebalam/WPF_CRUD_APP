using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
namespace Shahzeb.Model
{
    public class Employee : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName) 
        {
            if(PropertyChanged != null) 
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        private int employeeId;







        public int EmployeeId
        {
            get { return employeeId; }
            set { employeeId = value; OnPropertyChanged("EmployeeId"); }
        }
        private string fristname;






        public string Fristname





        {
            get { return fristname; }
            set { fristname = value; OnPropertyChanged("Fristname"); }





            #region pp











            #endregion







            #region hello














            #endregion






        }



        private string lastname;

















        public string Lastname
        {





            get { return lastname; }







            set { lastname = value; OnPropertyChanged("Lastname"); }














        }
















        private string emailId;






        public string EmailId
        {
            get { return emailId; }
            set { emailId = value; OnPropertyChanged("EmailId"); }
        }

        private string location;

        public string Location




        {
            get { return location; }





            set { location = value; OnPropertyChanged("Location"); 
            
            









            
            
            }





        }
        //private string city;



        //nothing


        //this is comment


        private string dateOfBirth;



        //hello








        //nothing
        //d





        //pp

        //op



        public string DateOfBirth




        {





            get { return dateOfBirth; }







            set { dateOfBirth = value; OnPropertyChanged("DateOfBirth");
            
            
            
            
            
            
            }







        }

    }
}
