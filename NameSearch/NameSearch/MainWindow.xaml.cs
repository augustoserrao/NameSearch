/* Augusto Serrao
   Deepti Aggarwal
   Hartaj Dhillon
   Gagandeep Singh
   Shoaib Hassan
*/

using System.Windows;

namespace NameSearch
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public struct ResultAttributes
        {
            public string message;
            public string foreground;
            public Visibility visibility;

            public ResultAttributes(string msg, string frg, Visibility vis)
            {
                this.message = msg;
                this.foreground = frg;
                this.visibility = vis;
            }
        }

        public static ResultAttributes[] ResultAttributesList =
        {
            new ResultAttributes(""                          , ""     , Visibility.Hidden),  // RESULT_IDLE
            new ResultAttributes("Enter a name first"        , "red"  , Visibility.Visible), // RESULT_ERROR_NO_NAME
            new ResultAttributes("Boy's name is not popular" , "red"  , Visibility.Visible), // RESULT_BOY_NOT_POPULAR
            new ResultAttributes("Girl's name is not popular", "red"  , Visibility.Visible), // RESULT_GIRL_NOT_POPULAR
            new ResultAttributes("Boy's name is popular"     , "green", Visibility.Visible), // RESULT_BOY_POPULAR
            new ResultAttributes("Girl's name is popular"    , "green", Visibility.Visible), // RESULT_GIRL_POPULAR
            new ResultAttributes("Neither names are popular" , "red"  , Visibility.Visible), // RESULT_NEITHER_POPULAR
            new ResultAttributes("Both names are popular"    , "green", Visibility.Visible), // RESULT_BOTH_POPULAR
        };
         
        NameSearchVM vm = new NameSearchVM();

        public MainWindow()
        {
            InitializeComponent();
            DataContext = vm;
        }

        private void Button_Search_Click(object sender, RoutedEventArgs e)
        {
            vm.CheckNames();
        }
    }
}
