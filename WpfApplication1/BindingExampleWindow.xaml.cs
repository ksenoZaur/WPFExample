using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using WpfApplication1.Annotations;

namespace WpfApplication1
{
    public class Employee : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string firstName;
        private string lastName;
        private int age;

        #region << prop >>

        public string FirstName
        {
            get { return firstName; }
            set
            {
                firstName = value;
                UpdateTarget();
            } 
        }
        public string LastName {
            get { return lastName; }
            set
            {
                lastName = value;
                UpdateTarget();
            }
        }

        public int Age
        {
            get { return age; }
            set
            {
                age = value;
                UpdateTarget();
            }
        }

        #endregion
        
        [NotifyPropertyChangedInvocator]
        protected virtual void UpdateTarget([CallerMemberName] string propertyName = null)
        {
            if( PropertyChanged != null )
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    
    public partial class BindingExampleWindow : Window, INotifyPropertyChanged
    {
        public ObservableCollection<Employee> Employees { get; set; }
        private Employee selectedEmployee;
        public Employee SelectedEmployee
        {
            get { return selectedEmployee; }
            set 
            { 
                selectedEmployee = value;
                OnPropertyChanged();
            }
        } 
            
        public BindingExampleWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            
            Employees = new ObservableCollection<Employee>();
            Employees.Add( new Employee()
            {
                FirstName = "Mihail",
                Age=12,
                LastName = "Ksenofontov"
            });
            Employees.Add( new Employee()
            {
                FirstName = "Dmitry",
                Age=21,
                LastName = "Poletaev"
            });
            Employees.Add( new Employee()
            {
                FirstName = "Segey",
                Age=16,
                LastName = "Pankratov"
            });
            
            //lb_emps.ItemsSource = Employees;
        }

        public void btn_Add_click(object sender, RoutedEventArgs rea)
        {
            this.Employees.Add(new Employee(){ FirstName = "Unknown"});
        }
        
        public void btn_Remove_click(object sender, RoutedEventArgs rea)
        {
            if (lb_emps.SelectedItem != null)
                Employees.Remove((lb_emps.SelectedItem as Employee));
        }


        private void is_selected(object sender, RoutedEventArgs e)
        {
            this.SelectedEmployee = lb_emps.SelectedItem as Employee;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if( PropertyChanged != null )
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}