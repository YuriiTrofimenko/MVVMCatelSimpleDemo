namespace MVVMCatelSimpleDemo.ViewModels
{
    using Catel.Data;
    using Catel.MVVM;
    using System.Threading.Tasks;
    using System.Windows;

    public class MainWindowViewModel : ViewModelBase
    {
        public static readonly PropertyData FirstNameProperty =
            RegisterProperty(nameof(FirstName), typeof(string), null);

        public MainWindowViewModel()
        {
            Submit = new Command(OnSubmitExecute, OnSubmitCanExecute);
        }

        public override string Title { get { return "Welcome to MVVMCatelSimpleDemo"; } }


        public string FirstName
        {
            get { return GetValue<string>(FirstNameProperty); }
            set { SetValue(FirstNameProperty, value); }
        }


        public Command Submit { get; private set; }

        private bool OnSubmitCanExecute()
        {
            return FirstName != null && FirstName.Length > 0 && FirstName.Length < 50;
        }

        private void OnSubmitExecute()
        {
            MessageBox.Show(FirstName);
        }

        // TODO: Register models with the vmpropmodel codesnippet
        // TODO: Register view model properties with the vmprop or vmpropviewmodeltomodel codesnippets
        // TODO: Register commands with the vmcommand or vmcommandwithcanexecute codesnippets

        protected override async Task InitializeAsync()
        {
            await base.InitializeAsync();

            // TODO: subscribe to events here
        }

        protected override async Task CloseAsync()
        {
            // TODO: unsubscribe from events here

            await base.CloseAsync();
        }
    }
}
