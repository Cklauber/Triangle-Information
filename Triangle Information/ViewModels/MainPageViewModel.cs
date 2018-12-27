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
        private int value1_ = 0;
        private int value2_ = 0;
        private int value3_ = 0;
        private Triangle triangle_ = null;
        private bool isValidated_ = true;
        private string result_ = "";
        private string triangleType_ = "";

        /**
         * Setting up the Properties
         */
        public string Side1
        {
            //The getters convert 0 to "" so that when the application starts we have empty fields
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
                //In case the field is empty, we don't want the application to break.
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
        /**
         * Starting up with the logic
         */
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
                /*
                 * I opted to create this as a singleton so that we don't
                 * instanciate the triangle every time we run the validator
                 */
                if(triangle_ == null)
                {
                    triangle_ = new Triangle(value1_, value2_, value3_);
                }
                else
                {
                    triangle_.setValue1(value1_);
                    triangle_.setValue2(value2_);
                    triangle_.setValue3(value3_);
                }

                //Now we will check if this is a valid triangle or not.
                if (triangle_.isValid())
                {
                    result_ = "This is a valid triangle";
                    triangleType_ = "Triangle type: " + triangle_.getTriangleType();
                    OnPropertyChanged("TriangleType");
                }
                else
                {
                    result_ = "This is not a valid triangle";
                    triangleType_ = triangle_.getTriangleType();
                    OnPropertyChanged("TriangleType");
                }
                OnPropertyChanged("Result");
            }
            //This is in case our fields just have 0s(in other words no values in there)
            else
            {
                isValidated_ = false;
                OnPropertyChanged("IsValidated");
            }
        }
    }
}