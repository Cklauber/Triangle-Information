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
        private string result_ = "";
        private string triangleType_ = "";

        public string Side1
        {
            get
            {
                if(value1_ == 0)
                {
                    return "";
                }
                else
                {
                    return value1_.ToString();
                }
            }
            set
            {
                if (value == "")
                {
                    value = "0";
                }
                value1_ = Int32.Parse(value);
                OnPropertyChanged("Value1");
                validator();

            }
        }
        public string Side2
        {
            get
            {
                if (value2_ == 0)
                {
                    return "";
                }
                else
                {
                    return value2_.ToString();
                }
            }
            set
            {
                if (value == "")
                {
                    value = "0";
                }
                value2_ = Int32.Parse(value);
                OnPropertyChanged("Value2");
                validator();

            }
        }
        public String Side3
        {
            get
            {
                if (value3_ == 0)
                {
                    return "";
                }
                else
                {
                    return value2_.ToString();
                }
            }
            set
            {
                if(value == "")
                {
                    value = "0";
                }
                value3_ = Int32.Parse(value);
                OnPropertyChanged("Value3");
                validator();
            }
        }
        public string Result
        {
            get => result_;
        }
        public string TriangleType
        {
            get => triangleType_;
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
                triangle_ = new Triangle(value1_, value2_, value3_);
                System.Diagnostics.Debug.WriteLine(value1_);
                System.Diagnostics.Debug.WriteLine(value2_);
                System.Diagnostics.Debug.WriteLine(value3_);
                System.Diagnostics.Debug.WriteLine(triangle_.isValid());
                if (triangle_.isValid())
                {
                    result_ = "This is a valid triangle";
                    triangleType_ = triangle_.triangleType();
                    OnPropertyChanged("TriangleType");
                }
                else
                {
                    result_ = "This is not a valid triangle";
                }

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