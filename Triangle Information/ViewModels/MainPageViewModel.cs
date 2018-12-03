using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Triangle_Information.ViewModels;

namespace Triangle_Information.ViewModel
{
    class MainPageViewModel : BaseModel
    {
        private Triangle triangle_ = null;
        private int value1_ = 0;
        private int value2_ = 0;
        private int value3_ = 0;
        private bool isValidated_ = true;
        private string result_ = "something";

        public int Side1
        {
            get { return value1_; }
            set
            {
                value1_ = value;
                OnPropertyChanged("Value1");
                validator();

            }
        }
        public int Side2
        {
            get { return value2_; }
            set
            {
                value2_ = value;
                OnPropertyChanged("Value2");
                validator();
            }
        }
        public int Side3
        {
            get { return value3_; }
            set
            {
                value3_ = value;
                OnPropertyChanged("Value3");
                validator();
            }
        }
        public string Result
        {
            get => result_;
        }
        public bool IsValidated
        {
            get => isValidated_;
        }
        public ICommand Validate
        {
            get
            {
                return new DelegateCommand(validator);
            }
        }
        public void validator()
        {
            if (value1_ != 0 & value2_ != 0 & value3_ != 0)
            {
                isValidated_ = true;
                OnPropertyChanged("IsValidated");
                result_ = "This is a valid triangle";
                OnPropertyChanged("Result");
                System.Diagnostics.Debug.WriteLine("Valid");
            }
            else
            {
                isValidated_ = false;
                OnPropertyChanged("IsValidated");
                System.Diagnostics.Debug.WriteLine("Not Valid");
            }
        }
    }
}