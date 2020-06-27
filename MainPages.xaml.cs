using Day2AppList.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Day2AppList
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPages : ContentPage
    {
        List<Employee> empList { get; set; }
        private int _selectedItemIndex { get; set; }
        public List<Cart> selectList { get; set; }

        public Employee et;
        public MainPages()
        {
            InitializeComponent();
            selectList = new List<Cart>();

               empList = new List<Employee>();


            Employee emp1 = new Employee { EmpName = "Roger Federer", EmpDesig = "HR", Image = "person.png", TickImg="uncheck.png"};
            Employee emp2 = new Employee { EmpName = "Rohan Sahi", EmpDesig = "Agent", Image = "agent.jpg", TickImg = "uncheck.png" };
            Employee emp3 = new Employee { EmpName = "Amy Jhonson", EmpDesig = "HR", Image = "FAgent.png", TickImg = "uncheck.png" };
            Employee emp4 = new Employee { EmpName = "Rocky Jhony", EmpDesig = "Employee", Image = "Emp.jpg", TickImg = "uncheck.png" };
            empList.Add(emp1);
            empList.Add(emp2);
            empList.Add(emp3);
            empList.Add(emp4);

            listImpl.ItemsSource = empList;
            
            
        }
            
     
        public void listImpl_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {


            _selectedItemIndex = empList.IndexOf((Employee)e.SelectedItem);
            if (empList[_selectedItemIndex].TickImg.Equals("uncheck.png"))
            {
                      
                empList[_selectedItemIndex].TickImg = "check.png";


                selectList.Add(new Cart
                {
                    CartEmpName = empList[_selectedItemIndex].EmpName,
                        CartEmpDesig = empList[_selectedItemIndex].EmpDesig,
                    CartImage = empList[_selectedItemIndex].Image,
                    CartTickImg= "uncheck.png"
                }) ;
                    
                    
                   
                

                }
            else
            {
                empList[_selectedItemIndex].TickImg = "uncheck.png";
            }
            //empList[_selectedItemIndex].TickImg = empList[_selectedItemIndex].TickImg
            //    .Equals("uncheck.png")
            //    ? "check.png"
            //    : "uncheck.png";
            listImpl.ItemsSource = null;
            listImpl.ItemsSource = empList;


        }

        async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SecondPage(selectList));
        }
    }
    }

