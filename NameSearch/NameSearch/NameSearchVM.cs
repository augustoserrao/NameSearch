/* Augusto Serrao
   Deepti Aggarwal
   Hartaj Dhillon
   Gagandeep Singh
   Shoaib Hassan
*/

using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace NameSearch
{
    class NameSearchVM : INotifyPropertyChanged
    {
        public enum ResultList
        {
            RESULT_IDLE,
            RESULT_ERROR_NO_NAME,
            RESULT_BOY_NOT_POPULAR,
            RESULT_GIRL_NOT_POPULAR,
            RESULT_BOY_POPULAR,
            RESULT_GIRL_POPULAR,
            RESULT_NEITHER_POPULAR,
            RESULT_BOTH_POPULAR
        }

        private ObservableCollection<string> boyNamesList;
        private ObservableCollection<string> girlNamesList = new ObservableCollection<string>();

        private string boyName = "";
        private string girlName = "";
        private ResultList result = ResultList.RESULT_IDLE;

        public string BoyName
        {
            get { return boyName; }
            set { boyName = value; _propertyChanged(); }
        }

        public string GirlName
        {
            get { return girlName; }
            set { girlName = value; _propertyChanged(); }
        }

        public ResultList Result
        {
            get { return result; }
            set { result = value; _propertyChanged(); }
        }

        public NameSearchVM()
        {
            boyNamesList = new ObservableCollection<string>(NameFiles.GetBoyNames());
            girlNamesList = new ObservableCollection<string>(NameFiles.GetGirlNames());
        }

        // Check if names are popular
        public void CheckNames()
        {
            bool isBoyPopular = boyNamesList.Contains(BoyName.ToLower());
            bool isGirlPopular = girlNamesList.Contains(GirlName.ToLower());

            if (BoyName == "" && GirlName == "")
            {
                Result = ResultList.RESULT_ERROR_NO_NAME;
            }
            else if (BoyName != "" && GirlName == "")
            {
                if (isBoyPopular)
                    Result = ResultList.RESULT_BOY_POPULAR;
                else
                    Result = ResultList.RESULT_BOY_NOT_POPULAR;
            }
            else if (BoyName == "" && GirlName != "")
            {
                if (isGirlPopular)
                    Result = ResultList.RESULT_GIRL_POPULAR;
                else
                    Result = ResultList.RESULT_GIRL_NOT_POPULAR;
            }
            else
            {
                if (isBoyPopular && isGirlPopular)
                    Result = ResultList.RESULT_BOTH_POPULAR;
                else if (isBoyPopular && !isGirlPopular)
                    Result = ResultList.RESULT_BOY_POPULAR;
                else if (!isBoyPopular && isGirlPopular)
                    Result = ResultList.RESULT_GIRL_POPULAR;
                else
                    Result = ResultList.RESULT_NEITHER_POPULAR;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void _propertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
